namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabMembershipFault : FabFault {
		
		public long AppId { get; private set; }
		public long UserId { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMembershipFault(long pAppId, long pUserId) : base(Code.MemberNotFound, "") {
			AppId = pAppId;
			UserId = pUserId;
			AppendMessage("There is no Member which associates the active App (AppId="+
				AppId+") with the active User (UserId="+UserId+").");
		}

	}

}