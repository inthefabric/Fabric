using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetUserAuth : TTestBase {

		private const string QueryGetUserAuth =
			"g.V('"+PropDbName.User_NameKey+"',_P0)"+
				".has('"+PropDbName.User_Password+"',Tokens.T.eq,_P1);";

		private string vUsername;
		private string vPassword;
		private User vGetUserAuthResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vUsername = "ZachKinstner";
			vPassword = "abcdefg";

			vGetUserAuthResult = new User();

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vGetUserAuthResult);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private User TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetUserAuth(vUsername, vPassword, MockApiCtx.Object);
			}

			var task = new GetUserAuth(vUsername, vPassword);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			Assert.AreEqual(QueryGetUserAuth, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vUsername.ToLower());
			TestUtil.CheckParam(cmd.Params, "_P1", FabricUtil.HashPassword(vPassword));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			User result = TestGo(pViaTask);

			AssertDataExecution(true);
			Assert.AreEqual(vGetUserAuthResult, result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			MockDataList[0].MockResult.SetupToElement<User>(null);

			User result = TestGo();

			AssertDataExecution(true);
			Assert.Null(result, "Result should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("", "x")]
		[TestCase(" ", "x")]
		[TestCase("x", "")]
		[TestCase("x", " ")]
		public void NotFoundEmpty(string pUsername, string pPassword) {
			vUsername = pUsername;
			vPassword = pPassword;

			User result = TestGo();

			AssertDataExecution(false);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullUsername() {
			vUsername = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullPassword() {
			vPassword = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

	}

}