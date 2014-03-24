namespace Fabric.Infrastructure.Faults {

	/*================================================================================================*/
	public class FabOauthFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabOauthFault() : base(Code.OauthTokenFailure, "") {
			AppendMessage("The OAuth token provided with this API request "+
				"is either incorrect or expired.");
		}

	}

}