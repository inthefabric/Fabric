using System;
using Fabric.New.Api.Objects;
using Fabric.New.Operations.Traversal.Routing;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepLink<TFrom, TTo> : TravStep<TFrom, TTo>
														where TFrom : FabVertex where TTo : FabElement {

		private readonly string vEdgeDbName;
		private readonly bool vInVertex;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepLink(string pCmd, string pEdgeDbName, bool pInVertex) : base(pCmd) {
			vEdgeDbName = pEdgeDbName;
			vInVertex = pInVertex;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ConsumeFirstPathItem(pPath, pToType);

			pPath.AddScript(
				".outE("+pPath.AddParam(vEdgeDbName)+")"+
				(vInVertex ? ".inV" : "")
			);
		}

	}

}