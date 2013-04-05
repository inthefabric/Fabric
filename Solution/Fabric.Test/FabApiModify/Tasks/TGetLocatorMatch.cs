using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetLocatorMatch : TModifyTasks {

		private static readonly string Query = 
			"g.V('FabType',_P)[0]"+
				".has('ValueX',Tokens.T.eq,_P)"+
				".has('ValueY',Tokens.T.eq,_P)"+
				".has('ValueZ',Tokens.T.eq,_P)"+
				".as('step4')"+
			".outE('"+typeof(LocatorUsesLocatorType).Name+"').inV"+
				".has('"+typeof(LocatorType).Name+"Id',Tokens.T.eq,_P)"+
			".back('step4');";

		private long vLocTypeId;
		private double vValueX;
		private double vValueY;
		private double vValueZ;
		private Locator vLocatorResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vLocTypeId = 9;
			vValueX = 1.34236;
			vValueY = 99.52352;
			vValueZ = 37.023983;
			vLocatorResult = new Locator();

			MockApiCtx
				.Setup(x => x.DbSingle<Locator>("GetLocatorMatch", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetLocatorMatch(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Locator GetLocatorMatch(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetLocatorMatch");

			string expect = TestUtil.InsertParamIndexes(Query, "_P");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pQuery.Params, "_P", new object[] {
				(int)NodeFabType.Locator,
				vValueX,
				vValueY,
				vValueZ,
				vLocTypeId
			});

			return vLocatorResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Locator result = Tasks.GetLocatorMatch(MockApiCtx.Object,
				vLocTypeId, vValueX, vValueY, vValueZ);

			UsageMap.AssertUses("GetLocatorMatch", 1);
			Assert.AreEqual(vLocatorResult, result, "Incorrect Result.");
		}

	}

}