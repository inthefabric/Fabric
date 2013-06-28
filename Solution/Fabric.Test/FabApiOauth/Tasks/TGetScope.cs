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
using Fabric.Test.Common;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetScope : TTestBase {

		private const string QueryGetMatchingScope =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
			".inE('"+EdgeDbName.OauthScopeUsesUser+"').outV"+
				".as('step5')"+
			".outE('"+EdgeDbName.OauthScopeUsesApp+"').inV"+
				".has('"+PropDbName.Artifact_ArtifactId+"',Tokens.T.eq,_P1)"+
			".back('step5');";

		private long vAppId;
		private long vUserId;
		private OauthScope vOauthScopeResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 8456;
			vUserId = 9876;
			
			vOauthScopeResult = new OauthScope();
			vOauthScopeResult.OauthScopeId = 25234;
			vOauthScopeResult.Allow = true;
			vOauthScopeResult.Created = 9148275124252;

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vOauthScopeResult);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private ScopeResult TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetScope(vAppId, vUserId, MockApiCtx.Object);
			}

			var task = new GetScope(vAppId, vUserId);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			Assert.AreEqual(QueryGetMatchingScope, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vUserId);
			TestUtil.CheckParam(cmd.Params, "_P1", vAppId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			ScopeResult result = TestGo(pViaTask);

			AssertDataExecution(true);
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
			MockDataList[0].MockResult.SetupToElement<OauthScope>(null);

			ScopeResult result = TestGo();

			AssertDataExecution(true);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidUserId() {
			vUserId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

	}

}