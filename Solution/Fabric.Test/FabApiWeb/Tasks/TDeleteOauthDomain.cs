﻿using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TDeleteOauthDomain : TWebTasks {

		private static readonly string Query =
			"g.V('"+typeof(App).Name+"Id',_P0)[0]"+
			".inE('"+typeof(OauthDomainUsesApp).Name+"').outV"+
				".has('"+typeof(OauthDomain).Name+"Id',Tokens.T.eq,_P1)"+
				".remove();";

		private long vAppId;
		private long vOauthDomainId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 3456;
			vOauthDomainId = 842645;

			MockApiCtx
				.Setup(x => x.DbData("DeleteOauthDomain", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => DeleteOauthDomain(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess DeleteOauthDomain(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("DeleteOauthDomain");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vAppId);
			TestUtil.CheckParam(pQuery.Params, "_P1", vOauthDomainId);
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			bool result = Tasks.DeleteOauthDomain(MockApiCtx.Object, vAppId, vOauthDomainId);

			UsageMap.AssertUses("DeleteOauthDomain", 1);
			Assert.True(result, "Incorrect Result.");
		}

	}

}