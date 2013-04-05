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
			"g.V('"+typeof(Factor).Name+"Id',_P0)"+
			".outE('"+typeof(TRel).Name+"');";

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

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vFactorId);

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