using System;
using System.Collections.Generic;
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
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModClassesBatchUri, typeof(FabBatchResult),
		Auth=ServiceAuthType.Member)]
	public class BatchCreateClass : BaseModifyFunc<FabBatchResult[]> { //TEST: BatchCreateClass
		
		public const string ClassesParam = "Classes";

		[ServiceOpParam(ServiceOpParamType.Form, ClassesParam, 0, typeof(Class))]
		private FabBatchNewClass[] vObjects;
		
		private readonly string vObjectsJson;
		private List<List<int>> vIndexes;
		private CreateClass[] vCreateFuncs;
		private FabBatchResult[] vResults;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public BatchCreateClass(IModifyTasks pTasks, string pObjectsJson) : base(pTasks) {
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

			var currIndexGroup = new List<int>();
			vIndexes = new List<List<int>>();
			vIndexes.Add(currIndexGroup);

			vCreateFuncs = new CreateClass[n];
			vResults = new FabBatchResult[n];

			var dupMap = new HashSet<string>();
			const int size = 100;

			for ( int i = 0 ; i < n ; ++i ) {
				FabBatchNewClass nc = vObjects[i];
				
				var res = new FabBatchResult();
				res.BatchId = nc.BatchId;
				vResults[i] = res;

				if ( currIndexGroup.Count == size ) {
					currIndexGroup = new List<int>();
					vIndexes.Add(currIndexGroup);
				}
				
				try {
					string key = GetMapKey(nc.Name, nc.Disamb);

					if ( dupMap.Contains(key) ) {
						string name = nc.Name+(nc.Disamb == null ? "" : " ("+nc.Disamb+")");
						throw new FabDuplicateFault(typeof(Class), CreateClass.NameParam, name);
					}

					var cc = new CreateClass(Tasks, nc.Name, nc.Disamb, nc.Note);
					cc.ValidateParamsForBatch();

					vCreateFuncs[i] = cc;
					dupMap.Add(key);
					currIndexGroup.Add(i);
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
			GetContextMember();

			var opt = new ParallelOptions();
			opt.MaxDegreeOfParallelism = 3; //TODO: use DB node count
			Parallel.ForEach(vIndexes, opt, InsertClass);

			return vResults;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void InsertClass(List<int> pIndexes, ParallelLoopState pState, long pThreadId) {
			int n = pIndexes.Count;
			var classes = new List<Class>();
			var txList = new List<IWeaverScript>();

			for ( int i = 0 ; i < n ; ++i ) {
				int index = pIndexes[i];
				FabBatchResult res = vResults[index];

				try {
					CreateClass cc = vCreateFuncs[index];
					IWeaverVarAlias<Class> classVar;
					IWeaverVarAlias<Member> memVar;

					TxBuilder txb = cc.GetFullTxForBatch(ApiCtx, out memVar, out classVar);

					txb.Transaction.AddQuery(
						NewPathFromVar(classVar, false).Prop(x => x.Id).End()
					);

					txList.Add(txb.Finish());

					Class c = cc.GetNewClassForBatch();
					res.ResultId = c.ArtifactId;
					classes.Add(c);

					ApiCtx.Cache.Memory.AddExists<Artifact>(c.ArtifactId);
				}
				catch ( FabFault fault ) {
					res.Error = FabError.ForFault(fault);
				}
			}

			////

			if ( classes.Count == 0 ) {
				return;
			}

			try {
				ApiCtx.DbData("BatchCreateClassTx", txList);
			}
			catch ( Exception e ) {
				Log.Error("BatchCreateClass batch exception: "+e);

				foreach ( int i in pIndexes ) {
					vResults[i].Error = FabError.ForInternalServerError();
				}
			}
		}

	}

}