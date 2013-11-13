using System.Collections.Generic;
using Fabric.New.Api.Objects.Meta;
using Fabric.New.Api.Objects.Oauth;

namespace Fabric.New.Api.Objects.Menu {

	/*================================================================================================*/
	public class FabHome : FabObject {

		public const string Get = "GET";

		public const string HomeUri = "/";

		public const string OauthUri = "/Oauth";
		public const string OauthAccessTokenUri = "/AccessToken";
		public const string OauthAccessTokenAuthCodeUri = "/AccessTokenAuthCode";
		public const string OauthAccessTokenRefreshUri = "/AccessTokenRefresh";
		public const string OauthAccessTokenClientCredentialsUri = "/AccessTokenClientCredentials";
		public const string OauthAccessTokenClientDataProvUri = "/AccessTokenClientDataProv";
		public const string OauthLoginUri = "/Login";
		public const string OauthLogoutUri = "/Logout";

		public const string TravUri = "/Trav";

		public const string ModUri = "/Mod";

		public const string MetaUri = "/Meta";
		public const string MetaSpecUri = "/Spec";
		public const string MetaVersionUri = "/Version";
		public const string MetaTimeUri = "/Time";

		public readonly static FabService MetaService = BuildMetaService();
		public readonly static FabService ModService = BuildModService();
		public readonly static FabService OauthService = BuildOauthService();
		public readonly static FabService TravService = BuildTravService();
		public readonly static FabHome Home = new FabHome();

		public string Name { get; private set; }
		public IList<FabService> Services { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private FabHome() {
			Name = "Fabric API";

			Services = new List<FabService> {
				BuildMetaService(),
				BuildModService(),
				BuildOauthService(),
				BuildTravService(),
			};

			foreach ( FabService s in Services ) {
				s.Operations = null;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static FabService BuildMetaService() {
			var s = new FabService();
			s.Name = "Meta";
			s.Uri = MetaUri;

			var op = new FabServiceOperation();
			op.Name = "GetSpecification";
			op.Uri = MetaSpecUri;
			op.Method = Get;
			op.ReturnType = typeof(FabSpec).Name;
			s.Operations.Add(op);

			op = new FabServiceOperation();
			op.Name = "GetVersion";
			op.Uri = MetaVersionUri;
			op.Method = Get;
			op.ReturnType = typeof(FabMetaVersion).Name;
			s.Operations.Add(op);

			op = new FabServiceOperation();
			op.Name = "GetTime";
			op.Uri = MetaTimeUri;
			op.Method = Get;
			op.ReturnType = typeof(FabMetaTime).Name;
			s.Operations.Add(op);

			return s;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabService BuildModService() {
			var s = new FabService();
			s.Name = "Modify";
			s.Uri = ModUri;
			return s;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static FabService BuildOauthService() {
			var s = new FabService();
			s.Name = "Oauth";
			s.Uri = OauthUri;

			var op = new FabServiceOperation();
			op.Name = "AccessToken";
			op.Uri = OauthAccessTokenUri;
			op.Method = Get;
			op.ReturnType = typeof(FabOauthAccess).Name;
			s.Operations.Add(op);

			op = new FabServiceOperation();
			op.Name = "AccessTokenAuthCode";
			op.Uri = OauthAccessTokenAuthCodeUri;
			op.Method = Get;
			op.ReturnType = typeof(FabOauthAccess).Name;
			s.Operations.Add(op);

			op = new FabServiceOperation();
			op.Name = "AccessTokenRefresh";
			op.Uri = OauthAccessTokenRefreshUri;
			op.Method = Get;
			op.ReturnType = typeof(FabOauthAccess).Name;
			s.Operations.Add(op);

			op = new FabServiceOperation();
			op.Name = "AccessTokenClientCredentials";
			op.Uri = OauthAccessTokenClientCredentialsUri;
			op.Method = Get;
			op.ReturnType = typeof(FabOauthAccess).Name;
			s.Operations.Add(op);

			op = new FabServiceOperation();
			op.Name = "AccessTokenClientDataProv";
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

			return s;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabService BuildTravService() {
			var s = new FabService();
			s.Name = "Traversal";
			s.Uri = TravUri;
			return s;
		}

	}

}