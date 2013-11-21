using Fabric.New.Api.Interfaces;
using Fabric.New.Operations.Internal;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public static class InternalExecutors {

		public static readonly ApiEntry[] ApiEntries = new[] {
			ApiEntry.Get("Internal/InitDb", DoSetupDatabase, typeof(object))
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse DoSetupDatabase(IApiRequest pApiReq) {
			return new InternalExecutor<InternalInitDbOperation>(pApiReq).Execute();
		}

	}

}