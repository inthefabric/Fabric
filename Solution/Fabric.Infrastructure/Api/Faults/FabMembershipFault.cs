namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabMembershipFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMembershipFault(long pAppId, long pUserId) : base("There is no Member which "+
													"associates the active App (AppId="+pAppId+
													") with the active User (UserId="+pUserId+").") {}

	}

}