using System;

namespace Fabric.Infrastructure.Api.Faults {
	
	/*================================================================================================*/
	public abstract class FabFault : Exception {

		public enum Code {
			IncorrectParamCount = 2001,
			IncorrectParamValue = 2002,
			IncorrectParamType = 2003,
			InvalidStep = 2004
		}

		public Code ErrCode { get; private set; }

		private string vMessage;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabFault(string pMessage) : base(pMessage) {
			vMessage = pMessage;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected FabFault(Code pErrCode, string pMessage, Exception pInner=null) :
																				base(pMessage, pInner) {
			ErrCode = pErrCode;
			vMessage = ErrCode+" ("+(int)ErrCode+"): "+pMessage;
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