using Fabric.New.Api.Executors;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public class ApiModule : BaseModule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiModule() {
			SetupFromApiEntries(CreateExecutors.ApiEntries);
		}

	}

}