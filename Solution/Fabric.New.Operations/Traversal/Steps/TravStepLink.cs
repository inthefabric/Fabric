using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepLink<TFrom, TTo> : TravStep<TFrom, TTo>
														where TFrom : FabVertex where TTo : FabElement {

		private readonly string vEdgeDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepLink(string pCommand, string pEdgeDbName) : base(pCommand) {
			vEdgeDbName = pEdgeDbName;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath) {
			ConsumeFirstPathItem(pPath);
			pPath.AddScript(".outE("+pPath.AddParam(vEdgeDbName)+")");
		}

	}

}