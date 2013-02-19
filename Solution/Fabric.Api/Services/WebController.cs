using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Modify.Tasks;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Web;
using Fabric.Api.Web.Tasks;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class WebController : FabResponseController {

		//NOTE: controller routing could be improved. For example, create a static ...
		//Dictionary<string, Func<string>> where the key is "METHOD /service/operation",
		//then just execute the Func<string> to get the data. Update methods to be
		//like AppsPost, FactorsPut, and FactorsDelete.

		public enum Route {
			Home,
			Apps,
			Users
		}

		private static FabService ServiceDto;
		private static string ServiceDtoJson;
		//private static Dictionary<string, Func<string>> RouteMap;

		private readonly Route vRoute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public WebController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks,
												Route pRoute) : base(pRequest, pApiCtx, pOauthTasks) {
			vRoute = pRoute;

			if ( ServiceDto == null ) {
				ServiceDto = FabHome.NewModifyService(true);
				ServiceDtoJson = ServiceDto.ToJson();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			return NewResponse(new FabRespJsonView(FabResp, GetRouteJson()));
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetRouteJson() {
			switch ( vRoute ) {
				case Route.Home: return ServiceDtoJson;
				case Route.Apps: return Apps();
				case Route.Users: return Users();
				default: return "";
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IWebTasks NewWebTasks() {
			return new WebTasks();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IModifyTasks NewModTasks() {
			return new ModifyTasks();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string FuncGo<T>(IApiFunc<T> pFunc) {
			return pFunc.Go(ApiCtx).ToJson();
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabNotFoundFault BadRequest() {
			return new FabNotFoundFault(typeof(FabServiceOperation), NancyReq.Method+" "+NancyReq.Path);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string Apps() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateApp(
						NewWebTasks(),
						NewModTasks(),
						GetPostString(CreateApp.NameParam),
						GetPostLong(CreateApp.UserIdParam)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Users() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateUser(
						NewWebTasks(),
						NewModTasks(),
						GetPostString(CreateUser.NameParam),
						GetPostString(CreateUser.PasswordParam),
						GetPostString(CreateUser.EmailParam)
					));
			}

			throw BadRequest();
		}

	}

}