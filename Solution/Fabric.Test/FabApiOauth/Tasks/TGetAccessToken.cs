using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
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
	public class TGetAccessToken : TTestBase {

		private const string QueryGetAccessTx = 
			"_V0=[];"+
			"g.V('"+PropDbName.OauthAccess_Token+"',_TP)"+
				".has('"+PropDbName.OauthAccess_Expires+"',Tokens.T.gt,_TP)"+
				".aggregate(_V0)"+
				".as('step5')"+
			".outE('"+EdgeDbName.OauthAccessUsesApp+"').inV"+
				".aggregate(_V0)"+
			".back('step5')"+
			".outE('"+EdgeDbName.OauthAccessUsesUser+"').inV"+
				".aggregate(_V0)"+
				".iterate();"+
			"_V0;";

		private string vToken;
		private DateTime vUtcNow;
		private int vExpiresInSec;
		private OauthAccess vResultAccess;
		private App vResultApp;
		private User vResultUser;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vToken = "abcdefghijklmnopqrstuvwxyz789012";
			vUtcNow = DateTime.UtcNow;
			vExpiresInSec = 1000;

			vResultAccess = new OauthAccess();
			vResultAccess.Token = vToken;
			vResultAccess.Refresh = FabricUtil.Code32;
			vResultAccess.Expires = vUtcNow.AddSeconds(vExpiresInSec).Ticks;

			vResultApp = new App();
			vResultApp.ArtifactId = 456;

			vResultUser = new User();
			vResultUser.ArtifactId = 9878;
			
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			
			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.Setup(x => x.ToElementAt<OauthAccess>(0,0)).Returns(vResultAccess);
			mda.MockResult.Setup(x => x.ToElementAt<App>(0,1)).Returns(vResultApp);
			mda.MockResult.Setup(x => x.ToElementAt<User>(0,2)).Returns(vResultUser);
			mda.MockResult.Setup(x => x.GetCommandResultCount(0)).Returns(3);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetAccessToken(vToken, MockApiCtx.Object);
			}

			var task = new GetAccessToken(vToken);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			
			string expect = TestUtil.InsertParamIndexes(QueryGetAccessTx, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_TP", new object[] {
				vToken,
				vUtcNow.Ticks
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			FabOauthAccess result = TestGo(pViaTask);

			CheckSuccessResult(result);
			AssertDataExecution(true);
			Assert.AreEqual(vResultUser.ArtifactId, result.UserId, "Incorrect Result.UserId.");

			MockMemCache.Verify(
				x => x.AddOauthAccess(
					vToken,
					It.Is<Tuple<OauthAccess, long, long?>>(tuple =>
						tuple.Item1 == vResultAccess && 
						tuple.Item2 == vResultApp.ArtifactId &&
						tuple.Item3 == vResultUser.ArtifactId
					),
					It.Is<int>(exp => exp == vExpiresInSec)
				)
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void SuccessNoUser(bool pViaTask) {
			MockDataList[0].MockResult.Setup(x => x.GetCommandResultCount(0)).Returns(2);

			FabOauthAccess result = TestGo(pViaTask);

			CheckSuccessResult(result);
			AssertDataExecution(true);
			Assert.Null(result.UserId, "Result.UserId should be null.");

			MockMemCache.Verify(
				x => x.AddOauthAccess(
					vToken,
					It.Is<Tuple<OauthAccess, long, long?>>(tuple => 
						tuple.Item1 == vResultAccess && 
						tuple.Item2 == vResultApp.ArtifactId &&
						tuple.Item3 == null
					),
					It.Is<int>(exp => exp == vExpiresInSec)
				)
			);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void SuccessCache(bool pViaTask) {
			var tuple = new Tuple<OauthAccess, long, long?>(
				vResultAccess, vResultApp.ArtifactId, vResultUser.ArtifactId);
			MockMemCache.Setup(x => x.FindOauthAccess(vToken)).Returns(tuple);

			FabOauthAccess result = TestGo(pViaTask);

			CheckSuccessResult(result);
			AssertDataExecution(false);
			Assert.AreEqual(vResultUser.ArtifactId, result.UserId, "Incorrect Result.UserId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-1)]
		[TestCase(0)]
		public void NotFound(int pCount) {
			MockDataList[0].MockResult.Setup(x => x.GetCommandResultCount(0)).Returns(pCount);

			FabOauthAccess result = TestGo();

			AssertDataExecution(true);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullToken() {
			vToken = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("x")]
		[TestCase("1234567890123456789012345678901")]
		[TestCase("123456789012345678901234567890123")]
		public void ErrTokenLen(string pToken) {
			vToken = pToken;
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("1234567890123456789012345678901_")]
		[TestCase("123456789 1234567890123456789012")]
		public void ErrTokenChars(string pToken) {
			vToken = pToken;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void CheckSuccessResult(FabOauthAccess pResult) {
			Assert.NotNull(pResult, "Result should be filled.");
			Assert.AreEqual(vToken, pResult.AccessToken, "Incorrect Result.AccessToken.");
			Assert.AreEqual(vResultAccess.Refresh, pResult.RefreshToken,
				"Incorrect Result.RefreshToken.");
			Assert.AreEqual("bearer", pResult.TokenType, "Incorrect Result.TokenType.");
			Assert.AreEqual(vExpiresInSec, pResult.ExpiresIn, "Incorrect Result.ExpiresIn.");
			Assert.AreEqual(vResultApp.ArtifactId, pResult.AppId, "Incorrect Result.AppId.");
		}

	}

}