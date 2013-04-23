using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetMemberOfApp : XWebTasks {

		private long vAppId;
		private long vMemberId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Member TestGo() {
			return Tasks.GetMemberOfApp(ApiCtx, vAppId, vMemberId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppFab, SetupUsers.MemberId.FabFabData)]
		[TestCase(AppGal, SetupUsers.MemberId.GalBookDataNone)]
		public void Found(SetupUsers.AppId pAppId, SetupUsers.MemberId pMemberId) {
			vAppId = (long)pAppId;
			vMemberId = (long)pMemberId;

			Member result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vMemberId, result.MemberId, "Incorrect MemberId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppFab, SetupUsers.MemberId.GalEllie)]
		[TestCase(AppGal, SetupUsers.MemberId.FabEllie)]
		public void NotFound(SetupUsers.AppId pAppId, SetupUsers.MemberId pMemberId) {
			vAppId = (long)pAppId;
			vMemberId = (long)pMemberId;

			Member result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}