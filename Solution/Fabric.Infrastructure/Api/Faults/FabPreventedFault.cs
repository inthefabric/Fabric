namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabPreventedFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabPreventedFault(string pNote) : base("This action was prevented. "+pNote) {}

		/*--------------------------------------------------------------------------------------------*/
		public FabPreventedFault(long pAppId) : this("The active App (AppId="+pAppId+
													") is not permitted to perform this action.") {}
		
	}

}