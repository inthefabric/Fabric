using Nancy;
using Nancy.Conventions;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class ApiBootstrap : DefaultNancyBootstrapper {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void ConfigureConventions(NancyConventions pConv) {
			base.ConfigureConventions(pConv);

			pConv.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory("/graph/js", @"/graph/js")
			);

			pConv.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory("/graph/styles", @"/graph/styles")
			);

			pConv.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory("/tables/styles", @"/tables/styles")
			);
		}

	}

}