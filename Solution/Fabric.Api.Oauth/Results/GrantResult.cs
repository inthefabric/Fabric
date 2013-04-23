namespace Fabric.Api.Oauth.Results {
	
	/*================================================================================================*/
	public class GrantResult {

		public long GrantId { get; set; }
		public long AppId { get; set; }
		public long? UserId { get; set; }
		public string Code { get; set; }
		public string RedirectUri { get; set; }

	}

}
