using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	public abstract class TFactorHasElement<T, TRel> : TModifyTasks where T : FactorElementNode {

		private readonly string Query =
			"g.V('"+typeof(Factor).Name+"Id',{{FactorId}}L)[0]."+
				"outE('"+typeof(TRel).Name+"');";

		private long vFactorId;
		private string vFuncName;
		private Mock<IApiDataAccess> vMockDataResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactorId = 3456;
			vFuncName = "FactorHas"+typeof(T).Name;

			vMockDataResult = new Mock<IApiDataAccess>();
			vMockDataResult.Setup(x => x.GetResultCount()).Returns(1);

			MockApiCtx
				.Setup(x => x.DbData(vFuncName, It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => FactorHasElement(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess FactorHasElement(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment(vFuncName);

			string expect = Query.Replace("{{FactorId}}", vFactorId+"");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			return vMockDataResult.Object;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract bool ExecuteTask(IApiContext pApiCtx, Factor pFactor);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Found() {
			bool result = ExecuteTask(MockApiCtx.Object, new Factor { FactorId = vFactorId });

			UsageMap.AssertUses(vFuncName, 1);
			Assert.True(result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			vMockDataResult.Setup(x => x.GetResultCount()).Returns(0);

			bool result = ExecuteTask(MockApiCtx.Object, new Factor { FactorId = vFactorId });

			UsageMap.AssertUses(vFuncName, 1);
			Assert.False(result, "Incorrect Result.");
		}

	}

}