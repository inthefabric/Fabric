using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Batch;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using ServiceStack.Text;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModClassesBatchUri, typeof(FabBatchResult),
		Auth=ServiceAuthType.Member)]
	public class CreateClassBatch : BaseModifyFunc<FabBatchResult[]> { //TEST: BatchCreateClass
		
		public const string ClassesParam = "Classes";

		[ServiceOpParam(ServiceOpParamType.Form, ClassesParam, 0, typeof(Class))]
		private FabBatchNewClass[] vObjects;
		
		private readonly string vObjectsJson;
		private int[] vIndexes;
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

			vIndexes = new int[n];
			vCreateFuncs = new CreateClass[n];
			vResults = new FabBatchResult[n];
			var dupMap = new HashSet<string>();

			for ( int i = 0 ; i < n ; ++i ) {
				FabBatchNewClass nc = vObjects[i];
				
				var res = new FabBatchResult();
				res.BatchId = nc.BatchId;
				vResults[i] = res;
				vIndexes[i] = i;
				
				try {
					string key = GetMapKey(nc.Name, nc.Disamb);

					if ( dupMap.Contains(key) ) {
						string name = nc.Name+(nc.Disamb == null ? "" : " ("+nc.Disamb+")");
						throw new FabDuplicateFault(typeof(Class), CreateClass.NameParam, name);
					}

					dupMap.Add(key);

					CreateClass cc = new CreateClass(Tasks, nc.Name, nc.Disamb, nc.Note);
					cc.ValidateParamsForBatch();
					vCreateFuncs[i] = cc;
				}
				catch ( FabFault fault ) {
					res.Error = FabError.ForFault(fault);
				}
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string GetMapKey(string pName, string pDisamb) {
			return pName+(pDisamb == null ? "" : "`|`"+pDisamb);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabBatchResult[] Execute() {
			var opt = new ParallelOptions();
			opt.MaxDegreeOfParallelism = 20;
			Parallel.ForEach(vIndexes, opt, InsertClass);
			return vResults;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void InsertClass(int pIndex, ParallelLoopState pState, long pThreadId) {
			FabBatchResult res = vResults[pIndex];

			if ( res.Error != null ) {
				return;
			}

			try {
				Class c = vCreateFuncs[pIndex].ExecuteForBatch(ApiCtx);
				res.ResultId = c.ClassId;
			}
			catch ( FabFault fault ) {
				res.Error = FabError.ForFault(fault);
			}
		}

	}

}