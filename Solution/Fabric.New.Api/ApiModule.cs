using Fabric.New.Api.Executors;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public class ApiModule : BaseModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiModule() {
			SetupFromApiEntries(MenuExecutors.ApiEntries);
			SetupFromApiEntries(CreateExecutors.ApiEntries);
			SetupFromApiEntries(TraversalExecutors.ApiEntries);
		}

	}

}