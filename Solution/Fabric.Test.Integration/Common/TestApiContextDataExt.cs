using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Elements;
using Weaver.Core.Query;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public static class TestApiContextDataExt {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IDataResult ExecuteForTest(this TestApiContext pApiCtx,
																		IWeaverScript pWeaverScript) {
			Log.Debug("TEST QUERY");
			return pApiCtx.Execute(pWeaverScript);
		}

	}

}