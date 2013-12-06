using System;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public partial class CreateMemberOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void VerifyCustomMember() { }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterSessionStart() {
			//TODO: verify member doesn't already exist
			throw new NotImplementedException();
		}

	}

}