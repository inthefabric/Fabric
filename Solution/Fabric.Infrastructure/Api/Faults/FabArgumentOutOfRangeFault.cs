namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabArgumentOutOfRangeFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentOutOfRangeFault(string pArgName)
													: base("Value "+pArgName+" is out of range.") {}
		
	}

}