using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Interfaces;
using Fabric.Api.Dto.Batch;
using System.Collections.Generic;
using ServiceStack.Text;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModClassesUri, typeof(IList<FabBatchResult>),
		Auth=ServiceAuthType.Member)]
	public class BatchCreateClass : BaseModifyFunc<IList<FabBatchResult>> {
		
		public const string ObjectsParam = "Objects";

		[ServiceOpParam(ServiceOpParamType.Form, ObjectsParam, 0, null)]
		private FabBatchNewClass[] vObjects;
		
		private readonly string vObjectsJson;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public BatchCreateClass(IModifyTasks pTasks, string pObjectsJson) : base(pTasks) {
			vObjectsJson = pObjectsJson;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			vObjects = JsonSerializer.DeserializeFromString<FabBatchNewClass[]>(vObjectsJson);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IList<FabBatchResult> Execute() {
			var results = new List<FabBatchResult>();
			int n = vObjects.Length;
			
			FabBatchNewClass nc = vObjects[0];
			var cc = new CreateClass(Tasks, nc.Name, nc.Disamb, nc.Note);
			TxBuilder txb = cc.
			
			for ( int i = 1 ; i < n ; ++i ) {
				nc = vObjects[i];
			}
			
			return results;
		}

	}

}