using System;
using Fabric.Api.Dto;
using Fabric.Infrastructure;

namespace Fabric.Api.Paths.Steps {
	
	/*================================================================================================*/
	public class StepException : Exception {

		public enum Code {
			IncorrectParamCount = 1001,
			IncorrectParamValue = 1002,
			IncorrectParamType = 1003
		}

		public override string Message { get { return vMessage; } }
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

			vMessage = BuildMessage(pMessage);
			Log.Error(vMessage);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabError ToFabError() {
			var e = new FabError();
			e.Code = (int)ErrCode;
			e.CodeName = ErrCode+"";
			e.Type = GetType().Name;
			e.Message = Message;
			return e;
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string BuildMessage(string pMessage) {
			string msg = ErrCode+" ("+(int)ErrCode+"): "+pMessage;
			msg += "\nStep "+StepIndex+": '"+StepText+"'";

			if ( ParamIndex != -1 ) {
				msg += "\nParam "+ParamIndex+": '"+ParamText+"'";
			}

			return msg;
		}

	}

}