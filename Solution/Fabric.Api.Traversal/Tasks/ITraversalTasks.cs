using Fabric.Infrastructure.Api;
using Fabric.Api.Dto.Traversal;

namespace Fabric.Api.Traversal.Tasks {

	/*================================================================================================*/
	public interface ITraversalTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		FabUser GetUserByContext(IApiContext pApiCtx);
		
		/*--------------------------------------------------------------------------------------------*/
		FabApp GetAppByContext(IApiContext pApiCtx);
		
		/*--------------------------------------------------------------------------------------------*/
		FabMember GetMemberByContext(IApiContext pApiCtx);
		
	}

}