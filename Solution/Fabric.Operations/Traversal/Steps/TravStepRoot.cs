using System;
using Fabric.Api.Objects.Traversal;
using Fabric.Infrastructure.Spec;
using Fabric.Operations.Traversal.Routing;

namespace Fabric.Operations.Traversal.Steps {

	/*================================================================================================*/
	[SpecStep("Root", IsRoot=true)]
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