using System;
using Fabric.New.Api.Objects.Traversal;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TravRule {
		
		public ITravStep Step { get; private set; }
		public Type FromType { get; private set; }
		public Type ToType { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravRule(ITravStep pStep, Type pFromType, Type pToType) {
			Step = pStep;
			FromType = pFromType;
			ToType = pToType;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabTravStep ToFabTravStep() {
			var s = new FabTravStep();
			s.Name = Step.Command;
			s.Uri = "/"+Step.Command;
			s.Return = (ToType == null ? null : ToType.Name);
			return s;
		}

	}

}