using Fabric.Infrastructure;
using Fabric.Infrastructure.Data;
using Weaver.Core.Query;

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