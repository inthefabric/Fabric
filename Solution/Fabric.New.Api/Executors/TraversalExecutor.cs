using System.Collections.Generic;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Operations.Traversal;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public class TraversalExecutor : FabResponseExecutor<FabObject> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TraversalExecutor(IApiRequest pApiReq) : base(pApiReq) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override IList<FabObject> GetResponse() {
			var t = new TraversalOperation();
			t.Perform(ApiReq.OpCtx, ApiReq.Path);
			return t.GetResult();
		}

	}

}