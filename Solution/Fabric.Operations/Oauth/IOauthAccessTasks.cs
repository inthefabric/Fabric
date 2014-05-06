using Fabric.Api.Objects.Oauth;
using Fabric.Domain;
using Fabric.Operations.Create;

namespace Fabric.Operations.Oauth {

	/*================================================================================================*/
	public interface IOauthAccessTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		App GetApp(IOperationData pData, long pAppId, string pClientSecret);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		OauthMember GetMemberByGrant(IOperationData pData, string pGrantCode);

		/*--------------------------------------------------------------------------------------------*/
		OauthMember GetMemberByRefresh(IOperationData pData, string pRefresh);

		/*--------------------------------------------------------------------------------------------*/
		Member GetDataProvMemberByApp(IOperationData pData, long pAppId);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		FabOauthAccess AddAccess(IOperationContext pOpCtx, CreateOauthAccessOperation pCreateOp,
			long pMemberId, bool pClientMode=false);
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		OauthException NewFault(AccessErrors pErr, AccessErrorDescs pDesc);

	}

}