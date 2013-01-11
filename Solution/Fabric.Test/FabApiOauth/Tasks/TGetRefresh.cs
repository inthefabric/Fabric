using System.Collections.Generic;
using Fabric.Api.Oauth.Results;
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
	public class TGetRefresh {

		private readonly static string QueryGetAccessTx =
			"_V0=[];"+
			"g.V('RootId',0)[0]"+
				".outE('"+typeof(RootContainsOauthAccess).Name+"').inV"+
					".has('Refresh',Tokens.T.eq,_TP0)"+
					".has('IsClientOnly',Tokens.T.eq,false)"+
					".as('step5')"+
				".outE('"+typeof(OauthAccessUsesApp).Name+"').inV"+
					".aggregate(_V0)"+
				".back('step5')"+
				".outE('"+typeof(OauthAccessUsesUser).Name+"').inV"+
					".aggregate(_V0)"+
					".iterate();"+
			"_V0;";

		private string vRefToken;
		private App vUsesApp;
		private User vUsesUser;
		private Mock<IApiContext> vMockCtx;
		private Mock<IApiDataAccess> vMockGetAccessTxResult;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vRefToken = "abcdefghijklmnopqrstuvwxyz789012";
			vUsageMap = new UsageMap();
			
			vUsesApp = new App();
			vUsesApp.AppId = 456;
			
			vUsesUser = new User();
			vUsesUser.UserId = 9878;
			
			var mockAppDbDto = new Mock<IDbDto>();
			mockAppDbDto.Setup(x => x.ToNode<App>()).Returns(vUsesApp);
			
			var mockUserDbDto = new Mock<IDbDto>();
			mockUserDbDto.Setup(x => x.ToNode<User>()).Returns(vUsesUser);
			
			var list = new List<IDbDto>();
			list.Add(mockAppDbDto.Object);
			list.Add(mockUserDbDto.Object);
			
			vMockGetAccessTxResult = new Mock<IApiDataAccess>();
			vMockGetAccessTxResult.SetupGet(x => x.ResultDtoList).Returns(list);

			vMockCtx = new Mock<IApiContext>();
			vMockCtx
				.Setup(x => x.DbData(
					GetRefresh.Query.GetAppUserTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => GetAccessTx(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private RefreshResult TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetRefresh(vRefToken, vMockCtx.Object);
			}

			var task = new GetRefresh(vRefToken);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess GetAccessTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(GetRefresh.Query.GetAppUserTx+"");
			string expect = QueryGetAccessTx
				.Replace("{{RefToken}}", vRefToken);

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", vRefToken);

			return vMockGetAccessTxResult.Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			RefreshResult result = TestGo(pViaTask);

			vUsageMap.AssertUses(GetRefresh.Query.GetAppUserTx+"", 1);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vUsesApp.AppId, result.AppId, "Incorrect Result.AppId.");
			Assert.AreEqual(vUsesUser.UserId, result.UserId, "Incorrect Result.UserId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase(0)]
		public void NotFound(int? pLen) {
			IList<IDbDto> list = null;
			if ( pLen == 0 ) { list = new List<IDbDto>(); }
			vMockGetAccessTxResult.SetupGet(x => x.ResultDtoList).Returns(list);

			RefreshResult result = TestGo();

			vUsageMap.AssertUses(GetRefresh.Query.GetAppUserTx+"", 1);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullCode() {
			vRefToken = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}