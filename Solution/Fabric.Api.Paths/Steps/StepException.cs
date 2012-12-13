using System;

namespace Fabric.Api.Paths.Steps {
	
	/*================================================================================================*/
	public class StepException : Exception {

		public IStep Step { get; private set; }
		public int StepIndex { get; private set; }
		public int ParamIndex { get; private set; }
		public string StepText { get; private set; }
		public string ParamText { get; private set; }

		private string vMessage;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public StepException(IStep pStep, string pMessage, int pParamIndex=-1,
														Exception pInnerEx=null) : base("", pInnerEx) {
			Step = pStep;

			StepIndex = Path.GetSegmentIndexOfStep(pStep);
			ParamIndex = pParamIndex;
			StepText = pStep.Data.RawString;

			try {
				if ( ParamIndex != -1 ) {
					ParamText = pStep.Data.Params[ParamIndex];
				}
			}
			catch ( Exception ) {
				ParamText = null;
			}

			vMessage += pMessage;
			vMessage += "\nStep "+StepIndex+": '"+StepText+"'";

			if ( ParamIndex != -1 ) {
				vMessage += "\nParam "+ParamIndex+": '"+ParamText+"'";
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string Message {
			get { return vMessage; }
		}

	}

}