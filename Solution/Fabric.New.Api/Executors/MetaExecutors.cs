using System;
using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Meta;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public static class MetaExecutors {

		private static readonly string Uri = ApiMenu.Meta.Uri;

		public static readonly ApiEntry[] ApiEntries = new[] {
			ApiEntry.Get(Uri+ApiMenu.MetaSpec.Uri, GetSpec, typeof(FabResponse<FabSpec>)),
			ApiEntry.Get(Uri+ApiMenu.MetaVersion.Uri, GetVersion, typeof(FabResponse<FabMetaVersion>)),
			ApiEntry.Get(Uri+ApiMenu.MetaTime.Uri, GetTime, typeof(FabResponse<FabMetaTime>)),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetSpec(IApiRequest pApiReq) {
			return Execute(pApiReq, ApiSpec.Spec);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetVersion(IApiRequest pApiReq) {
			return Execute(pApiReq, BaseModule.Version);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetTime(IApiRequest pApiReq) {
			return Execute(pApiReq, new FabMetaTime());
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