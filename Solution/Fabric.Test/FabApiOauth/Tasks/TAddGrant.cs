﻿using System;
using Fabric.Api.Oauth.Tasks;
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
	public class TAddGrant {

		private readonly static string QueryUpdateGrantTx =
			"_V0=[];"+
			"g.V('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
				".inE('"+typeof(OauthGrantUsesUser).Name+"').outV"+
					".as('step3')"+
				".outE('"+typeof(OauthGrantUsesApp).Name+"').inV"+
					".has('"+typeof(App).Name+"Id',Tokens.T.eq,{{AppId}}L)"+
				".back('step3')"+
					".aggregate(_V0)"+
					".each{"+
						"it.setProperty('RedirectUri',_TP0);"+
						"it.setProperty('Expires',{{ExpireTicks}}L);"+
						"it.setProperty('Code',_TP1)"+
					"};"+
			"_V0;";

		private readonly static string QueryAddGrantTx =
			"g.V('RootId',0)[0]"+
				".each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(OauthGrant).Name+"Id:{{OauthGrantId}}L,"+
				"RedirectUri:_TP0,"+
				"Code:_TP1,"+
				"Expires:{{ExpireTicks}}L"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP2);"+
			"g.V('"+typeof(App).Name+"Id',{{AppId}}L)[0]"+
				".each{_V2=g.v(it)};"+
			"g.addEdge(_V1,_V2,_TP3);"+
			"g.V('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
				".each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,_TP4);";

		protected long vAppId;
		protected long vUserId;
		protected string vRedirUri;
		protected string vGrantCode;
		protected DateTime vUtcNow;
		protected long vAddOauthGrantId;
		private OauthGrant vGrantResult;
		protected Mock<IApiContext> vMockCtx;
		protected UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vAppId = 99;
			vUserId = 1234;
			vRedirUri = "http://www.test.com/oauth";
			vGrantCode = "12345678901234567890123456789012";
			vUtcNow = DateTime.UtcNow;
			vAddOauthGrantId = 123456789;
			vUsageMap = new UsageMap();
			
			vGrantResult = new OauthGrant();
			vGrantResult.Code = vGrantCode;

			vMockCtx = new Mock<IApiContext>();
			vMockCtx.Setup(x => x.GetSharpflakeId<OauthGrant>()).Returns(vAddOauthGrantId);
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			vMockCtx.SetupGet(x => x.Code32).Returns(vGrantCode);
			
			vMockCtx
				.Setup(x => x.DbSingle<OauthGrant>(
					AddGrant.Query.UpdateGrantTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverScript ws) => UpdateGrant(ws));
			
			vMockCtx
				.Setup(x => x.DbData(AddGrant.Query.AddGrantTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverScript ws) => AddGrantTx(ws));
		}

		/*--------------------------------------------------------------------------------------------*/
		private string TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().AddGrant(vAppId, vUserId, vRedirUri, vMockCtx.Object);
			}

			var task = new AddGrant(vAppId, vUserId, vRedirUri);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthGrant UpdateGrant(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddGrant.Query.UpdateGrantTx+"");
			
			string expect = QueryUpdateGrantTx
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", vUserId+"")
				.Replace("{{ExpireTicks}}", vUtcNow.AddMinutes(2).Ticks+"");

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			
			TestUtil.CheckParam(pScripted.Params, "_TP0", vRedirUri);
			TestUtil.CheckParam(pScripted.Params, "_TP1", vGrantCode);
			
			return vGrantResult;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess AddGrantTx(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddGrant.Query.AddGrantTx+"");

			string expect = QueryAddGrantTx
				.Replace("{{OauthGrantId}}", vAddOauthGrantId+"")
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", vUserId+"")
				.Replace("{{ExpireTicks}}", vUtcNow.AddMinutes(2).Ticks+"");

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pScripted.Params, "_TP0", vRedirUri);
			TestUtil.CheckParam(pScripted.Params, "_TP1", vGrantCode);
			TestUtil.CheckParam(pScripted.Params, "_TP2", typeof(RootContainsOauthGrant).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP3", typeof(OauthGrantUsesApp).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP4", typeof(OauthGrantUsesUser).Name);
			
			return null;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void UpdateSuccess(bool pViaTask) {
			string result = TestGo(pViaTask);

			vUsageMap.AssertUses(AddGrant.Query.UpdateGrantTx+"", 1);
			vUsageMap.AssertUses(AddGrant.Query.AddGrantTx+"", 0);
			Assert.AreEqual(vGrantCode, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void AddGrantSuccess(bool pViaTask) {
			vGrantResult = null;
			
			string result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddGrant.Query.UpdateGrantTx+"", 1);
			vUsageMap.AssertUses(AddGrant.Query.AddGrantTx+"", 1);
			Assert.AreEqual(vGrantCode, result, "Incorrect Result.");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public virtual void ErrAppId(long pAppId) {
			vAppId = pAppId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public virtual void ErrUserId(long pUserId) {
			vUserId = pUserId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}