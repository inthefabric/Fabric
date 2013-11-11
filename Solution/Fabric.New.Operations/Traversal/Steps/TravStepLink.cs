namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepLink<TFrom, TTo> : TravStep<TFrom, TTo> {

		private readonly string vEdgeDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepLink(string pCommand, string pEdgeDbName) : base(pCommand, 0) {
			vEdgeDbName = pEdgeDbName;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath) {
			ITravPathStep step = pPath.ConsumeSteps(1, ToType)[0];
			step.VerifyParamCount(Params);

			string edgeParam = pPath.AddParam(vEdgeDbName);
			pPath.AddScript(".outE("+edgeParam+")");
		}

	}

}