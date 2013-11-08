
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects;
using Fabric.New.Operations;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public static class CreateExecutors {

		public static readonly ApiEntry[] ApiEntries = new [] {
			ApiEntry.Post("/Mod/Classes", CreateClass, typeof(FabResponse<FabClass>)),
			ApiEntry.Post("/Mod/Factors", CreateFactor, typeof(FabResponse<FabFactor>)),
			ApiEntry.Post("/Mod/Instances", CreateInstance, typeof(FabResponse<FabInstance>)),
			ApiEntry.Post("/Mod/Members", CreateMember, typeof(FabResponse<FabMember>)),
			ApiEntry.Post("/Mod/Urls", CreateUrl, typeof(FabResponse<FabUrl>)),
		};
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse CreateClass(IApiRequest pApiReq) {
			return new CreateExecutor<FabClass, CreateClassOperation>(pApiReq).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse CreateFactor(IApiRequest pApiReq) {
			return new CreateExecutor<FabFactor, CreateFactorOperation>(pApiReq).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse CreateInstance(IApiRequest pApiReq) {
			return new CreateExecutor<FabInstance, CreateInstanceOperation>(pApiReq).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse CreateMember(IApiRequest pApiReq) {
			return new CreateExecutor<FabMember, CreateMemberOperation>(pApiReq).Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse CreateUrl(IApiRequest pApiReq) {
			return new CreateExecutor<FabUrl, CreateUrlOperation>(pApiReq).Execute();
		}

	}

}