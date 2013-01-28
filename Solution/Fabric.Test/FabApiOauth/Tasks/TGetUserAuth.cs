using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetUserAuth {

		private static readonly string QueryGetUserAuth =
			"g.V('RootId',0)[0]"+
				".outE('"+typeof(RootContainsUser).Name+"').inV"+
					".has('Password',Tokens.T.eq,_P0)"+
					".filter{it.getProperty('Name').toLowerCase()==NAME};";

		private string vUsername;
		private string vPassword;
		private Mock<IApiContext> vMockCtx;
		private User vGetUserAuthResult;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vUsername = "ZachKinstner";
			vPassword = "abcdefg";
			vUsageMap = new UsageMap();

			vGetUserAuthResult = new User();

			vMockCtx = new Mock<IApiContext>();

			vMockCtx
				.Setup(x => x.DbSingle<User>(
					GetUserAuth.Query.GetUser+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetUser(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private User TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetUserAuth(vUsername, vPassword, vMockCtx.Object);
			}

			var task = new GetUserAuth(vUsername, vPassword);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private User GetUser(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			vUsageMap.Increment(GetUserAuth.Query.GetUser+"");

			Assert.AreEqual(QueryGetUserAuth, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", FabricUtil.HashPassword(vPassword));
			TestUtil.CheckParam(pQuery.Params, "NAME", vUsername.ToLower());

			return vGetUserAuthResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			User result = TestGo(pViaTask);

			vUsageMap.AssertUses(GetUserAuth.Query.GetUser+"", 1);
			Assert.AreEqual(vGetUserAuthResult, result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			vGetUserAuthResult = null;

			User result = TestGo();

			vUsageMap.AssertUses(GetUserAuth.Query.GetUser+"", 1);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullUsername() {
			vUsername = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullPassword() {
			vPassword = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}