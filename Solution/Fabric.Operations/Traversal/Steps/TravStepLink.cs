using System;
using Fabric.Api.Objects;
using Fabric.Infrastructure.Spec;
using Fabric.Operations.Traversal.Routing;

namespace Fabric.Operations.Traversal.Steps {

	/*================================================================================================*/
	[SpecStep("Link")]
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