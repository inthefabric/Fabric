using Fabric.New.Api.Objects.Traversal;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepRoot<TTo> : TravStep<FabTravRoot, TTo> where TTo : FabTravRoot {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepRoot(string pCommand) : base(pCommand) {}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath) {
			ConsumeFirstPathItem(pPath);
		}

	}

}