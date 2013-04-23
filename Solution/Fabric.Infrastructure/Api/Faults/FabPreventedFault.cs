using System;

namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabPreventedFault : FabFault {
		
		public string Note { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabPreventedFault(Code pCode, string pNote, Exception pInner=null) : 
																			base(pCode, "", pInner) {
			Note = pNote;
			AppendMessage("This action was prevented. "+Note);
		}
		
	}

}