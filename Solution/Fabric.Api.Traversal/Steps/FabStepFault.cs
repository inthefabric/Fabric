using System;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Traversal.Steps {
	
	/*================================================================================================*/
	public class FabStepFault : FabFault {

		public IStep Step { get; private set; }
		public int StepIndex { get; private set; }
		public int ParamIndex { get; private set; }
		public string StepText { get; private set; }
		public string ParamText { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabStepFault(Code pErrCode, IStep pStep, string pMessage, int pParamIndex=-1,
											Exception pInner=null) : base(pErrCode, pMessage, pInner) {
			Step = pStep;

			StepIndex = Step.GetPathIndex();
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

			string msg = "\nStep "+StepIndex+": '"+StepText+"'"+
				(ParamIndex == -1 ? "" : "\nParam "+ParamIndex+": '"+ParamText+"'");
			AppendMessage(msg);
		}

	}

}