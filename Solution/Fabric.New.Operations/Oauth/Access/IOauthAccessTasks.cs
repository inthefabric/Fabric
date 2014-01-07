using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;

namespace Fabric.New.Operations.Oauth.Access {

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
		FabOauthAccess AddAccess(IOperationContext pOpCtx, Member pMember, bool pClientMode=false);
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		OauthException NewFault(AccessErrors pErr, AccessErrorDescs pDesc);

	}

}