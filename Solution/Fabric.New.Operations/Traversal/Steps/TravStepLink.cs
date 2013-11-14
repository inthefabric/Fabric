using System;
using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepLink<TFrom, TTo> : TravStep<TFrom, TTo>
														where TFrom : FabVertex where TTo : FabElement {

		private readonly string vEdgeDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepLink(string pCmd, string pEdgeDbName) : base(pCmd) {
			vEdgeDbName = pEdgeDbName;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ConsumeFirstPathItem(pPath, pToType);
			pPath.AddScript(".outE("+pPath.AddParam(vEdgeDbName)+")");
		}

	}

}