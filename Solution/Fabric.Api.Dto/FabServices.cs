using System.Collections.Generic;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Dto.Spec;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabServices : FabDto {

		private const string Get = "GET";
		private const string Post = "POST";
		private const string Put = "PUT";
		private const string Delete = "DELETE";

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
			s.Uri = "/Oauth";

			if ( pIncludeOps ) {
				var op = new FabServiceOperation();
				op.Name = "AccessToken";
				op.Uri = "/"+op.Name;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthAccess).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AccessTokenAuthCode";
				op.Uri = "/"+op.Name;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthAccess).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AccessTokenRefresh";
				op.Uri = "/"+op.Name;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthAccess).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AccessTokenClientCredentials";
				op.Uri = "/"+op.Name;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthAccess).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AccessTokenClientDataProv";
				op.Uri = "/"+op.Name;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthAccess).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "Login";
				op.Uri = "/"+op.Name;
				op.Method = Get;
				op.ReturnType = typeof(FabOauthLogin).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "Logout";
				op.Uri = "/"+op.Name;
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
			s.Uri = "/Spec";

			if ( pIncludeOps ) {
				var op = new FabServiceOperation();
				op.Name = "FullSpecDoc";
				op.Uri = "/Full";
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
			s.Uri = "/Traversal";

			if ( pIncludeOps ) {
				var op = new FabServiceOperation();
				op.Name = "Root";
				op.Uri = "/Root";
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