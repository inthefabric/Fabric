using System;

namespace Fabric.New.Infrastructure.Faults {
	
	/*================================================================================================*/
	public class FabStepFault : FabFault {

		public int StepIndex { get; private set; }
		public int ParamIndex { get; private set; }
		public string StepText { get; private set; }
		public string ParamText { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabStepFault(Code pErrCode, int pStepIndex, string pRawText, string pMessage, 
											int pParamIndex=-1, string pParamRawText=null,
											Exception pInner=null) : base(pErrCode, pMessage, pInner) {
			StepIndex = pStepIndex;
			StepText = pRawText;
			ParamIndex = pParamIndex;
			ParamText = pParamRawText;

			string msg = "\nStep "+StepIndex+": '"+StepText+"'"+
				(ParamIndex == -1 ? "" : "\nParam "+ParamIndex+": '"+ParamText+"'");
			AppendMessage(msg);
		}

	}

}