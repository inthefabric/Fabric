using System;
using System.Collections.Generic;
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
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModClassesBatchUri, typeof(FabBatchResult[]),
		Auth=ServiceAuthType.Member)]
	public class CreateClassBatch : BaseModifyFunc<FabBatchResult[]> { //TEST: BatchCreateClass
		
		public const string ClassesParam = "Classes";

		[ServiceOpParam(ServiceOpParamType.Form, ClassesParam, 0, typeof(Class))]
		private FabBatchNewClass[] vObjects;
		
		private readonly string vObjectsJson;
		private CreateClass[] vCreateFuncs;
		private FabBatchResult[] vResults;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateClassBatch(IModifyTasks pTasks, string pObjectsJson) : base(pTasks) {
			vObjectsJson = pObjectsJson;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vObjectsJson == null ) {
				throw new FabArgumentNullFault(ClassesParam);
			}

			try {
				vObjects = JsonSerializer.DeserializeFromString<FabBatchNewClass[]>(vObjectsJson);
			}
			catch ( Exception ) {
				throw new FabArgumentValueFault("Malformed "+ClassesParam+" JSON data.");
			}

			int n = vObjects.Length;

			if ( n == 0 ) {
				throw new FabArgumentValueFault("The "+ClassesParam+" batch list is empty.");
			}

			//TODO: BatchCreateClass max length bound (first, determine a reasonable maximum)

			////

			vCreateFuncs = new CreateClass[n];
			vResults = new FabBatchResult[n];
			var dupMap = new HashSet<string>();

			for ( int i = 0 ; i < n ; ++i ) {
				FabBatchNewClass nc = vObjects[i];
				
				var res = new FabBatchResult();
				res.BatchId = nc.BatchId;
				vResults[i] = res;
				
				try {
					if ( dupMap.Contains(nc.Name+"|"+nc.Disamb) ) {
						string name = nc.Name+(nc.Disamb == null ? "" : " ("+nc.Disamb+")");
						throw new FabDuplicateFault(typeof(Class), CreateClass.NameParam, name);
					}

					dupMap.Add(nc.Name+"|"+nc.Disamb);

					CreateClass cc = new CreateClass(Tasks, nc.Name, nc.Disamb, nc.Note);
					cc.ValidateParamsForBatch();
					vCreateFuncs[i] = cc;
				}
				catch ( FabFault fault ) {
					res.Error = FabError.ForFault(fault);
				}
				/*catch ( Exception ) {
					res.Error = FabError.ForInternalServerError();
				}*/
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabBatchResult[] Execute() {
			TxBuilder txb = BuildTx();

			if ( txb != null ) {
				IApiDataAccess data = ApiCtx.DbData("BatchCreateClassTx", txb.Finish());
				CacheClasses(data);
			}

			return vResults;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private TxBuilder BuildTx() {
			int n = vObjects.Length;
			TxBuilder txb = null;
			IWeaverVarAlias<Root> rootVar = null;
			IWeaverVarAlias<Member> memVar = null;
			IWeaverVarAlias<ArtifactType> artTypeVar = null;
			var nodeIds = new string[n];

			for ( int i = 0 ; i < n ; ++i ) {
				FabBatchResult res = vResults[i];
				nodeIds[i] = "0";

				if ( res.Error != null ) {
					continue;
				}

				try {
					CreateClass cc = vCreateFuncs[i];
					cc.SetApiCtxForBatch(ApiCtx);

					IWeaverVarAlias<Class> classVar;

					if ( txb == null ) {
						txb = cc.GetFullTx(out rootVar, out memVar, out artTypeVar, out classVar);
					}
					else {
						cc.FillBatchTx(txb, rootVar, memVar, artTypeVar, out classVar);
					}

					res.ResultId = cc.GetNewClassIdForBatch();
					nodeIds[i] = classVar.Name+".id";
				}
				catch ( FabFault fault ) {
					res.Error = FabError.ForFault(fault);
				}
				/*catch ( Exception ) {
					res.Error = FabError.ForInternalServerError();
				}*/
			}

			if ( txb != null ) {
				var q = new WeaverQuery();
				q.FinalizeQuery("["+string.Join(",", nodeIds)+"]");
				//txb.Transaction.AddQuery(q);
			}

			return txb;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CacheClasses(IApiDataAccess pData) {
			int n = vObjects.Length;
			//int count = 0;

			for ( int i = 0 ; i < n ; ++i ) {
				FabBatchResult res = vResults[i];

				if ( res.Error != null ) {
					continue;
				}

				FabBatchNewClass nc = vObjects[i];
				ApiCtx.AddToClassNameCache(res.ResultId, nc.Name, nc.Disamb);

				//c.Id = pData.GetLongResultAt(count);
				//++count;
			}
		}

	}

}