using Fabric.New.Domain;

namespace Fabric.New.Operations.Oauth {

	/*================================================================================================*/
	public interface IOauthLogoutTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		OauthAccess GetAccessToken(IOperationData pData, string pToken);

		/*--------------------------------------------------------------------------------------------*/
		void DoLogout(IOperationData pData, OauthAccess pAccess);

	}

}