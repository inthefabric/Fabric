using Fabric.Api.Dto;
using Fabric.Api.Traversal.Tasks;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Traversal.Operations {

	/*================================================================================================*/
	[ServiceOp(FabHome.TravUri, FabHome.Get, FabHome.TravUserUri, typeof(FabUser))]
	public class GetActiveUser : ApiFunc<FabUser> { //TEST: GetActiveUser
		
		private ITraversalTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetActiveUser(ITraversalTasks pTasks) {
			vTasks = pTasks;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabUser Execute() {
			return vTasks.GetUserByContext(ApiCtx);
		}

	}

}