using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetScope {

		private const string QueryGetMatchingScope =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
			".inE('"+RelDbName.OauthScopeUsesUser+"').outV"+
				".as('step5')"+
			".outE('"+RelDbName.OauthScopeUsesApp+"').inV"+
				".has('"+PropDbName.Artifact_ArtifactId+"',Tokens.T.eq,_P1)"+
			".back('step5');";

		private long vAppId;
		private long vUserId;
		private OauthScope vOauthScopeResult;
		private Mock<IApiContext> vMockCtx;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vAppId = 8456;
			vUserId = 9876;
			vUsageMap = new UsageMap();
			
			vOauthScopeResult = new OauthScope();
			vOauthScopeResult.OauthScopeId = 25234;
			vOauthScopeResult.Allow = true;
			vOauthScopeResult.Created = 9148275124252;

			vMockCtx = new Mock<IApiContext>();
			vMockCtx
				.Setup(x => x.DbSingle<OauthScope>(
					GetScope.Query.GetMatchingScope+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetMatchingScope(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private ScopeResult TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetScope(vAppId, vUserId, vMockCtx.Object);
			}

			var task = new GetScope(vAppId, vUserId);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthScope GetMatchingScope(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			vUsageMap.Increment(GetScope.Query.GetMatchingScope+"");

			Assert.AreEqual(QueryGetMatchingScope, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vUserId);
			TestUtil.CheckParam(pQuery.Params, "_P1", vAppId);

			return vOauthScopeResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			ScopeResult result = TestGo(pViaTask);

			vUsageMap.AssertUses(GetScope.Query.GetMatchingScope+"", 1);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vOauthScopeResult.OauthScopeId, result.ScopeId,"Incorrect Result.ScopeId.");
			Assert.AreEqual(vAppId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vUserId, result.UserId, "Incorrect Result.UserId.");
			Assert.AreEqual(vOauthScopeResult.Allow, result.Allow, "Incorrect Result.Allow.");
			Assert.AreEqual(vOauthScopeResult.Created, result.Created.Ticks,
				"Incorrect Result.Created.");
			Assert.Null(result.Login, "Result.Login should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			vOauthScopeResult = null;

			ScopeResult result = TestGo();

			vUsageMap.AssertUses(GetScope.Query.GetMatchingScope+"", 1);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidUserId() {
			vUserId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}