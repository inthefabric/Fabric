namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabArgumentOutOfRangeFault : FabFault {
		
		//TODO: improve FabArgumentOutOfRangeFault message for full sentences
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentOutOfRangeFault(string pArgName)
													: base("Value "+pArgName+" is out of range.") {}
		
	}

}