using System;
using Fabric.New.Api.Objects.Oauth;

namespace Fabric.New.Operations.Oauth {

	/*================================================================================================*/
	public class OauthAccessOperation {

		private IOperationContext vOpCtx;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthAccess Execute(IOperationContext pOpCtx, string pGrantType, string pClientId,
				string pSecret, string pLogin, string pRefresh, string pRedirUri, string pDataProvId) {
			vOpCtx = pOpCtx;
			throw new NotImplementedException();
		}
	}

}