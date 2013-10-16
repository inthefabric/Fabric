using System.Text;
using Fabric.Api.Internal.Setups;
using Fabric.Api.Internal.Status;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	//TEST: All Modules
	//TEST: All Controllers
	public class HomeModule : BaseModule {

		private static readonly byte[] RoboBytes = Encoding.UTF8.GetBytes("User-agent: *\nDisallow: /");


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public HomeModule() {
			Log.ConfigureOnce();

			Get["/"] = (p => GetHome(Context));

			Get["/robots.txt"] = (p => {
				var r = new Response();
				r.ContentType = "text/plain; charset=utf-8";
				r.Contents = (s => s.Write(RoboBytes, 0, RoboBytes.Length));
				return r;
			});
			
			Get["/Internal/Setup"] = (p => GetInternalSetup(Context));

			Get["/Internal/Status"] = (p => GetInternalStatus(Context));
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

		/*--------------------------------------------------------------------------------------------*/
		private static Response GetInternalStatus(NancyContext pCtx) {
			var ac = new StatusController(pCtx.Request, NewApiCtx());
			return ac.Execute();
		}

	}

}