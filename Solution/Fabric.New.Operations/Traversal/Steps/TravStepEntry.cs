namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepEntryContains<TFrom, TTo> : TravStep<TFrom, TTo> {

		private readonly string vPropDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepEntryContains(string pName, string pPropDbName) : base(pName, 1) {
			vPropDbName = pPropDbName;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath) {
			ITravPathStep step = pPath.ConsumeSteps(1, ToType)[0];
			step.VerifyParamCount(Params);

			string val = step.ParamAt<string>(0);
			string op = GremlinUtil.GetElasticContainsOperation();

			string propParam = pPath.AddParam(vPropDbName);
			string valParam = pPath.AddParam(val);

			pPath.AddScript(".has("+propParam+", "+op+", "+valParam+")");
		}

	}

}