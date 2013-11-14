using System;
using Fabric.New.Api.Objects.Traversal;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepRoot<TTo> : TravStep<FabTravRoot, TTo> where TTo : FabTravTypedRoot {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepRoot(string pCmd) : base(pCmd) {}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ConsumeFirstPathItem(pPath, pToType);
		}

	}

}