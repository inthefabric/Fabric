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
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModClassesBatchUri, typeof(FabBatchResult),
		Auth=ServiceAuthType.Member)]
	public class BatchCreateFactor : BaseModifyFunc<FabBatchResult[]> { //TEST: BatchCreateFactor
		
		public const string ClassesParam = "Classes";

		[ServiceOpParam(ServiceOpParamType.Form, ClassesParam, 0, typeof(Class))]
		private FabBatchNewFactor[] vObjects;
		
		private readonly string vObjectsJson;
		private FactorOperationSet[] vOpSets;
		private FabBatchResult[] vResults;
		private int[] vVerifyIndexes;
		private List<List<int>> vIndexes;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public BatchCreateFactor(IModifyTasks pTasks, string pObjectsJson) : base(pTasks) {
			vObjectsJson = pObjectsJson;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vObjectsJson == null ) {
				throw new FabArgumentNullFault(ClassesParam);
			}

			try {
				vObjects = JsonSerializer.DeserializeFromString<FabBatchNewFactor[]>(vObjectsJson);
			}
			catch ( Exception ) {
				throw new FabArgumentValueFault("Malformed "+ClassesParam+" JSON data.");
			}

			int n = vObjects.Length;

			if ( n == 0 ) {
				throw new FabArgumentValueFault("The "+ClassesParam+" batch list is empty.");
			}

			//TODO: BatchCreateFactor max length bound (first, determine a reasonable maximum)

			////

			vOpSets = new FactorOperationSet[n];
			vResults = new FabBatchResult[n];
			vVerifyIndexes = new int[n];

			for ( int i = 0 ; i < n ; ++i ) {
				vVerifyIndexes[i] = i;
				FabBatchNewFactor nf = vObjects[i];
				
				var res = new FabBatchResult();
				res.BatchId = nf.BatchId;
				vResults[i] = res;
				
				try {
					var fos = new FactorOperationSet(Tasks, nf);
					fos.ValidateParamsForBatch();
					vOpSets[i] = fos;
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
			opt.MaxDegreeOfParallelism = 10;
			Parallel.ForEach(vVerifyIndexes, opt, VerifyRequiredNodes);

			////
			
			var currIndexGroup = new List<int>();
			vIndexes = new List<List<int>>();
			vIndexes.Add(currIndexGroup);

			int n = vObjects.Length;
			const int size = 10;

			for ( int i = 0 ; i < n ; ++i ) {
				if ( vResults[i].Error != null ) {
					continue;
				}

				if ( currIndexGroup.Count == size ) {
					currIndexGroup = new List<int>();
					vIndexes.Add(currIndexGroup);
				}

				vOpSets[i].SetCreator(mem);
				currIndexGroup.Add(i);
			}

			////

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
		private void InsertFactors(List<int> pIndexes, ParallelLoopState pState, long pThreadId) {
			int n = pIndexes.Count;
			var txb = new TxBuilder();
			var relTxbList = new List<TxBuilder>();

			for ( int i = 0 ; i < n ; ++i ) {
				int index = pIndexes[i];
				FabBatchResult res = vResults[index];

				try {
					FactorOperationSet fos = vOpSets[index];
					fos.GetNodeQuery(ApiCtx, txb);
					relTxbList.Add(fos.GetRelTx());
					res.ResultId = fos.FactorId;
				}
				catch ( FabFault fault ) {
					res.Error = FabError.ForFault(fault);
				}
			}

			ApiCtx.DbData("BatchCreateFactorNodesTx", txb.Finish());

			foreach ( TxBuilder relTxb in relTxbList ) {
				if ( relTxb == null ) {
					continue;
				}

				ApiCtx.DbData("BatchCreateFactorRelsTx", relTxb.Transaction);
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
		public void GetNodeQuery(IApiContext pApiCtx, TxBuilder pTxBuilder) {
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

			var facBuild = new FactorBuilder(pTxBuilder, f);
			facBuild.AddNode();
			facBuild.SetUsesPrimaryArtifact(vBatch.PrimaryArtifactId);
			facBuild.SetUsesRelatedArtifact(vBatch.RelatedArtifactId);
			facBuild.SetInMemberCreates(vMember);
		}

		/*--------------------------------------------------------------------------------------------*/
		public TxBuilder GetRelTx() {
			var txb = new TxBuilder();
			bool found = false;

			IWeaverVarAlias<Factor> facVar;
			txb.GetNode(new Factor { FactorId = FactorId }, out facVar);

			var facBuild = new FactorBuilder(txb);
			facBuild.SetNodeVar(facVar);

			if ( vBatch.Descriptor.PrimaryArtifactRefineId != null ) {
				facBuild.SetDescriptorRefinesPrimaryWithArtifact((
					long)vBatch.Descriptor.PrimaryArtifactRefineId);
				found = true;
			}

			if ( vBatch.Descriptor.RelatedArtifactRefineId != null ) {
				facBuild.SetDescriptorRefinesRelatedWithArtifact(
					(long)vBatch.Descriptor.RelatedArtifactRefineId);
				found = true;
			}

			if ( vBatch.Descriptor.TypeRefineId != null ) {
				facBuild.SetDescriptorRefinesTypeWithArtifact(
					(long)vBatch.Descriptor.TypeRefineId);
				found = true;
			}

			if ( vBatch.Vector != null ) {
				facBuild.SetVectorUsesAxisArtifact(vBatch.Vector.AxisArtifactId);
				found = true;
			}

			if ( !found ) {
				return null;
			}

			txb.Finish();
			return txb;
		}

	}

}