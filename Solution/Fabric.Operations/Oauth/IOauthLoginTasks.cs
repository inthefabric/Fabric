using Fabric.New.Domain;
using Fabric.New.Operations.Create;

namespace Fabric.New.Operations.Oauth {

	/*================================================================================================*/
	public interface IOauthLoginTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		long AppIdToLong(string pAppId);

		/*--------------------------------------------------------------------------------------------*/
		void VerifyAppDomain(App pApp, string pRedirectUri);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		App GetApp(IOperationData pData, long pAppId);

		/*--------------------------------------------------------------------------------------------*/
		User GetUser(IOperationData pData, long pUserId);

		/*--------------------------------------------------------------------------------------------*/
		User GetUserByCredentials(IOperationData pData, string pUsername, string pPassword);

		/*--------------------------------------------------------------------------------------------*/
		Member GetMember(IOperationData pData, long pAppId, long pUserId);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		Member AddMember(IOperationContext pOpCtx, CreateMemberOperation pOper,
			long pAppId, long pUserId);

		/*--------------------------------------------------------------------------------------------*/
		void DenyScope(IOperationData pData, Member pMember);

		/*--------------------------------------------------------------------------------------------*/
		void UpdateGrant(IOperationContext pOpCtx, Member pMember, string pRedirectUri);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		OauthException NewFault(LoginErrors pErr, LoginErrorDescs pDesc);

	}

}