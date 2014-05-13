using System;
using Fabric.Api.Interfaces;
using Fabric.Operations.Internal;

namespace Fabric.Api.Executors {

	/*================================================================================================*/
	public static class InternalExecutors {

		public static readonly ApiEntry[] ApiEntries = new[] {
			ApiEntry.Get("Internal/InitDb", DoSetupDatabase, typeof(object)),
			ApiEntry.Get("Internal/RemoveMember", DoRemoveMember, typeof(object)),
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

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse DoRemoveMember(IApiRequest pApiReq) {
			Func<object> getResp = (() => {
				var op = new InternalRemoveMemberOperation();
				op.Perform(pApiReq.OpCtx,
					pApiReq.GetQueryValue("pass", false),
					pApiReq.GetQueryValue("memId", false),
					pApiReq.GetQueryValue("delete", false));
				return op.GetResult();
			});

			var exec = new JsonExecutor<object>(pApiReq, getResp);
			return exec.Execute();
		}

	}

}