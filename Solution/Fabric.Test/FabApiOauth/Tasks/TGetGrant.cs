using System;
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
	public class TGetGrant : TTestBase {

		private const string QueryGetAndUpdateTx =
			"_V0=[];"+
			"g.V('"+PropDbName.OauthGrant_Code+"',_TP)"+
				".has('"+PropDbName.OauthGrant_Expires+"',Tokens.T.gt,_TP)"+
				".aggregate(_V0)"+
				".as('step5')"+
			".outE('"+EdgeDbName.OauthGrantUsesApp+"').inV"+
				".aggregate(_V0)"+
			".back('step5')"+
			".outE('"+EdgeDbName.OauthGrantUsesUser+"').inV"+
				".aggregate(_V0)"+
			".back('step5')"+
				".sideEffect{"+
					"it.removeProperty('"+PropDbName.OauthGrant_Code+"');"+
				"}"+
				".iterate();"+
			"_V0;";

		private OauthGrant vResultGrant;
		private App vResultApp;
		private User vResultUser;
		private DateTime vUtcNow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vUtcNow = DateTime.UtcNow;
			
			vResultGrant = new OauthGrant();
			vResultGrant.Id = "x99";
			vResultGrant.OauthGrantId = 123;
			vResultGrant.Code = "abcdefghijklmnopqrstuvwxyz789012";
			vResultGrant.RedirectUri = "test.com/redir";
			
			vResultApp = new App();
			vResultApp.ArtifactId = 456;
			
			vResultUser = new User();
			vResultUser.ArtifactId = 9878;
			
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.Setup(x => x.ToElementAt<OauthGrant>(0, 0)).Returns(vResultGrant);
			mda.MockResult.Setup(x => x.ToElementAt<App>(0, 1)).Returns(vResultApp);
			mda.MockResult.Setup(x => x.ToElementAt<User>(0, 2)).Returns(vResultUser);
			mda.MockResult.Setup(x => x.GetCommandResultCount(0)).Returns(3);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private GrantResult TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetGrant(vResultGrant.Code, MockApiCtx.Object);
			}

			var task = new GetGrant(vResultGrant.Code);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			string expect = TestUtil.InsertParamIndexes(QueryGetAndUpdateTx, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_TP", new object[] {
				vResultGrant.Code,
				vUtcNow.Ticks
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			GrantResult result = TestGo(pViaTask);
			
			AssertDataExecution(true);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vResultGrant.OauthGrantId, result.GrantId, "Incorrect Result.GrantId.");
			Assert.AreEqual(vResultGrant.Code, result.Code, "Incorrect Result.AccessToken.");
			Assert.AreEqual(vResultGrant.RedirectUri, result.RedirectUri,
				"Incorrect Result.RedirectUri.");
			Assert.AreEqual(vResultApp.ArtifactId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vResultUser.ArtifactId, result.UserId, "Incorrect Result.UserId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-1)]
		[TestCase(0)]
		public void NotFound(int pCount) {
			MockDataList[0].MockResult.Setup(x => x.GetCommandResultCount(0)).Returns(pCount);

			GrantResult result = TestGo();

			AssertDataExecution(true);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullCode() {
			vResultGrant.Code = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

	}

}