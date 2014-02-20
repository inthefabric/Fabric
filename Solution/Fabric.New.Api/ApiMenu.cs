using System;
using Fabric.New.Api.Executors;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Menu;
using Fabric.New.Api.Objects.Meta;
using Fabric.New.Api.Objects.Oauth;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public static class ApiMenu {

		public readonly static FabService Meta = BuildMetaMenu();
		public readonly static FabService Mod = BuildModMenu();
		public readonly static FabService Oauth = BuildOauthMenu();
		public readonly static FabService Trav = BuildTravMenu();

		public static FabServiceOperation MetaSpec;
		public static FabServiceOperation MetaVersion;
		public static FabServiceOperation MetaTime;

		public static FabServiceOperation OauthAt;
		public static FabServiceOperation OauthAtac;
		public static FabServiceOperation OauthAtr;
		public static FabServiceOperation OauthAtcc;
		public static FabServiceOperation OauthLogin;
		public static FabServiceOperation OauthLogout;

		public readonly static FabHome Home = BuildHomeMenu();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static FabHome BuildHomeMenu() {
			var h = new FabHome();
			h.Uri = "/";
			h.Services.Add(BuildMetaMenu());
			h.Services.Add(BuildModMenu());
			h.Services.Add(BuildOauthMenu());
			h.Services.Add(BuildTravMenu());

			foreach ( FabService s in h.Services ) {
				s.Operations = null;
			}

			return h;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static FabService BuildMetaMenu() {
			var s = new FabService();
			s.Name = "Meta";
			s.Uri = "/Meta";

			if ( MetaSpec == null ) {
				MetaSpec = NewOperation<FabResponse<FabSpec>>("Spec");
				MetaVersion = NewOperation<FabResponse<FabMetaVersion>>("Version");
				MetaTime = NewOperation<FabResponse<FabMetaTime>>("Time");
			}

			s.Operations.Add(MetaSpec);
			s.Operations.Add(MetaVersion);
			s.Operations.Add(MetaTime);

			return s;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabService BuildModMenu() {
			var s = new FabService();
			s.Name = "Modify";
			s.Uri = "/Mod";

			foreach ( ApiEntry e in CreateExecutors.ApiEntries ) {
				string name = e.Path.Replace(s.Uri+"/", "");
				var op = NewOperation(name, e.ResponseType, e.RequestMethod);
				s.Operations.Add(op);
			}

			return s;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabService BuildOauthMenu() {
			var s = new FabService();
			s.Name = "OAuth";
			s.Uri = "/Oauth";

			if ( OauthAt == null ) {
				OauthAt = NewOperation<FabOauthAccess>("AccessToken");
				OauthAtac = NewOperation<FabOauthAccess>("AccessTokenAuthCode");
				OauthAtr = NewOperation<FabOauthAccess>("AccessTokenRefresh");
				OauthAtcc = NewOperation<FabOauthAccess>("AccessTokenClientCredentials");
				OauthLogin = NewOperation<FabOauthLogin>("Login");
				OauthLogout = NewOperation<FabOauthLogout>("Logout");
			}

			s.Operations.Add(OauthAt);
			s.Operations.Add(OauthAtac);
			s.Operations.Add(OauthAtr);
			s.Operations.Add(OauthAtcc);
			s.Operations.Add(OauthLogin);
			s.Operations.Add(OauthLogout);

			return s;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabService BuildTravMenu() {
			var s = new FabService();
			s.Name = "Traversal";
			s.Uri = "/Trav";

			foreach ( ApiEntry e in TraversalExecutors.ApiEntries ) {
				if ( e.Path.IndexOf("*") != -1 ) {
					continue;
				}

				string name = e.Path.Replace(s.Uri+"/", "");
				var op = NewOperation(name, e.ResponseType, e.RequestMethod);
				s.Operations.Add(op);
			}

			return s;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static FabServiceOperation NewOperation<T>(string pName,
														ApiEntry.Method pMethod=ApiEntry.Method.Get) {
			return NewOperation(pName, typeof(T), pMethod);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabServiceOperation NewOperation(string pName, Type pRespType,
														ApiEntry.Method pMethod=ApiEntry.Method.Get) {
			var op = new FabServiceOperation();
			op.Name = pName;
			op.Uri = "/"+pName.Replace(" ", "");
			op.Method = (pMethod+"").ToUpper();
			op.Return = ApiLang.TypeName(pRespType);
			return op;
		}

	}

}