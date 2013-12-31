﻿using System;
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
			Func<object> getResp = (() => {
				var op = new InternalInitDbOperation();
				op.Perform(pApiReq.OpCtx, pApiReq.GetQueryValue("pass", true));
				return op.GetResult();
			});

			var exec = new BasicExecutor<object>(pApiReq, getResp);
			return exec.Execute();
		}

	}

}