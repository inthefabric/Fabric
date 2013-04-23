using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetValidMemberByContext : XModifyTasks {


		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Member TestGo() {
			return Tasks.GetValidMemberByContext(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserZach, SetupUsers.MemberId.GalZach)]
		[TestCase(AppFab, UserMel, SetupUsers.MemberId.FabMel)]
		[TestCase(AppBook, UserBook, SetupUsers.MemberId.BookBookData)]
		public void Found(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId,
																SetupUsers.MemberId pExpectMemberId) {
			ApiCtx.SetAppUserId((long)pAppId, (long)pUserId);

			Member result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((long)pExpectMemberId, result.MemberId, "Incorrect MemberId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserFab)]
		[TestCase(AppBook, UserPenny)]
		[TestCase(AppGal, UserBook)] //has a "None" MemberType
		public void NotFound(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId) {
			ApiCtx.SetAppUserId((long)pAppId, (long)pUserId);

			Member result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}