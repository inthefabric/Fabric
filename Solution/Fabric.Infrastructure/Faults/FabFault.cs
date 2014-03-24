using System;

namespace Fabric.New.Infrastructure.Faults {
	
	/*================================================================================================*/
	public abstract class FabFault : Exception {

		public enum Code {
			HttpError = 1,

			InternalError = 1001,
			AuthorizationRequired = 1002,
			ActionNotPermitted = 1003,
			OauthTokenFailure = 1004,
			UniqueConstraintViolation = 1005,
			ObjectNotFound = 1006,
			ArgumentMissingFault = 1007,

			InvalidStep = 2001,
			IncorrectParamCount = 2002,
			IncorrectParamValue = 2003,
			IncorrectParamType = 2004,
			InvalidParamSyntax = 2005,

			PropertyNullFault = 3001,
			PropertyLengthFault = 3002,
			PropertyOutOfRange = 3003,
			PropertyInvalidValue = 3004,
		}

		public Code ErrCode { get; private set; }

		private string vMessage;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabFault(Code pErrCode, string pMessage, Exception pInner=null) :
																				base(pMessage, pInner) {
			ErrCode = pErrCode;
			vMessage = (pMessage ?? "");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override string Message {
			get { return vMessage; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppendMessage(string pMessage) {
			vMessage += pMessage;
		}

	}

}