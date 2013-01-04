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
	public class TGetScope {

		private readonly static string QueryGetScopeTx =
			"g.startTransaction();"+
			"_V0=[];"+
			"g.idx(_TP0).get('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
					".aggregate(_V0)"+
				".inE('"+typeof(OauthScopeUsesUser).Name+"').outV"+
					".as('step4')"+
				".outE('"+typeof(OauthScopeUsesApp).Name+"')[0].inV[0]"+
					".has('"+typeof(App).Name+"Id',Tokens.T.eq,{{AppId}}L)"+
					".aggregate(_V0)"+
				".back('step4')"+
					".aggregate(_V0)"+
					".iterate();"+
			"g.stopTransaction(TransactionalGraph.Conclusion.SUCCESS);"+
			"_V0;";

		private long vAppId;
		private long vUserId;
		private OauthScope vOauthScopeResult;
		private App vUsesApp;
		private User vUsesUser;
		private Mock<IApiContext> vMockCtx;
		private Mock<IApiDataAccess> vMockGetScopeTxResult;
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
			
			vUsesApp = new App();
			vUsesApp.AppId = vAppId;
			
			vUsesUser = new User();
			vUsesUser.UserId = vUserId;

			var mockUserDbDto = new Mock<IDbDto>();
			mockUserDbDto.Setup(x => x.ToNode<User>()).Returns(vUsesUser);

			var mockAppDbDto = new Mock<IDbDto>();
			mockAppDbDto.Setup(x => x.ToNode<App>()).Returns(vUsesApp);
			
			var mockScopeDbDto = new Mock<IDbDto>();
			mockScopeDbDto.Setup(x => x.ToNode<OauthScope>()).Returns(vOauthScopeResult);

			var list = new List<IDbDto>();
			list.Add(mockUserDbDto.Object);
			list.Add(mockAppDbDto.Object);
			list.Add(mockScopeDbDto.Object);
			
			vMockGetScopeTxResult = new Mock<IApiDataAccess>();
			vMockGetScopeTxResult.SetupGet(x => x.ResultDtoList).Returns(list);

			vMockCtx = new Mock<IApiContext>();
			vMockCtx
				.Setup(x => x.DbData(
					GetScope.Query.GetScopeTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => GetScopeTx(tx));
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
		private IApiDataAccess GetScopeTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(GetScope.Query.GetScopeTx+"");

			string expect = QueryGetScopeTx
				.Replace("{{UserId}}", vUserId+"")
				.Replace("{{AppId}}", vAppId+"");

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", typeof(User).Name);

			return vMockGetScopeTxResult.Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			ScopeResult result = TestGo(pViaTask);

			vUsageMap.AssertUses(GetScope.Query.GetScopeTx+"", 1);
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
		[TestCase(null)]
		[TestCase(0)]
		public void NotFound(int? pLen) {
			IList<IDbDto> list = null;
			if ( pLen == 0 ) { list = new List<IDbDto>(); }
			vMockGetScopeTxResult.SetupGet(x => x.ResultDtoList).Returns(list);

			ScopeResult result = TestGo();

			vUsageMap.AssertUses(GetScope.Query.GetScopeTx+"", 1);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public void ErrInvalidAppId(long pAppId) {
			vAppId = pAppId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public void ErrInvalidUserId(long pUserId) {
			vUserId = pUserId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}