using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class DoLogout : AddAccess {
		
		private readonly FabOauthAccess vAccess;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DoLogout(FabOauthAccess pAccess) : 
									base(pAccess.AppId, pAccess.UserId, 0, (pAccess.UserId == null)) {
			vAccess = pAccess;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabOauthAccess Execute() {
			ClearOldTokens();
			return vAccess;
		}

	}

}
