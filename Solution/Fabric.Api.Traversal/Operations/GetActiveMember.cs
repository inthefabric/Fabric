using Fabric.Api.Dto;
using Fabric.Api.Traversal.Tasks;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Traversal.Operations {

	/*================================================================================================*/
	[ServiceOp(FabHome.TravUri, FabHome.Get, FabHome.TravMemberUri, typeof(FabMember))]
	public class GetActiveMember : ApiFunc<FabMember> { //TEST: GetActiveMember
		
		private ITraversalTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetActiveMember(ITraversalTasks pTasks) {
			vTasks = pTasks;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabMember Execute() {
			return vTasks.GetMemberByContext(ApiCtx);
		}

	}

}