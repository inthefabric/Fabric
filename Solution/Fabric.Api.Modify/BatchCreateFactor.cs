using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Batch;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using ServiceStack.Text;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModFactorsBatchUri, typeof(FabBatchResult),
		Auth=ServiceAuthType.Member)]
	public class BatchCreateFactor : BaseModifyFunc<FabBatchResult[]> { //TEST: BatchCreateFactor
		
		public const string FactorsParam = "Factors";

		[ServiceOpParam(ServiceOpParamType.Form, FactorsParam, 0, typeof(Class))]
		private FabBatchNewFactor[] vObjects;
		
		private readonly string vObjectsJson;
		private FactorOperationSet[] vOpSets;
		private FabBatchResult[] vResults;
		private List<List<int>> vIndexes;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public BatchCreateFactor(IModifyTasks pTasks, string pObjectsJson) : base(pTasks) {
			vObjectsJson = pObjectsJson;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vObjectsJson == null ) {
				throw new FabArgumentNullFault(FactorsParam);
			}

			try {
				vObjects = JsonSerializer.DeserializeFromString<FabBatchNewFactor[]>(vObjectsJson);
			}
			catch ( Exception ) {
				throw new FabArgumentValueFault("Malformed "+FactorsParam+" JSON data.");
			}

			int n = vObjects.Length;

			if ( n == 0 ) {
				throw new FabArgumentValueFault("The "+FactorsParam+" batch list is empty.");
			}

			//TODO: BatchCreateFactor max length bound (first, determine a reasonable maximum)

			////

			var currIndexGroup = new List<int>();
			vIndexes = new List<List<int>>();
			vIndexes.Add(currIndexGroup);

			vOpSets = new FactorOperationSet[n];
			vResults = new FabBatchResult[n];

			const int size = 50;

			for ( int i = 0 ; i < n ; ++i ) {
				FabBatchNewFactor nf = vObjects[i];

				var res = new FabBatchResult();
				res.BatchId = nf.BatchId;
				vResults[i] = res;

				if ( currIndexGroup.Count == size ) {
					currIndexGroup = new List<int>();
					vIndexes.Add(currIndexGroup);
				}

				try {
					var fos = new FactorOperationSet(Tasks, nf);
					fos.ValidateParamsForBatch();
					vOpSets[i] = fos;
					currIndexGroup.Add(i);
				}
				catch ( FabFault fault ) {
					res.Error = FabError.ForFault(fault);
				}
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabBatchResult[] Execute() {
			Member mem = GetContextMember();

			VerifyRequiredArtifacts();

			////
			
			int n = vObjects.Length;

			for ( int i = 0 ; i < n ; ++i ) {
				if ( vResults[i].Error == null ) {
					vOpSets[i].SetCreator(mem);
				}
			}

			var opt = new ParallelOptions();
			opt.MaxDegreeOfParallelism = 3; //TODO: use DB node count
			Parallel.ForEach(vIndexes, opt, InsertFactors);
			return vResults;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void VerifyRequiredArtifacts() {
			var map = new Dictionary<long, IList<KeyValuePair<int, string>>>();
			int count = 0;
			int hit = 0;

			foreach ( List<int> indexList in vIndexes ) {
				foreach ( int i in indexList ) {
					FactorOperationSet fos = vOpSets[i];

					foreach ( KeyValuePair<string, long> pair in fos.RequiredArtifacts ) {
						count++;

						if ( ApiCtx.Cache.Memory.FindExists<Artifact>(pair.Value) == true ) {
							hit++;
							continue; //skip verification; the Artifact exists
						}

						if ( !map.ContainsKey(pair.Value) ) {
							map.Add(pair.Value, new List<KeyValuePair<int, string>>());
						}

						map[pair.Value].Add(new KeyValuePair<int, string>(i, pair.Key));
					}
				}
			}

			Log.Debug("Artifact Cache: "+hit+"/"+count);

			var queries = new List<IWeaverScript>();

			foreach ( long artId in map.Keys ) {
				var q = new WeaverQuery();
				string artParam = q.AddParam(new WeaverQueryVal(artId));
				q.FinalizeQuery("g.V('"+PropDbName.Artifact_ArtifactId+"',"+artParam+")."+
					PropDbName.Artifact_ArtifactId);
				queries.Add(q);
			}

			////

			IApiDataAccess data = ApiCtx.DbData("GetBatchArtifacts", queries);
			int n = queries.Count;
			
			for ( int i = 0 ; i < n ; ++i ) {
				IList<string> list = data.Result.GetTextListForCommandAt(i+1); //skip Session.Start
				string val = null;

				if ( list != null && list.Count > 0 ) {
					val = list[0];
				}

				long id;
				long.TryParse(val, out id);
				long expectId = map.Keys.ElementAt(i);

				if ( id == expectId ) {
					ApiCtx.Cache.Memory.AddExists<Artifact>(id);
					continue;
				}

				foreach ( KeyValuePair<int, string> pair in map[expectId] ) {
					var nf = new FabNotFoundFault(typeof(Artifact), pair.Value+"="+expectId);
					vResults[pair.Key].Error = FabError.ForFault(nf);
				}
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void InsertFactors(IList<int> pIndexes, ParallelLoopState pState, long pThreadId) {
			var list = new List<IWeaverScript>();

			foreach ( int i in pIndexes ) {
				FabBatchResult res = vResults[i];

				if ( res.Error != null ) {
					continue;
				}

				try {
					FactorOperationSet fos = vOpSets[i];
					list.AddRange(fos.GetNodeQueries(ApiCtx));
					res.ResultId = fos.FactorId;
				}
				catch ( FabFault fault ) {
					res.Error = FabError.ForFault(fault);
				}
			}

			////

			if ( list.Count == 0 ) {
				return;
			}

			try {
				ApiCtx.DbData("BatchCreateFactorNodeTx", list);
			}
			catch ( Exception e ) {
				Log.Error("BatchCreateFactor batch exception: "+e);

				foreach ( int i in pIndexes ) {
					vResults[i].Error = FabError.ForInternalServerError();
				}
			}
		}

	}
	

	/*================================================================================================*/
	public class FactorOperationSet {

		public long FactorId { get; private set; }
		public List<KeyValuePair<string, long>> RequiredArtifacts { get; private set; }

		private readonly CreateFactor vCreate;
		private readonly List<AttachFactorElement> vElems;
		private readonly FabBatchNewFactor vBatch;
		private Member vMember;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorOperationSet(IModifyTasks pTasks, FabBatchNewFactor pBatch) {
			vBatch = pBatch;

			vCreate = new CreateFactor(pTasks, vBatch.PrimaryArtifactId, vBatch.RelatedArtifactId,
				vBatch.FactorAssertionId, vBatch.IsDefining, vBatch.Note);

			vElems = new List<AttachFactorElement>();

			if ( vBatch.Descriptor != null ) {
				var desc = new AttachDescriptor(pTasks, 0, vBatch.Descriptor.TypeId,
					vBatch.Descriptor.PrimaryArtifactRefineId,
					vBatch.Descriptor.RelatedArtifactRefineId,
					vBatch.Descriptor.TypeRefineId);
				vElems.Add(desc);
			}
			else {
				throw new FabArgumentNullFault("Descriptor");
			}

			if ( vBatch.Director != null ) {
				var dir = new AttachDirector(pTasks, 0, vBatch.Director.TypeId,
					vBatch.Director.PrimaryActionId, vBatch.Director.RelatedActionId);
				vElems.Add(dir);
			}

			if ( vBatch.Eventor != null ) {
				var eve = new AttachEventor(pTasks, 0, vBatch.Eventor.TypeId,
					vBatch.Eventor.PrecisionId, vBatch.Eventor.DateTime);
				vElems.Add(eve);
			}

			if ( vBatch.Identor != null ) {
				var iden = new AttachIdentor(pTasks, 0, vBatch.Identor.TypeId, vBatch.Identor.Value);
				vElems.Add(iden);
			}

			if ( vBatch.Locator != null ) {
				var loc = new AttachLocator(pTasks, 0, vBatch.Locator.TypeId, vBatch.Locator.ValueX,
					vBatch.Locator.ValueY, vBatch.Locator.ValueZ);
				vElems.Add(loc);
			}

			if ( vBatch.Vector != null ) {
				var vec = new AttachVector(pTasks, 0, vBatch.Vector.TypeId, vBatch.Vector.Value,
					vBatch.Vector.AxisArtifactId, vBatch.Vector.UnitId, vBatch.Vector.UnitPrefixId);
				vElems.Add(vec);
			}

			RequiredArtifacts = new List<KeyValuePair<string, long>>();
			RequiredArtifacts.AddRange(vCreate.GetRequiredArtifactIdsForBatch().ToList());

			foreach ( AttachFactorElement afe in vElems ) {
				Dictionary<string, long> arts = afe.GetRequiredArtifactIdsForBatch();
				
				if ( arts == null ) {
					continue;
				}

				RequiredArtifacts.AddRange(arts.ToList());
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ValidateParamsForBatch() {
			vCreate.ValidateParamsForBatch();

			foreach ( AttachFactorElement afe in vElems ) {
				afe.ValidateParamsForBatch();
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetCreator(Member pMember) {
			vMember = pMember;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IList<IWeaverScript> GetNodeQueries(IApiContext pApiCtx) {
			FactorId = pApiCtx.GetSharpflakeId<Factor>();

			var f = new Factor();
			f.FactorId = FactorId;
			f.FactorAssertionId = vBatch.FactorAssertionId;
			f.IsDefining = vBatch.IsDefining;
			f.Note = vBatch.Note;
			f.Created = pApiCtx.UtcNow.Ticks;
			f.Completed = f.Created;

			f.Descriptor_TypeId = vBatch.Descriptor.TypeId;

			if ( vBatch.Director != null ) {
				f.Director_TypeId = vBatch.Director.TypeId;
				f.Director_PrimaryActionId = vBatch.Director.PrimaryActionId;
				f.Director_RelatedActionId = vBatch.Director.RelatedActionId;
			}

			if ( vBatch.Eventor != null ) {
				f.Eventor_TypeId = vBatch.Eventor.TypeId;
				f.Eventor_PrecisionId = vBatch.Eventor.PrecisionId;
				f.Eventor_DateTime = vBatch.Eventor.DateTime;
			}

			if ( vBatch.Identor != null ) {
				f.Identor_TypeId = vBatch.Identor.TypeId;
				f.Identor_Value = vBatch.Identor.Value;
			}

			if ( vBatch.Locator != null ) {
				f.Locator_TypeId = vBatch.Locator.TypeId;
				f.Locator_ValueX = vBatch.Locator.ValueX;
				f.Locator_ValueY = vBatch.Locator.ValueY;
				f.Locator_ValueZ = vBatch.Locator.ValueZ;
			}

			if ( vBatch.Vector != null ) {
				f.Vector_TypeId = vBatch.Vector.TypeId;
				f.Vector_UnitId = vBatch.Vector.UnitId;
				f.Vector_UnitPrefixId = vBatch.Vector.UnitPrefixId;
				f.Vector_Value = vBatch.Vector.Value;
			}

			////

			var list = new List<IWeaverScript>();

			var txb = new TxBuilder();
			var facBuild = new FactorBuilder(txb, f);
			facBuild.AddNode();

			var facVar = new WeaverVarAlias<Factor>(txb.Transaction) { Name = "_F" };
			var q = new WeaverQuery();
			q.FinalizeQuery(facBuild.NodeVar.Name);
			q.StoreResultAsVar(facVar);
			txb.Transaction.AddQuery(q);

			txb.Transaction.AddQuery(
				ApiFunc.NewPathFromVar(facVar, false).Prop(x => x.Id).End()
			);

			list.Add(txb.Finish());

			AppendQueries(list, facVar, fb => {
				fb.SetUsesPrimaryArtifact(vBatch.PrimaryArtifactId);
				fb.SetUsesRelatedArtifact(vBatch.RelatedArtifactId);
				fb.SetInMemberCreates(vMember);
			});

			if ( vBatch.Descriptor.PrimaryArtifactRefineId != null ) {
				AppendQueries(list, facVar, fb =>
					fb.SetDescriptorRefinesPrimaryWithArtifact(
						(long)vBatch.Descriptor.PrimaryArtifactRefineId)
				);
			}

			if ( vBatch.Descriptor.RelatedArtifactRefineId != null ) {
				AppendQueries(list, facVar, fb =>
					fb.SetDescriptorRefinesRelatedWithArtifact(
						(long)vBatch.Descriptor.RelatedArtifactRefineId)
				);
			}

			if ( vBatch.Descriptor.TypeRefineId != null ) {
				AppendQueries(list, facVar, fb =>
					fb.SetDescriptorRefinesTypeWithArtifact((long)vBatch.Descriptor.TypeRefineId)
				);
			}

			if ( vBatch.Vector != null ) {
				AppendQueries(list, facVar, fb =>
					fb.SetVectorUsesAxisArtifact(vBatch.Vector.AxisArtifactId)
				);
			}

			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AppendQueries(IList<IWeaverScript> pList, IWeaverVarAlias<Factor> pFacVar,
																	Action<FactorBuilder> pAction) {
			var facBuild = new FactorBuilder(new TxBuilder());
			facBuild.SetNodeVar(pFacVar);
			pAction(facBuild);

			IWeaverQuery q = new WeaverQuery();
			q.FinalizeQuery("1"); //skip unnecessary return data
			facBuild.TxBuild.Transaction.AddQuery(q);
			pList.Add(facBuild.TxBuild.Finish());
		}

	}

}