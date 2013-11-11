using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepHas<TFrom, TVal> : TravStep<TFrom, TFrom> {

		private readonly bool vExact;
		private readonly string vPropDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepHas(string pProperty, string pPropDbName, bool pExact) : 
															base("Has"+pProperty, (pExact ? 1 : 2)) {
			vExact = pExact;
			vPropDbName = pPropDbName;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath) {
			ITravPathStep step = pPath.ConsumeSteps(1, ToType)[0];
			step.VerifyParamCount(Params);

			TVal val = step.ParamAt<TVal>(0);
			string op = GremlinUtil.Equal;

			if ( !vExact ) {
				op = step.ParamAt<string>(1);

				if ( !GremlinUtil.IsValidContainsOperation(op) ) {
					throw step.NewStepFault(FabFault.Code.IncorrectParamValue, "Invalid operator.", 1);
				}
			}

			string propParam = pPath.AddParam(vPropDbName);
			string valParam = pPath.AddParam(val);

			pPath.AddScript(".has("+propParam+", "+op+", "+valParam+")");
		}

	}

}