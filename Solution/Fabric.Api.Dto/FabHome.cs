using System.Collections.Generic;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Dto.Spec;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabHome : FabObject {

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

		public const string ModUri = "/Mod";
		public const string ModAppsUri = "/Apps";
		public const string ModClassesUri = "/Classes";
		public const string ModDescriptorsUri = "/Descriptors";
		public const string ModDirectorsUri = "/Directors";
		public const string ModEventorsUri = "/Eventors";
		public const string ModFactorsUri = "/Factors";
		public const string ModIdentorsUri = "/Identors";
		public const string ModInstancesUri = "/Instances";
		public const string ModLocatorsUri = "/Locators";
		public const string ModUrlsUri = "/Urls";
		public const string ModUsersUri = "/Users";
		public const string ModVectorsUri = "/Vectors";

		public IList<FabService> Services { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabHome() : this(false) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabHome(bool pIncludeOps) {
			Services = new List<FabService>();
			Services.Add(NewTraversalService(pIncludeOps));
			Services.Add(NewOauthService(pIncludeOps));
			Services.Add(NewModifyService(pIncludeOps));
			Services.Add(NewSpecService(pIncludeOps));
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabService NewOauthService(bool pIncludeOps) {
			var s = new FabService();
			s.Name = "Oauth";
			s.Uri = OauthUri;

			if ( pIncludeOps ) {
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
			}
			else {
				s.Operations = null;
			}

			return s;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static FabService NewSpecService(bool pIncludeOps) {
			var s = new FabService();
			s.Name = "Spec";
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
			s.Name = "Traversal";
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

		/*--------------------------------------------------------------------------------------------*/
		public static FabService NewModifyService(bool pIncludeOps) {
			var s = new FabService();
			s.Name = "Modify";
			s.Uri = ModUri;

			if ( pIncludeOps ) {
				var op = new FabServiceOperation();
				op.Name = "AddApp";
				op.Uri = ModAppsUri;
				op.Method = Post;
				op.ReturnType = typeof(FabApp).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AddClass";
				op.Uri = ModClassesUri;
				op.Method = Post;
				op.ReturnType = typeof(FabClass).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AttachDescriptorToFactor";
				op.Uri = ModDescriptorsUri;
				op.Method = Post;
				op.ReturnType = typeof(FabDescriptor).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AttachDirectorToFactor";
				op.Uri = ModDirectorsUri;
				op.Method = Post;
				op.ReturnType = typeof(FabDirector).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AttachEventorToFactor";
				op.Uri = ModEventorsUri;
				op.Method = Post;
				op.ReturnType = typeof(FabEventor).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AddFactor";
				op.Uri = ModFactorsUri;
				op.Method = Post;
				op.ReturnType = typeof(FabFactor).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "CompleteFactor";
				op.Uri = ModFactorsUri;
				op.Method = Put;
				op.ReturnType = typeof(FabFactor).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "DeleteFactor";
				op.Uri = ModFactorsUri;
				op.Method = Delete;
				op.ReturnType = typeof(FabFactor).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AttachIdentorToFactor";
				op.Uri = ModIdentorsUri;
				op.Method = Post;
				op.ReturnType = typeof(FabIdentor).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AddInstance";
				op.Uri = ModInstancesUri;
				op.Method = Post;
				op.ReturnType = typeof(FabInstance).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AttachLocatorToFactor";
				op.Uri = ModLocatorsUri;
				op.Method = Post;
				op.ReturnType = typeof(FabLocator).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AddUrl";
				op.Uri = ModUrlsUri;
				op.Method = Post;
				op.ReturnType = typeof(FabUrl).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AddUser";
				op.Uri = ModUsersUri;
				op.Method = Post;
				op.ReturnType = typeof(FabUser).Name;
				s.Operations.Add(op);

				op = new FabServiceOperation();
				op.Name = "AttachVectorToFactor";
				op.Uri = ModVectorsUri;
				op.Method = Post;
				op.ReturnType = typeof(FabVector).Name;
				s.Operations.Add(op);
			}
			else {
				s.Operations = null;
			}

			return s;
		}

	}

}