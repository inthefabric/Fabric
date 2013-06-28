using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;
using Fabric.Test.Common;

namespace Fabric.Test.FabApiOauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthGrantCore : TTestBase {
	
		private const string QueryGetApp =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0);";
			
		private const string QueryGetUser =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0);";

		private string vClientId;
		private long vClientIdLong;
		private string vRedirUri;
		private long vLoggedUserId;
		private long? vCoreUserId;
		
		private App vReturnApp;
		private User vReturnUser;
		
		private MockDataAccess vAppDataAcc;
		private MockDataAccess vUserDataAcc;
		
		private Mock<IOauthTasks> vMockTasks;
		private string vTaskGrantCode;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vClientIdLong = 12345;
			vClientId = vClientIdLong+"";
			vRedirUri = "http://www.test.com/oauth";
			vLoggedUserId = 345;
			vCoreUserId = vLoggedUserId;
			vTaskGrantCode = "testGrantCode1234";
			
			vReturnApp = new App();
			vReturnUser = new User();
			
			vMockTasks = new Mock<IOauthTasks>();
			vMockTasks.Setup(x => x.GetScope(vClientIdLong, vLoggedUserId, MockApiCtx.Object))
				.Returns(new ScopeResult() { Allow = true });
			vMockTasks.Setup(x => x.AddMemberEnsure(vClientIdLong, vLoggedUserId, MockApiCtx.Object))
				.Returns(true);
			vMockTasks.Setup(x => x.AddGrant(vClientIdLong, vLoggedUserId, vRedirUri, MockApiCtx.Object))
				.Returns(vTaskGrantCode);
				
			vAppDataAcc = MockDataAccess.Create(OnExecuteApp);
			vAppDataAcc.MockResult.SetupToElement(vReturnApp);
			
			vUserDataAcc = MockDataAccess.Create(OnExecuteUser);
			vUserDataAcc.MockResult.SetupToElement(vReturnUser);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthGrantCore NewCore() {
			return new OauthGrantCore(vClientId, vRedirUri, vLoggedUserId);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteApp(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			Assert.AreEqual(QueryGetApp, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", long.Parse(vClientId));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteUser(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			Assert.AreEqual(QueryGetUser, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vCoreUserId);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("123", 123, 456, 456L)]
		[TestCase("123", 123, 0, null)]
		[TestCase(null, 0, 456, 456L)]
		[TestCase(null, 0, 0, null)]
		[TestCase("123a", 0, 0, null)]
		public void New(string pClientId, long pAppId, long pLogUserId, long? pUserId) {
			vClientId = pClientId;
			vLoggedUserId = pLogUserId;
			
			var core = NewCore();
			
			Assert.AreEqual(vClientId, core.ClientId, "Incorrect ClientId.");
			Assert.AreEqual(vRedirUri, core.RedirectUri, "Incorrect RedirectUri.");
			Assert.AreEqual(vLoggedUserId, core.LoggedUserId, "Incorrect LoggedUserId.");
			Assert.AreEqual(pAppId, core.AppId, "Incorrect AppId.");
			Assert.AreEqual(pUserId, core.UserId, "Incorrect UserId.");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetApp() {
			MockDataList.Add(vAppDataAcc);
		
			App result = NewCore().GetApp(MockApiCtx.Object);
			
			AssertDataExecution(true);
			Assert.AreEqual(vReturnApp, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAppNotFound() {
			MockDataList.Add(vAppDataAcc);
			vAppDataAcc.MockResult.SetupToElement<App>(null);
			
			CheckOauthEx(() => NewCore().GetApp(MockApiCtx.Object),
				GrantErrors.unauthorized_client, GrantErrorDescs.BadClient);
			AssertDataExecution(true);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetUser() {
			MockDataList.Add(vUserDataAcc);
			
			User result = NewCore().GetUser(MockApiCtx.Object);
			
			AssertDataExecution(true);
			Assert.AreEqual(vReturnUser, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0L)]
		[TestCase(-1L)]
		[TestCase(null)]
		public void GetUserBadUserId(long? pUserId) {
			vCoreUserId = pUserId;
			
			OauthGrantCore core = NewCore();
			core.SetUserId(pUserId);
			
			User result = core.GetUser(MockApiCtx.Object);
			
			AssertDataExecution(false);
			Assert.Null(result, "Result should be null.");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetGrant() {
			LoginScopeResult result = NewCore()
				.GetGrantCodeIfScopeAlreadyAllowed(vMockTasks.Object, MockApiCtx.Object);
			
			AssertDataExecution(false);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vTaskGrantCode, result.Code, "Incorrect Result.Code.");
			Assert.AreEqual(vRedirUri, result.Redirect, "Incorrect Result.Redirect.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetGrantNoUserId() {
			OauthGrantCore core = NewCore();
			core.SetUserId(null);
			
			LoginScopeResult result = core
				.GetGrantCodeIfScopeAlreadyAllowed(vMockTasks.Object, MockApiCtx.Object);
			
			AssertDataExecution(false);
			Assert.Null(result, "Result should be null.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void GetGrantBadScope(bool pNull) {
			vMockTasks.Setup(x => x.GetScope(vClientIdLong, vLoggedUserId, MockApiCtx.Object))
				.Returns(pNull ? null : new ScopeResult() { Allow = false });
			
			LoginScopeResult result = NewCore()
				.GetGrantCodeIfScopeAlreadyAllowed(vMockTasks.Object, MockApiCtx.Object);
			
			AssertDataExecution(false);
			Assert.Null(result, "Result should be null.");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void AddGrantCode(bool pAlreadyAdded) {
			LoginScopeResult result = NewCore()
				.AddGrantCode(pAlreadyAdded, vMockTasks.Object, MockApiCtx.Object);
			
			AssertDataExecution(false);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vTaskGrantCode, result.Code, "Incorrect Result.Code.");
			Assert.AreEqual(vRedirUri, result.Redirect, "Incorrect Result.Redirect.");
			
			vMockTasks
				.Verify(x => x.AddScope(It.IsAny<long>(), It.IsAny<long>(),
						It.IsAny<bool>(), It.IsAny<IApiContext>()),
					(pAlreadyAdded ? Times.Never() : Times.Once()));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddGrantCodeNoUserId() {
			OauthGrantCore core = NewCore();
			core.SetUserId(null);
			
			LoginScopeResult result = core.AddGrantCode(true, vMockTasks.Object, MockApiCtx.Object);
			
			AssertDataExecution(false);
			Assert.Null(result, "Result should be null.");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void CheckOauthEx(TestDelegate pFunc, GrantErrors pErr, GrantErrorDescs pDesc) {
			OauthException oe = TestUtil.CheckThrows<OauthException>(true, pFunc);
			
			Assert.NotNull(oe.OauthError, "OauthError should filled.");
			Assert.AreEqual(pErr+"", oe.OauthError.Error, "Invalid OauthError.Error");
			Assert.AreEqual(OauthGrantCore.ErrDescStrings[(int)pDesc]+"",
				oe.OauthError.ErrorDesc, "Invalid OauthError.ErrorDesc");
		}
		
	}

}