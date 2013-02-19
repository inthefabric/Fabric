using Fabric.Api.Dto;
using Fabric.Api.Oauth.Tasks;
using Fabric.Api.Services;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	public class ModifyModule : BaseModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ModifyModule() {
			const string mod = FabHome.ModUri;
			const string classes = mod+FabHome.ModClassesUri;
			const string descriptors = mod+FabHome.ModDescriptorsUri;
			const string directors = mod+FabHome.ModDirectorsUri;
			const string eventors = mod+FabHome.ModEventorsUri;
			const string factors = mod+FabHome.ModFactorsUri;
			const string identors = mod+FabHome.ModIdentorsUri;
			const string instances = mod+FabHome.ModInstancesUri;
			const string locators = mod+FabHome.ModLocatorsUri;
			const string urls = mod+FabHome.ModUrlsUri;
			const string vectors = mod+FabHome.ModVectorsUri;

			Get[mod] = (p => Spec(Context, ModifyController.Route.Home));
			Post[classes] = (p => Spec(Context, ModifyController.Route.Classes));
			Post[descriptors] = (p => Spec(Context, ModifyController.Route.Descriptors));
			Post[directors] = (p => Spec(Context, ModifyController.Route.Directors));
			Post[eventors] = (p => Spec(Context, ModifyController.Route.Eventors));
			Post[factors] = (p => Spec(Context, ModifyController.Route.Factors));
			Put[factors] = (p => Spec(Context, ModifyController.Route.Factors));
			Delete[factors] = (p => Spec(Context, ModifyController.Route.Factors));
			Post[identors] = (p => Spec(Context, ModifyController.Route.Identors));
			Post[instances] = (p => Spec(Context, ModifyController.Route.Instances));
			Post[locators] = (p => Spec(Context, ModifyController.Route.Locators));
			Post[urls] = (p => Spec(Context, ModifyController.Route.Urls));
			Post[vectors] = (p => Spec(Context, ModifyController.Route.Vectors));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Response Spec(NancyContext pCtx, ModifyController.Route pRoute) {
			var sc = new ModifyController(pCtx.Request, NewApiCtx(), new OauthTasks(), pRoute);
			return sc.Execute();
		}

	}

}