using Fabric.Api.Internal.Setups;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	//TEST: All Modules
	//TEST: All Controllers
	public class HomeModule : BaseModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public HomeModule() {
			Log.ConfigureOnce();

			Get["/"] = (p => GetHome(Context));

			Get["/Internal/Setup"] = (p => GetInternalSetup(Context));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static Response GetHome(NancyContext pCtx) {
			var ac = new HomeController(pCtx.Request, NewApiCtx(), new OauthTasks());
			return ac.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response GetInternalSetup(NancyContext pCtx) {
			var ac = new SetupController(pCtx.Request, NewApiCtx());
			return ac.Execute();
		}

	}

}