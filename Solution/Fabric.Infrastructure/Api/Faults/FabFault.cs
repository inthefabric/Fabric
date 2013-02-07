using System;

namespace Fabric.Infrastructure.Api.Faults {
	
	/*================================================================================================*/
	public abstract class FabFault : Exception {

		public enum Code {
			InternalError = 1001,
			ActionNotPermitted = 1002,
			MemberNotFound = 1003,
			UniqueConstraintViolation = 1004,
			ObjectNotFound = 1005,
			
			ArgumentNullFault = 1205,
			ArgumentLengthFault = 1206,
			ArgumentOutOfRange = 1207,
			ArgumentInvalidValue = 1208,
			
			IncorrectParamCount = 2001,
			IncorrectParamValue = 2002,
			IncorrectParamType = 2003,
			InvalidParamSyntax = 2004,
			InvalidStep = 2204,
			
			FactorAlreadyCompleted = 3001,
			FactorElementConflict = 3002
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