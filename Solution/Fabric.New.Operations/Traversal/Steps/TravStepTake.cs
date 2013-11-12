using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepTake<TFrom> : TravStep<TFrom, TFrom> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepTake() : base("Take", 1) {}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath) {
			ITravPathStep step = pPath.ConsumeSteps(1, ToType)[0];
			step.VerifyParamCount(Params);

			int count = step.ParamAt<int>(0);
			
			if ( count < 1 || count > 100 ) {
				throw step.NewStepFault(FabFault.Code.IncorrectParamValue,
					"Cannot be less than 1 or greater than 100.", 0);
			}

			pPath.AddScript("["+count+"]");
		}

	}

}