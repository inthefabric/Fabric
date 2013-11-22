using System.Collections.Generic;
using System.Linq;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public class TraversalExecutor : FabResponseExecutor<FabElement> {

		private TraversalOperation vOper;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TraversalExecutor(IApiRequest pApiReq) : base(pApiReq) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override IList<FabElement> GetResponse() {
			string path = ApiReq.Path.Substring(6); //remove "/Trav/"

			vOper = new TraversalOperation();
			vOper.Perform(ApiReq.OpCtx, path);
			return vOper.GetResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabResponse<FabElement> NewFabResponse() {
			var ftr = new FabTravResponse<FabElement>();
			ftr.Steps = vOper.GetResultSteps().ToArray();
			return ftr;
		}

	}

}