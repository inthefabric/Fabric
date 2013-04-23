using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Oauth.Results {
	
	/*================================================================================================*/
	public class ScopeResult {

		public long ScopeId { get; set; }
		public long AppId { get; set; }
		public long? UserId { get; set; }
		public bool Allow { get; set; }
		public DateTime Created { get; set; }
		public FabOauthLogin Login { get; set; }
		
	}

}