using System;
using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactor : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Factor).Name+"Id',_P0)"+
				".sideEffect{"+
					"it.setProperty('{{PropName}}',_P1)"+
				"};";

		private Factor vFactor;
		private bool vCompleted;
		private bool vDeleted;

		private DateTime vUtcNow;
		private Factor vFactorResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 3456 };
			vCompleted = false;
			vDeleted = false;

			vUtcNow = DateTime.UtcNow;
			vFactorResult = new Factor();

			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			MockApiCtx
				.Setup(x => x.DbSingle<Factor>("UpdateFactor", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetFactor(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Factor GetFactor(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("UpdateFactor");

			string expect = Query
				.Replace("{{PropName}}", (vCompleted ? "Completed" : "Deleted"));

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vFactor.FactorId);
			TestUtil.CheckParam(pQuery.Params, "_P1", vUtcNow.Ticks);

			return vFactorResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, false)]
		[TestCase(false, true)]
		public void Success(bool pCompleted, bool pDeleted) {
			vCompleted = pCompleted;
			vDeleted = pDeleted;

			Factor result = Tasks.UpdateFactor(MockApiCtx.Object, vFactor, vCompleted, vDeleted);

			UsageMap.AssertUses("UpdateFactor", 1);
			Assert.AreEqual(vFactorResult, result, "Incorrect Result.");
		}

	}

}