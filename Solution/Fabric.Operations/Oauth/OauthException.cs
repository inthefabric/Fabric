using System;
using Fabric.Api.Objects.Oauth;

namespace Fabric.Operations.Oauth {

	/*================================================================================================*/
	public class OauthException : Exception {

		public FabOauthError OauthError { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthException(string pName, string pDesc) : base(pName+" / "+pDesc) {
			OauthError = new FabOauthError();
			OauthError.Error = pName;
			OauthError.ErrorDesc = pDesc;
		}

	}

}