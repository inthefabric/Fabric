using System;
using Fabric.New.Api.Objects.Traversal;

namespace Fabric.New.Operations.Traversal.Routing {

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
		public static FabTravStep ToFabTravStep(TravRule pRule) {
			var s = new FabTravStep();
			s.Name = pRule.Step.Command;
			s.Uri = "/"+pRule.Step.Command;
			s.Return = (pRule.ToType == null ? null : pRule.ToType.Name);
			return s;
		}

	}

}