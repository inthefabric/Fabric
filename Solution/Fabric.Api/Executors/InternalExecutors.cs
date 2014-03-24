using System;
using Fabric.Api.Interfaces;
using Fabric.Operations.Internal;

namespace Fabric.Api.Executors {

	/*================================================================================================*/
	public static class InternalExecutors {

		public static readonly ApiEntry[] ApiEntries = new[] {
			ApiEntry.Get("Internal/InitDb", DoSetupDatabase, typeof(object))
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse DoSetupDatabase(IApiRequest pApiReq) {
			Func<object> getResp = (() => {
				var op = new InternalInitDbOperation();
				op.Perform(pApiReq.OpCtx, pApiReq.GetQueryValue("pass", false));
				return op.GetResult();
			});

			var exec = new JsonExecutor<object>(pApiReq, getResp);
			return exec.Execute();
		}

	}

}