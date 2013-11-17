
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Operations.Create;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public static class CreateExecutors {

		private static readonly IList<ApiEntryParam> ClassParams = new List<ApiEntryParam> {
			new ApiEntryParam("Data", typeof(CreateFabClass))
		};

		private static readonly IList<ApiEntryParam> FactorParams = new List<ApiEntryParam> {
			new ApiEntryParam("Data", typeof(CreateFabFactor))
		};

		private static readonly IList<ApiEntryParam> InstanceParams = new List<ApiEntryParam> {
			new ApiEntryParam("Data", typeof(CreateFabInstance))
		};

		private static readonly IList<ApiEntryParam> MemberParams = new List<ApiEntryParam> {
			new ApiEntryParam("Data", typeof(CreateFabMember))
		};

		private static readonly IList<ApiEntryParam> UrlParams = new List<ApiEntryParam> {
			new ApiEntryParam("Data", typeof(CreateFabUrl))
		};

		public static readonly ApiEntry[] ApiEntries = new [] {
			ApiEntry.Post("/Mod/Classes", CreateClass, typeof(FabResponse<FabClass>), ClassParams),
			ApiEntry.Post("/Mod/Factors", CreateFactor, typeof(FabResponse<FabFactor>), FactorParams),
			ApiEntry.Post("/Mod/Instances", CreateInstance, typeof(FabResponse<FabInstance>), InstanceParams),
			ApiEntry.Post("/Mod/Members", CreateMember, typeof(FabResponse<FabMember>), MemberParams),
			ApiEntry.Post("/Mod/Urls", CreateUrl, typeof(FabResponse<FabUrl>), UrlParams),
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