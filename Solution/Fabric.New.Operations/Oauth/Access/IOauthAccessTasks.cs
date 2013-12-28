using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;

namespace Fabric.New.Operations.Oauth.Access {

	/*================================================================================================*/
	public interface IOauthAccessTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		App GetApp(IOperationContext pOpCtx, long pAppId, string pClientSecret);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		OauthMember GetMemberByGrant(IOperationContext pOpCtx, string pGrantCode);

		/*--------------------------------------------------------------------------------------------*/
		OauthMember GetMemberByRefresh(IOperationContext pOpCtx, string pGrantCode);

		/*--------------------------------------------------------------------------------------------*/
		Member GetMemberByApp(IOperationContext pOpCtx, long pAppId);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		FabOauthAccess AddAccess(IOperationContext pOpCtx, Member pMember, bool pClientMode=false);
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		OauthException NewFault(AccessErrors pErr, AccessErrorDescs pDesc);

	}

}