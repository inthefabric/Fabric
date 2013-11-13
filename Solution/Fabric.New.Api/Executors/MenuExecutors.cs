using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Menu;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public static class MenuExecutors {

		public static readonly ApiEntry[] ApiEntries = new[] {
			ApiEntry.Get(ApiMenu.Home.Uri, GetHome, typeof(FabResponse<FabHome>)),
			ApiEntry.Get(ApiMenu.Meta.Uri, GetMeta, typeof(FabResponse<FabService>)),
			ApiEntry.Get(ApiMenu.Modify.Uri, GetMod, typeof(FabResponse<FabService>)),
			ApiEntry.Get(ApiMenu.Oauth.Uri, GetOauth, typeof(FabResponse<FabService>)),
			ApiEntry.Get(ApiMenu.Traversal.Uri, GetTrav, typeof(FabResponse<FabService>)),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetHome(IApiRequest pApiReq) {
			return new MenuExecutor<FabHome>(pApiReq, ApiMenu.Home).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetMeta(IApiRequest pApiReq) {
			return new MenuExecutor<FabService>(pApiReq, ApiMenu.Meta).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetMod(IApiRequest pApiReq) {
			return new MenuExecutor<FabService>(pApiReq, ApiMenu.Modify).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetOauth(IApiRequest pApiReq) {
			return new MenuExecutor<FabService>(pApiReq, ApiMenu.Oauth).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetTrav(IApiRequest pApiReq) {
			return new MenuExecutor<FabService>(pApiReq, ApiMenu.Traversal).Execute();
		}

	}

}