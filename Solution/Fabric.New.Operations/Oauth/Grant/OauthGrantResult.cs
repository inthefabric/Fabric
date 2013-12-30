using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Oauth.Grant {

	/*================================================================================================*/
	public class OauthGrantResult<T> where T : FabObject {

		public T Object { get; set; }
		public string Html { get; set; }
		public string RedirectUri { get; set; }

	}

}