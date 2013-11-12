using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepEntry<TFrom, TVal, TTo> : TravStep<TFrom, TTo> {

		private readonly string vPropDbName;
		private readonly bool vExact;
		private readonly bool vToLower;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepEntry(string pName, string pPropDbName, bool pExact, bool pToLower) : 
																		base(pName, (pExact ? 1 : 2)) {
			vPropDbName = pPropDbName;
			vExact = pExact;
			vToLower = pToLower;
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

			if ( vToLower ) {
				var valStr = (val as string);
				
				if ( valStr != null ) {
					val = (TVal)(object)valStr.ToLower();
				}
			}

			op = GremlinUtil.GetStandardCompareOperation(op);
			string propParam = pPath.AddParam(vPropDbName);
			string valParam = pPath.AddParam(val);

			pPath.AddScript(".has("+propParam+", "+op+", "+valParam+")");
		}

	}

}