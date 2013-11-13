using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Operations.Traversal;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public class TraversalExecutor : FabResponseExecutor<FabObject> {

		//private static readonly Logger Log = Logger.Build<TraversalExecutor>();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TraversalExecutor(IApiRequest pApiReq) : base(pApiReq) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override IList<FabObject> GetResponse() {
			string path = ApiReq.Path.Substring(6); //remove "/Trav/"

			var t = new TraversalOperation();
			t.Perform(ApiReq.OpCtx, path);
			return t.GetResult();
		}
	}

}