using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Modify;
using Fabric.Api.Modify.Tasks;
using Fabric.Api.Oauth.Tasks;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class ModifyController : FabResponseController {

		public enum Route {
			Home,
			Apps,
			Classes,
			Descriptors,
			Directors,
			Eventors,
			Factors,
			Identors,
			Instances,
			Locators,
			Urls,
			Users,
			Vectors
		}

		private static FabService ServiceDto;
		private static string ServiceDtoJson;

		private readonly Route vRoute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ModifyController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks,
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
				case Route.Apps: return AddApp();
				default: return "";
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static ModifyTasks NewModTasks() {
			return new ModifyTasks();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string FuncGo<T>(IApiFunc<T> pFunc) {
			return pFunc.Go(ApiCtx).ToJson();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string AddApp() {
			var ca = new CreateApp(
				NewModTasks(),
				GetPostString(CreateApp.NameParam),
				GetPostLong(CreateApp.UserIdParam)
			);

			return FuncGo(ca);
		}

	}

}