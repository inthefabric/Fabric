namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabNotFoundFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabNotFoundFault(string pItem) 
									: base("No "+pItem+" item was found with the given criteria.") {}
		
	}

}