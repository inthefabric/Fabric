namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabMembershipFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMembershipFault(uint pAppKeyId) 
										: base("The authenticated User does not have a membership "+
												"with the App specified by AppKey.Id="+pAppKeyId) {}

	}

}