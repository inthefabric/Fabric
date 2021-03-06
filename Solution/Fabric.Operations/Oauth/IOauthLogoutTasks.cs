﻿using Fabric.Domain;

namespace Fabric.Operations.Oauth {

	/*================================================================================================*/
	public interface IOauthLogoutTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		OauthAccess GetAccessToken(IOperationData pData, string pToken);

		/*--------------------------------------------------------------------------------------------*/
		void DoLogout(IOperationContext pOpCtx, OauthAccess pAccess);

	}

}