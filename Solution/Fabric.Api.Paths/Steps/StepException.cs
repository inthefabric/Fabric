using System;
using Fabric.Infrastructure;

namespace Fabric.Api.Paths.Steps {
	
	/*================================================================================================*/
	public class StepException : Exception {

		public enum Code {
			IncorrectParamCount = 1001,
			IncorrectParamValue = 1002,
			FailedParamConversion = 1003
		}

		public Code ErrCode { get; private set; }
		public IStep Step { get; private set; }
		public int StepIndex { get; private set; }
		public int ParamIndex { get; private set; }
		public string StepText { get; private set; }
		public string ParamText { get; private set; }

		private readonly string vMessage;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public StepException(Code pErrCode, IStep pStep, string pMessage, int pParamIndex=-1,
														Exception pInnerEx=null) : base("", pInnerEx) {
			ErrCode = pErrCode;
			Step = pStep;

			StepIndex = Path.GetSegmentIndexOfStep(Step);
			ParamIndex = pParamIndex;
			StepText = Step.Data.RawString;

			try {
				if ( ParamIndex != -1 ) {
					ParamText = Step.Data.Params[ParamIndex];
				}
			}
			catch ( Exception ) {
				ParamText = null;
			}

			vMessage = BuildMessage(pMessage);
			Log.Error(vMessage);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string BuildMessage(string pMessage) {
			string msg = ErrCode+" ("+(int)ErrCode+"): "+pMessage;
			msg += "\nStep "+StepIndex+": '"+StepText+"'";

			if ( ParamIndex != -1 ) {
				msg += "\nParam "+ParamIndex+": '"+ParamText+"'";
			}

			return msg;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string Message {
			get { return vMessage; }
		}

	}

}