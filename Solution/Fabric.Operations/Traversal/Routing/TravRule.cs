using System;
using Fabric.Api.Objects.Traversal;

namespace Fabric.Operations.Traversal.Routing {

	/*================================================================================================*/
	public class TravRule : ITravRule {
		
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
		public static FabTravStep ToFabTravStep(ITravRule pRule) {
			var s = new FabTravStep();
			s.Name = pRule.Step.Command;
			s.Uri = "/"+pRule.Step.Command;
			s.Return = (pRule.ToType == null ? null : pRule.ToType.Name);
			return s;
		}

	}

}