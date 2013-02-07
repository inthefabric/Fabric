using System;

namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabInternalFault : FabFault {
		
		public string Note { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabInternalFault(string pNote, Exception pInner=null) : 
																base(Code.InternalError, "", pInner) {
			Note = pNote;
			AppendMessage("This action was prevented. "+pNote);
		}
		
	}

}