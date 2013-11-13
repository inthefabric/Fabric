using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Menu;
using Fabric.New.Api.Objects.Meta;
using Fabric.New.Api.Objects.Oauth;
using FabOauthAccess = Fabric.New.Api.Objects.FabOauthAccess;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public static class ApiMenu {

		public readonly static FabService Meta = BuildMetaMenu();
		public readonly static FabService Modify = BuildModMenu();
		public readonly static FabService Oauth = BuildOauthMenu();
		public readonly static FabService Traversal = BuildTravMenu();
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

			var op = NewOperation<FabSpec>("Specification");
			op.Uri = "/Spec";
			s.Operations.Add(op);

			op = NewOperation<FabMetaVersion>("Version");
			s.Operations.Add(op);

			op = NewOperation<FabMetaTime>("Time");
			s.Operations.Add(op);

			return s;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabService BuildModMenu() {
			var s = new FabService();
			s.Name = "Modify";
			s.Uri = "/Mod";
			return s;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabService BuildOauthMenu() {
			var s = new FabService();
			s.Name = "Oauth";
			s.Uri = "/Oauth";

			var op = NewOperation<FabOauthAccess>("AccessToken");
			s.Operations.Add(op);

			op = NewOperation<FabOauthAccess>("AccessTokenAuthCode");
			s.Operations.Add(op);

			op = NewOperation<FabOauthAccess>("AccessTokenRefresh");
			s.Operations.Add(op);

			op = NewOperation<FabOauthAccess>("AccessTokenClientCredentials");
			s.Operations.Add(op);

			op = NewOperation<FabOauthAccess>("AccessTokenClientDataProv");
			s.Operations.Add(op);

			op = NewOperation<FabOauthLogin>("Login");
			s.Operations.Add(op);

			op = NewOperation<FabOauthLogout>("Logout");
			s.Operations.Add(op);

			return s;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabService BuildTravMenu() {
			var s = new FabService();
			s.Name = "Traversal";
			s.Uri = "/Trav";
			return s;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static FabServiceOperation NewOperation<T>(string pName,
									ApiEntry.Method pMethod=ApiEntry.Method.Get) where T : FabObject {
			var op = new FabServiceOperation();
			op.Name = pName;
			op.Uri = "/"+pName.Replace(" ", "");
			op.Method = (pMethod+"").ToUpper();
			op.ReturnType = typeof(T).Name;
			return op;
		}

	}

}