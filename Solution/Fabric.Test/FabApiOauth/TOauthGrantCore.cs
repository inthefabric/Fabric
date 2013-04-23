using Fabric.Api.Oauth;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiOauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthGrantCore {
	
		private const string QueryGetApp =
			"g.V('"+PropDbName.App_AppId+"',_P0);";
			
		private const string QueryGetUser =
			"g.V('"+PropDbName.User_UserId+"',_P0);";

		private string vClientId;
		private long vClientIdLong;
		private string vRedirUri;
		private long vLoggedUserId;
		private long? vCoreUserId;
		
		private Mock<IApiContext> vMockCtx;
		private App vReturnApp;
		private User vReturnUser;
		private UsageMap vUsageMap;
		
		private Mock<IOauthTasks> vMockTasks;
		private string vTaskGrantCode;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vClientIdLong = 12345;
			vClientId = vClientIdLong+"";
			vRedirUri = "http://www.test.com/oauth";
			vLoggedUserId = 345;
			vCoreUserId = vLoggedUserId;
			vTaskGrantCode = "testGrantCode1234";
			
			vReturnApp = new App();
			vReturnUser = new User();
			
			vMockCtx = new Mock<IApiContext>();
			vUsageMap = new UsageMap();
			
			vMockCtx
				.Setup(x => x.DbSingle<App>(OauthGrantCore.Query.GetApp+"", It.IsAny<IWeaverQuery>()))
					.Returns((string s, IWeaverQuery q) => GetAppReturns(q));
					
			vMockCtx
				.Setup(x => x.DbSingle<User>(OauthGrantCore.Query.GetUser+"", It.IsAny<IWeaverQuery>()))
					.Returns((string s, IWeaverQuery q) => GetUserReturns(q));
					
			vMockTasks = new Mock<IOauthTasks>();
			vMockTasks.Setup(x => x.GetScope(vClientIdLong, vLoggedUserId, vMockCtx.Object))
				.Returns(new ScopeResult() { Allow = true });
			vMockTasks.Setup(x => x.AddMemberEnsure(vClientIdLong, vLoggedUserId, vMockCtx.Object))
				.Returns(true);
			vMockTasks.Setup(x => x.AddGrant(vClientIdLong, vLoggedUserId, vRedirUri, vMockCtx.Object))
				.Returns(vTaskGrantCode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthGrantCore NewCore() {
			return new OauthGrantCore(vClientId, vRedirUri, vLoggedUserId);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private App GetAppReturns(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			vUsageMap.Increment(OauthGrantCore.Query.GetApp+"");
			
			Assert.AreEqual(QueryGetApp, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", long.Parse(vClientId));
			
			return vReturnApp;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private User GetUserReturns(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			vUsageMap.Increment(OauthGrantCore.Query.GetUser+"");
			
			Assert.AreEqual(QueryGetUser, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vCoreUserId);
			
			return vReturnUser;
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
			App result = NewCore().GetApp(vMockCtx.Object);
			
			vUsageMap.AssertUses(OauthGrantCore.Query.GetApp+"", 1);
			vUsageMap.AssertUses(OauthGrantCore.Query.GetUser+"", 0);
			Assert.AreEqual(vReturnApp, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAppNotFound() {
			vReturnApp = null;
			CheckOauthEx(() => NewCore().GetApp(vMockCtx.Object),
				GrantErrors.unauthorized_client, GrantErrorDescs.BadClient);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetUser() {
			User result = NewCore().GetUser(vMockCtx.Object);
			
			vUsageMap.AssertUses(OauthGrantCore.Query.GetApp+"", 0);
			vUsageMap.AssertUses(OauthGrantCore.Query.GetUser+"", 1);
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
			
			User result = core.GetUser(vMockCtx.Object);
			
			vUsageMap.AssertNoOverallUses();
			Assert.Null(result, "Result should be null.");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetGrant() {
			LoginScopeResult result = NewCore()
				.GetGrantCodeIfScopeAlreadyAllowed(vMockTasks.Object, vMockCtx.Object);
			
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
				.GetGrantCodeIfScopeAlreadyAllowed(vMockTasks.Object, vMockCtx.Object);
			
			Assert.Null(result, "Result should be null.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void GetGrantBadScope(bool pNull) {
			vMockTasks.Setup(x => x.GetScope(vClientIdLong, vLoggedUserId, vMockCtx.Object))
				.Returns(pNull ? null : new ScopeResult() { Allow = false });
			
			LoginScopeResult result = NewCore()
				.GetGrantCodeIfScopeAlreadyAllowed(vMockTasks.Object, vMockCtx.Object);
			
			Assert.Null(result, "Result should be null.");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void AddGrantCode(bool pAlreadyAdded) {
			LoginScopeResult result = NewCore()
				.AddGrantCode(pAlreadyAdded, vMockTasks.Object, vMockCtx.Object);
			
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
			
			LoginScopeResult result = core.AddGrantCode(true, vMockTasks.Object, vMockCtx.Object);
			
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