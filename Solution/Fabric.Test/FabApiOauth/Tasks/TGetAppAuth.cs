﻿using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetAppAuth{

		private readonly static string QueryGetApp =
			"g.V('"+typeof(App).Name+"Id',{{AppId}}L)[0]"+
				".has('Secret',Tokens.T.eq,_P0);";

		private long vAppId;
		private string vAppSecret;
		private App vGetAppResult;

		private Mock<IApiContext> vMockCtx;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vAppId = 123;
			vAppSecret = "abcdefghijklmnopqrstuvwxyz789012";
			vGetAppResult = new App();
			vUsageMap = new UsageMap();

			vMockCtx = new Mock<IApiContext>();

			vMockCtx
				.Setup(x => x.DbSingle<App>(
					GetAppAuth.Query.GetApp+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetApp(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private App TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetAppAuth(vAppId, vAppSecret, vMockCtx.Object);
			}

			var task = new GetAppAuth(vAppId, vAppSecret);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private App GetApp(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			vUsageMap.Increment(GetAppAuth.Query.GetApp+"");
			string expect = QueryGetApp
				.Replace("{{AppId}}", vAppId+"");

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vAppSecret);

			return vGetAppResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			App result = TestGo(pViaTask);

			vUsageMap.AssertUses(GetAppAuth.Query.GetApp+"", 1);
			Assert.AreEqual(vGetAppResult, result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			vGetAppResult = null;

			App result = TestGo();

			vUsageMap.AssertUses(GetAppAuth.Query.GetApp+"", 1);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public void ErrAppIdRange(int pAppId) {
			vAppId = pAppId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullSecret() {
			vAppSecret = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}