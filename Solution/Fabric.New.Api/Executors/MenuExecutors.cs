using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Menu;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public static class MenuExecutors {

		public static readonly ApiEntry[] ApiEntries = new[] {
			ApiEntry.Get(FabHome.HomeUri, GetHome, typeof(FabResponse<FabHome>)),
			ApiEntry.Get(FabHome.MetaUri, GetMeta, typeof(FabResponse<FabService>)),
			ApiEntry.Get(FabHome.ModUri, GetMod, typeof(FabResponse<FabService>)),
			ApiEntry.Get(FabHome.OauthUri, GetOauth, typeof(FabResponse<FabService>)),
			ApiEntry.Get(FabHome.TravUri, GetTrav, typeof(FabResponse<FabService>)),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetHome(IApiRequest pApiReq) {
			return new MenuExecutor<FabHome>(pApiReq, FabHome.Home).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetMeta(IApiRequest pApiReq) {
			return new MenuExecutor<FabService>(pApiReq, FabHome.MetaService).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetMod(IApiRequest pApiReq) {
			return new MenuExecutor<FabService>(pApiReq, FabHome.ModService).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetOauth(IApiRequest pApiReq) {
			return new MenuExecutor<FabService>(pApiReq, FabHome.OauthService).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetTrav(IApiRequest pApiReq) {
			return new MenuExecutor<FabService>(pApiReq, FabHome.TravService).Execute();
		}

	}

}