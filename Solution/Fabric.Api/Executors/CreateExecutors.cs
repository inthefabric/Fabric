
// GENERATED CODE
// Changes made to this source file will be overwritten

using System;
using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
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
			return Execute<Class, FabClass, CreateClassOperation>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse CreateFactor(IApiRequest pApiReq) {
			return Execute<Factor, FabFactor, CreateFactorOperation>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse CreateInstance(IApiRequest pApiReq) {
			return Execute<Instance, FabInstance, CreateInstanceOperation>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse CreateMember(IApiRequest pApiReq) {
			return Execute<Member, FabMember, CreateMemberOperation>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse CreateUrl(IApiRequest pApiReq) {
			return Execute<Url, FabUrl, CreateUrlOperation>(pApiReq);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse Execute<TDom, TApi, TOp>(IApiRequest pApiReq) 
														where TDom : Vertex
														where TApi : FabVertex
														where TOp : ICreateOperation<TDom,TApi>, new() {
			Func<IList<TApi>> getResp = (() => {
				string json = pApiReq.GetFormValue("Data", true);
				var o = new TOp();

				TDom result = o.Execute(
					pApiReq.OpCtx, new CreateOperationBuilder(), new CreateOperationTasks(), json);

				return new List<TApi> {
					o.ConvertResult(result)
				};
			});
			
			var exec = new FabResponseExecutor<TApi>(pApiReq, getResp);
			return exec.Execute();
		}

	}

}