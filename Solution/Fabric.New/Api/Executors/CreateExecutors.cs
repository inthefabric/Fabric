
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects;
using Fabric.New.Api.Operations;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public static class CreateExecutors {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IApiResponse CreateClass(IApiRequest pApiReq) {
			var ce = new CreateExecutor<FabClass, CreateClassOperation>(pApiReq);
			return ce.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IApiResponse CreateFactor(IApiRequest pApiReq) {
			var ce = new CreateExecutor<FabFactor, CreateFactorOperation>(pApiReq);
			return ce.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IApiResponse CreateInstance(IApiRequest pApiReq) {
			var ce = new CreateExecutor<FabInstance, CreateInstanceOperation>(pApiReq);
			return ce.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IApiResponse CreateMember(IApiRequest pApiReq) {
			var ce = new CreateExecutor<FabMember, CreateMemberOperation>(pApiReq);
			return ce.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static IApiResponse CreateUrl(IApiRequest pApiReq) {
			var ce = new CreateExecutor<FabUrl, CreateUrlOperation>(pApiReq);
			return ce.Execute();
		}

	}

}