using Fabric.Api.Dto;
using Fabric.Api.Traversal.Tasks;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Traversal.Operations {

	/*================================================================================================*/
	[ServiceOp(FabHome.TravUri, FabHome.Get, FabHome.TravAppUri, typeof(FabApp))]
	public class GetActiveApp : ApiFunc<FabApp> { //TEST: GetActiveApp
		
		private ITraversalTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetActiveApp(ITraversalTasks pTasks) {
			vTasks = pTasks;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabApp Execute() {
			return vTasks.GetAppByContext(ApiCtx);
		}

	}

}