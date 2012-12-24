namespace Fabric.Infrastructure.Api.Faults {
	
	/*================================================================================================*/
	public class FabAuthorizationFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabAuthorizationFault(string pAuthType) 
							: base("This function or action requires "+pAuthType+" authentication.") {}

	}

}