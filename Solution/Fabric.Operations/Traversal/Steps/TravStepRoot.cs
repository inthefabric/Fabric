using System;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Infrastructure.Spec;
using Fabric.New.Operations.Traversal.Routing;

namespace Fabric.New.Operations.Traversal.Steps {

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