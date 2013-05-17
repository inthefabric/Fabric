﻿using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetUrlByAbsoluteUrl : TModifyTasks {

		private const string Query =
			"g.V('"+PropDbName.Node_FabType+"',_P0)"+
				".filter{it.getProperty('"+PropDbName.Url_AbsoluteUrl+"').toLowerCase()==_P1};";

		private string vAbsoluteUrl;
		private Url vUrlResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAbsoluteUrl = "http://www.duplicate.com";
			vUrlResult = new Url();

			MockApiCtx
				.Setup(x => x.DbSingle<Url>("GetUrlByAbsoluteUrl", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetUrl(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Url GetUrl(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetUrlByAbsoluteUrl");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", (byte)NodeFabType.Url);
			TestUtil.CheckParam(pQuery.Params, "_P1", vAbsoluteUrl.ToLower());

			return vUrlResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Url result = Tasks.GetUrlByAbsoluteUrl(MockApiCtx.Object, vAbsoluteUrl);

			UsageMap.AssertUses("GetUrlByAbsoluteUrl", 1);
			Assert.AreEqual(vUrlResult, result, "Incorrect Result.");
		}

	}

}