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
			return new MetaExecutor<FabSpec>(pApiReq, ApiSpec.Spec).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetVersion(IApiRequest pApiReq) {
			return new MetaExecutor<FabMetaVersion>(pApiReq, BaseModule.Version).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse GetTime(IApiRequest pApiReq) {
			return new MetaExecutor<FabMetaTime>(pApiReq, new FabMetaTime()).Execute();
		}

	}

}