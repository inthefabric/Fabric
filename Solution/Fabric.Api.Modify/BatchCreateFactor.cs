using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Batch;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
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
		private List<int> vVerifyIndexes;
		private List<int> vIndexes;


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

			vOpSets = new FactorOperationSet[n];
			vResults = new FabBatchResult[n];
			vVerifyIndexes = new List<int>();

			for ( int i = 0 ; i < n ; ++i ) {
				FabBatchNewFactor nf = vObjects[i];
				
				var res = new FabBatchResult();
				res.BatchId = nf.BatchId;
				vResults[i] = res;
				
				try {
					var fos = new FactorOperationSet(Tasks, nf);
					fos.ValidateParamsForBatch();
					vOpSets[i] = fos;
					vVerifyIndexes.Add(i);
				}
				catch ( FabFault fault ) {
					res.Error = FabError.ForFault(fault);
				}
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabBatchResult[] Execute() {
			Member mem = GetContextMember();

			var opt = new ParallelOptions();
			opt.MaxDegreeOfParallelism = 20;
			Parallel.ForEach(vVerifyIndexes, opt, VerifyRequiredNodes);

			////
			
			vIndexes = new List<int>();
			int n = vObjects.Length;

			for ( int i = 0 ; i < n ; ++i ) {
				if ( vResults[i].Error != null ) {
					continue;
				}

				vOpSets[i].SetCreator(mem);
				vIndexes.Add(i);
			}

			Parallel.ForEach(vIndexes, opt, InsertFactors);
			return vResults;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void VerifyRequiredNodes(int pIndex, ParallelLoopState pState, long pThreadId) {
			try {
				FactorOperationSet fos = vOpSets[pIndex];
				fos.VerifyRequiredNodesForBatch(ApiCtx);
			}
			catch ( FabFault fault ) {
				FabBatchResult res = vResults[pIndex];
				res.Error = FabError.ForFault(fault);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void InsertFactors(int pIndex, ParallelLoopState pState, long pThreadId) {
			FabBatchResult res = vResults[pIndex];

			try {
				FactorOperationSet fos = vOpSets[pIndex];
				ApiCtx.DbData("BatchCreateFactorNodeTx", fos.GetNodeTx(ApiCtx));
				res.ResultId = fos.FactorId;
				//Log.Debug("NodeId: "+data.GetStringResultAt(0));
			}
			catch ( FabFault fault ) {
				res.Error = FabError.ForFault(fault);
			}
		}

	}
	

	/*================================================================================================*/
	public class FactorOperationSet {

		public long FactorId { get; private set; }

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
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ValidateParamsForBatch() {
			vCreate.ValidateParamsForBatch();

			foreach ( AttachFactorElement afe in vElems ) {
				afe.ValidateParamsForBatch();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VerifyRequiredNodesForBatch(IApiContext pApiCtx) {
			vCreate.VerifyRequiredNodesForBatch(pApiCtx);

			foreach ( AttachFactorElement afe in vElems ) {
				afe.VerifyRequiredNodesForBatch(pApiCtx);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetCreator(Member pMember) {
			vMember = pMember;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IWeaverTransaction GetNodeTx(IApiContext pApiCtx) {
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

			//OPTIMIZE: Inserting Factor data this way isn't ideal, because it leads to different 
			//Gremlin scripts almost every time. The database has to compile any script which is not
			//cached, leading to long wait times until the most common insertion scripts are cached.
			//Could possibly split up these commands, however, they would lose their "transaction"
			//grouping, which is not preferable. The API would need to manually delete elements if
			//later portions of the "transaction" group fail.

			var txb = new TxBuilder();
			var facBuild = new FactorBuilder(txb, f);
			facBuild.AddNode();
			facBuild.SetUsesPrimaryArtifact(vBatch.PrimaryArtifactId);
			facBuild.SetUsesRelatedArtifact(vBatch.RelatedArtifactId);
			facBuild.SetInMemberCreates(vMember);

			if ( vBatch.Descriptor.PrimaryArtifactRefineId != null ) {
				facBuild.SetDescriptorRefinesPrimaryWithArtifact((
					long)vBatch.Descriptor.PrimaryArtifactRefineId);
			}

			if ( vBatch.Descriptor.RelatedArtifactRefineId != null ) {
				facBuild.SetDescriptorRefinesRelatedWithArtifact(
					(long)vBatch.Descriptor.RelatedArtifactRefineId);
			}

			if ( vBatch.Descriptor.TypeRefineId != null ) {
				facBuild.SetDescriptorRefinesTypeWithArtifact(
					(long)vBatch.Descriptor.TypeRefineId);
			}

			if ( vBatch.Vector != null ) {
				facBuild.SetVectorUsesAxisArtifact(vBatch.Vector.AxisArtifactId);
			}

			txb.Transaction.AddQuery(
				ApiFunc.NewPathFromVar(facBuild.NodeVar, false).Prop(x => x.Id).End()
			);

			return txb.Finish();
		}

	}

}