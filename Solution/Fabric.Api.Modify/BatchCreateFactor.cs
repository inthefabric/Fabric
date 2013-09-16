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
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Weaver;
using ServiceStack.Text;
using Weaver.Core.Pipe;
using Weaver.Core.Query;

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

			const int size = 10;

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

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void InsertFactors(IList<int> pIndexes, ParallelLoopState pState, long pThreadId) {
			IDataAccess acc = ApiCtx.NewData(null, true);
			acc.AddSessionStart();

			var newFactorCmds = new List<string>();

			foreach ( int i in pIndexes ) {
				FabBatchResult res = vResults[i];

				if ( res.Error != null ) {
					continue;
				}

				try {
					FactorOperationSet fos = vOpSets[i];
					fos.AddQueries(ApiCtx, acc);
					res.ResultId = fos.FactorId;
					newFactorCmds.Add(fos.NewFactorCmdId);
				}
				catch ( FabFault fault ) {
					res.Error = FabError.ForFault(fault);
				}
			}

			////

			try {
				acc.AddSessionCommit();
				acc.AddSessionClose();
				ExecuteRequest(acc, pIndexes, newFactorCmds);
			}
			catch ( Exception e ) {
				Log.Error("BatchCreateFactor batch exception: "+e);

				foreach ( int i in pIndexes ) {
					vResults[i].Error = FabError.ForInternalServerError();
				}
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ExecuteRequest(IDataAccess pAccess, IList<int> pIndexes, 
																		IList<string> pNewFactorCmds ) {
			IDataResult data = pAccess.Execute("Modify-BatchCreateFactor-Add");
			int cmdI = 0;

			foreach ( int i in pIndexes ) {
				int fi = data.GetCommandIndexByCmdId(pNewFactorCmds[cmdI++]);

				if ( data.ToMapAt(fi, 0) != null ) {
					continue;
				}

				var nf = new FabNotFoundFault(typeof(Artifact), "One or more of the specified "+
					typeof(Artifact).Name+"s could not be found.");
				vResults[i].Error = FabError.ForFault(nf);
			}
		}

	}
	

	/*================================================================================================*/
	public class FactorOperationSet {

		public long FactorId { get; private set; }
		public string NewFactorCmdId { get; private set; }
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
				var eve = new AttachEventor(pTasks, 0, vBatch.Eventor.TypeId, vBatch.Eventor.DateTime);
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
		public void AddQueries(IApiContext pApiCtx, IDataAccess pAccess) {
			ArtifactVar priArt = AddArtifactQuery(pAccess, "_PA", vBatch.PrimaryArtifactId);
			string condCmdId = priArt.CmdId;

			ArtifactVar relArt = AddArtifactQuery(pAccess, "_RA", vBatch.RelatedArtifactId);
			pAccess.AddConditionsToLatestCommand(condCmdId);
			condCmdId = relArt.CmdId;

			FabBatchNewFactorDescriptor desc = vBatch.Descriptor;
			ArtifactVar priRefArt = null;
			ArtifactVar relRefArt = null;
			ArtifactVar typeRefArt = null;
			ArtifactVar axisArt = null;

			if ( desc.PrimaryArtifactRefineId != null ) {
				priRefArt = AddArtifactQuery(pAccess, "_RPA", (long)desc.PrimaryArtifactRefineId);
				pAccess.AddConditionsToLatestCommand(condCmdId);
				condCmdId = priRefArt.CmdId;
			}

			if ( desc.RelatedArtifactRefineId != null ) {
				relRefArt = AddArtifactQuery(pAccess, "_RRA", (long)desc.RelatedArtifactRefineId);
				pAccess.AddConditionsToLatestCommand(condCmdId);
				condCmdId = relRefArt.CmdId;
			}

			if ( desc.TypeRefineId != null ) {
				typeRefArt = AddArtifactQuery(pAccess, "_RTA", (long)desc.TypeRefineId);
				pAccess.AddConditionsToLatestCommand(condCmdId);
				condCmdId = typeRefArt.CmdId;
			}

			if ( vBatch.Vector != null ) {
				axisArt = AddArtifactQuery(pAccess, "_AA", vBatch.Vector.AxisArtifactId);
				pAccess.AddConditionsToLatestCommand(condCmdId);
				condCmdId = axisArt.CmdId;
			}

			////

			FactorId = pApiCtx.GetSharpflakeId<Factor>();

			var f = new Factor();
			f.FactorId = FactorId;
			f.FactorAssertionId = vBatch.FactorAssertionId;
			f.IsDefining = vBatch.IsDefining;
			f.Note = vBatch.Note;
			f.Created = pApiCtx.UtcNow.Ticks;
			f.Completed = f.Created;

			f.Descriptor_TypeId = desc.TypeId;

			if ( vBatch.Director != null ) {
				f.Director_TypeId = vBatch.Director.TypeId;
				f.Director_PrimaryActionId = vBatch.Director.PrimaryActionId;
				f.Director_RelatedActionId = vBatch.Director.RelatedActionId;
			}

			if ( vBatch.Eventor != null ) {
				f.Eventor_TypeId = vBatch.Eventor.TypeId;
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

			var txb = new TxBuilder();
			var facBuild = new FactorBuilder(txb, f);
			facBuild.AddVertex();
			facBuild.SetInMemberCreates(vMember);
			 
			facBuild.TxBuild.RegisterVarWithTxBuilder(priArt.Alias);
			facBuild.SetUsesPrimaryArtifact(priArt.Alias);

			facBuild.TxBuild.RegisterVarWithTxBuilder(relArt.Alias);
			facBuild.SetUsesRelatedArtifact(relArt.Alias);
			
			if ( priRefArt != null ) {
				facBuild.TxBuild.RegisterVarWithTxBuilder(priRefArt.Alias);
				facBuild.SetDescriptorRefinesPrimaryWithArtifact(priRefArt.Alias);
			}

			if ( relRefArt != null ) {
				facBuild.TxBuild.RegisterVarWithTxBuilder(relRefArt.Alias);
				facBuild.SetDescriptorRefinesRelatedWithArtifact(relRefArt.Alias);
			}

			if ( typeRefArt != null ) {
				facBuild.TxBuild.RegisterVarWithTxBuilder(typeRefArt.Alias);
				facBuild.SetDescriptorRefinesTypeWithArtifact(typeRefArt.Alias);
			}

			if ( axisArt != null ) {
				facBuild.TxBuild.RegisterVarWithTxBuilder(axisArt.Alias);
				facBuild.SetVectorUsesAxisArtifact(axisArt.Alias);
			}

			////

			for ( int i = 0 ; i < txb.Scripts.Count ; ++i ) {
				IWeaverScript ws = txb.Scripts[i];

				var endQ = new WeaverQuery();
				endQ.FinalizeQuery(i == 0 ? "[id:"+facBuild.VertexVar.Name+".id]" : "1");

				var tx = new WeaverTransaction();
				tx.AddQuery((IWeaverQuery)ws);
				tx.AddQuery(endQ);
				tx.Finish();

				pAccess.AddQuery(tx, true);
				pAccess.AddConditionsToLatestCommand(condCmdId);

				if ( i == 0 ) {
					NewFactorCmdId = pAccess.GetLatestCommandId();
				}
				else {
					pAccess.OmitResultsOfLatestCommand();
					pAccess.RemoveCommandIdOfLatestCommand();
				}
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static ArtifactVar AddArtifactQuery(
											IDataAccess pAccess, string pVarName, long pArtifactId) {
			IWeaverVarAlias<Artifact> v;

			IWeaverQuery q1 = Weave.Inst.Graph
				.V.ExactIndex<Artifact>(x => x.ArtifactId, pArtifactId)
				.ToQuery();
			q1 = WeaverQuery.StoreResultAsVar(pVarName, q1, out v);

			IWeaverQuery q2 = Weave.Inst.FromVar(v).Next().ToQuery();
			q2 = WeaverQuery.StoreResultAsVar(pVarName, q2, out v);

			var q = new WeaverQuery();
			q.AddParam(q1.Params["_P0"]);
			q.FinalizeQuery(q1.Script+"if("+v.Name+"){"+q2.Script+"1;}else{0;}");
			pAccess.AddQuery(q, true);

			return new ArtifactVar { CmdId = pAccess.GetLatestCommandId(), Alias = v };
		}

	}
	

	/*================================================================================================*/
	public class ArtifactVar {

		public string CmdId { get; set; }
		public IWeaverVarAlias<Artifact> Alias { get; set; }

	}

}