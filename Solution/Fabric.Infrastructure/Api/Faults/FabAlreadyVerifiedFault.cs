namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabAlreadyVerifiedFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabAlreadyVerifiedFault(string pItem) 
												: base("This "+pItem+" has already been verified.") {}
		
	}

}