﻿using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateAppSecret : TWebTasks {

		private static readonly string Query =
			"g.V('"+typeof(App).Name+"Id',{{AppId}}L)[0]"+
				".sideEffect{it.setProperty('Secret',_P0)};";

		private long vAppId;
		private string vSecret;
		private App vAppResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 3456;
			vSecret = "abcdefgHIJKLMNOPqrsTUVwxyz12345678";
			vAppResult = new App();

			MockApiCtx
				.Setup(x => x.DbSingle<App>("UpdateAppSecret", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => UpdateAppSecret(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private App UpdateAppSecret(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("UpdateAppSecret");

			string expect = Query.Replace("{{AppId}}", vAppId+"");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vSecret);

			return vAppResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			App result = Tasks.UpdateAppSecret(MockApiCtx.Object, vAppId, vSecret);

			UsageMap.AssertUses("UpdateAppSecret", 1);
			Assert.AreEqual(vAppResult, result, "Incorrect Result.");
		}

	}

}