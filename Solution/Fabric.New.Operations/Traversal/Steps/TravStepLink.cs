using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepLink<TFrom, TTo> : TravStep<TFrom, TTo> {

		private readonly string vEdgeDbName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepLink(string pCommand, string pEdgeDbName) : base(pCommand, 0) {
			vEdgeDbName = pEdgeDbName;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override bool AcceptsPath(ITravPath pPath) {
			if ( !pPath.CurrentType.IsAssignableFrom(FromType) ) {
				return false;
			}

			IList<ITravPathStep> steps = pPath.GetSteps(1);

			if ( steps != null ) {
				ITravPathStep s = steps[0];
				return (s.Command == Command);
			}

			return false;
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