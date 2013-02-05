using System.Collections.Generic;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Dto.Spec;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabServices : FabDto {

		public const string Get = "GET";
		public const string Post = "POST";
		public const string Put = "PUT";
		public const string Delete = "DELETE";

		public const string OauthUri = "/Oauth";
		public const string OauthAccessTokenUri = "/AccessToken";
		public const string OauthAccessTokenAuthCodeUri = "/AccessTokenAuthCode";
		public const string OauthAccessTokenRefreshUri = "/AccessTokenRefresh";
		public const string OauthAccessTokenClientCredentialsUri = "/AccessTokenClientCredentials";
		public const string OauthAccessTokenClientDataProvUri = "/AccessTokenClientDataProv";
		public const string OauthLoginUri = "/Login";
		public const string OauthLogoutUri = "/Logout";

		public const string SpecUri = "/Spec";
		public const string SpecDocUri = "/Doc";

		public const string TravUri = "/Trav";
		public const string TravRootUri = "/Root";

		public IList<FabService> Services { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabServices() {
			const bool includeOps = false;

			Services = new List<FabService>();
			Services.Add(NewTraversalService(includeOps));
			Services.Add(NewOauthService(includeOps));
			Services.Add(NewSpecService(includeOps));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabService NewOauthService(bool pIncludeOps) {
			var s = new FabService();
			s.Name = "OAuthService";
			s.Uri = OauthUri;

			if ( pIncludeOps ) {
				var op = new FabServiceOperation();
				op.Name = "AccessToken";
				op.Uri = OauthAccessTokenUri;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthAccess).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AccessToken_AuthCode";
				op.Uri = OauthAccessTokenAuthCodeUri;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthAccess).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AccessToken_Refresh";
				op.Uri = OauthAccessTokenRefreshUri;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthAccess).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AccessToken_ClientCredentials";
				op.Uri = OauthAccessTokenClientCredentialsUri;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthAccess).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AccessToken_ClientDataProv";
				op.Uri = OauthAccessTokenClientDataProvUri;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthAccess).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "Login";
				op.Uri = OauthLoginUri;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthLogin).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "Logout";
				op.Uri = OauthLogoutUri;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthLogout).Name;
				s.Operations.Add(op);
			}
			else {
				s.Operations = null;
			}

			return s;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static FabService NewSpecService(bool pIncludeOps) {
			var s = new FabService();
			s.Name = "SpecService";
			s.Uri = SpecUri;

			if ( pIncludeOps ) {
				var op = new FabServiceOperation();
				op.Name = "Document";
				op.Uri = SpecDocUri;
				op.Method = Get;
				op.ReturnType = typeof(FabSpec).Name;
				s.Operations.Add(op);
			}
			else {
				s.Operations = null;
			}

			return s;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabService NewTraversalService(bool pIncludeOps) {
			var s = new FabService();
			s.Name = "TraversalService";
			s.Uri = TravUri;

			if ( pIncludeOps ) {
				var op = new FabServiceOperation();
				op.Name = "Root";
				op.Uri = TravRootUri;
				op.Method = Get;
				op.ReturnType = typeof(FabRoot).Name;
				s.Operations.Add(op);
			}
			else {
				s.Operations = null;
			}

			return s;
		}

	}

}