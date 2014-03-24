using System;
using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Menu;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public static class MenuExecutors {

		public static readonly ApiEntry[] ApiEntries = new[] {
			ApiEntry.Get(ApiMenu.Home.Uri, GetHome, typeof(FabResponse<FabHome>)),
			ApiEntry.Get(ApiMenu.Meta.Uri, GetMeta, typeof(FabResponse<FabService>)),
			ApiEntry.Get(ApiMenu.Mod.Uri, GetMod, typeof(FabResponse<FabService>)),
			ApiEntry.Get(ApiMenu.Oauth.Uri, GetOauth, typeof(FabResponse<FabService>)),
			ApiEntry.Get(ApiMenu.Trav.Uri, GetTrav, typeof(FabResponse<FabService>)),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetHome(IApiRequest pApiReq) {
			return Execute(pApiReq, ApiMenu.Home);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetMeta(IApiRequest pApiReq) {
			return Execute(pApiReq, ApiMenu.Meta);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetMod(IApiRequest pApiReq) {
			return Execute(pApiReq, ApiMenu.Mod);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetOauth(IApiRequest pApiReq) {
			return Execute(pApiReq, ApiMenu.Oauth);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetTrav(IApiRequest pApiReq) {
			return Execute(pApiReq, ApiMenu.Trav);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse Execute<T>(IApiRequest pApiReq, T pObj) where T : FabObject {
			Func<IList<T>> getResp = (() => new List<T> { pObj });

			var exec = new FabResponseExecutor<T>(pApiReq, getResp);
			return exec.Execute();
		}

	}

}