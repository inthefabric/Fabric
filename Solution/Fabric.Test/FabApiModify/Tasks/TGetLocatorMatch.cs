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
			"g.V('"+typeof(Root).Name+"Id',0)[0]"+
				".outE('"+typeof(RootContainsLocator).Name+"').inV"+
					".has('ValueX',Tokens.T.eq,{{X}}D)"+
					".has('ValueY',Tokens.T.eq,{{Y}}D)"+
					".has('ValueZ',Tokens.T.eq,{{Z}}D)"+
					".as('step6')"+
				".outE('"+typeof(LocatorUsesLocatorType).Name+"').inV"+
					".has('"+typeof(LocatorType).Name+"Id',Tokens.T.eq,{{LocTypeId}}L)"+
				".back('step6');";

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

			string expect = Query
				.Replace("{{LocTypeId}}", vLocTypeId+"")
				.Replace("{{X}}", vValueX+"")
				.Replace("{{Y}}", vValueY+"")
				.Replace("{{Z}}", vValueZ+"");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

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