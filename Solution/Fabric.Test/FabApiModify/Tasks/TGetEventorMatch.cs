using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetEventorMatch : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',0)[0]"+
				".outE('"+typeof(RootContainsEventor).Name+"').inV"+
					".has('DateTime',Tokens.T.eq,{{DateTime}}L)"+
					".as('step4')"+
				".outE('"+typeof(EventorUsesEventorType).Name+"').inV"+
					".has('"+typeof(EventorType).Name+"Id',Tokens.T.eq,{{EveTypeId}}L)"+
				".back('step4')"+
				".outE('"+typeof(EventorUsesEventorPrecision).Name+"').inV"+
					".has('"+typeof(EventorPrecision).Name+"Id',Tokens.T.eq,{{EvePrecId}}L)"+
				".back('step4');";

		private long vEveTypeId;
		private long vEvePrecId;
		private long vDateTime;
		private Eventor vEventorResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vEveTypeId = 9;
			vEvePrecId = 14365126;
			vDateTime = 25795285235275;
			vEventorResult = new Eventor();

			MockApiCtx
				.Setup(x => x.DbSingle<Eventor>("GetEventorMatch", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetEventorMatch(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Eventor GetEventorMatch(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetEventorMatch");

			string expect = Query
				.Replace("{{DateTime}}", vDateTime+"")
				.Replace("{{EveTypeId}}", vEveTypeId+"")
				.Replace("{{EvePrecId}}", vEvePrecId+"");

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

			return vEventorResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Eventor result = Tasks.GetEventorMatch(
				MockApiCtx.Object, vEveTypeId, vEvePrecId, vDateTime);

			UsageMap.AssertUses("GetEventorMatch", 1);
			Assert.AreEqual(vEventorResult, result, "Incorrect Result.");
		}

	}

}