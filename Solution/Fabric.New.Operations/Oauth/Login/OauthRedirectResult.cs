using System.Collections.Generic;

namespace Fabric.New.Operations.Oauth.Login {

	/*================================================================================================*/
	public class OauthRedirectResult {

		public string Uri { get; set; }
		public IDictionary<string, string> Params { get; set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthRedirectResult(string pUri) {
			Uri = pUri;
			Params = new Dictionary<string, string>();
		}

	}

}