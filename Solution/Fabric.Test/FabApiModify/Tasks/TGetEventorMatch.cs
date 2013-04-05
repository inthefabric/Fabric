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
			"g.V('FabType',_P0)[0]"+
				".has('DateTime',Tokens.T.eq,_P1)"+
				".as('step4')"+
			".outE('"+typeof(EventorUsesEventorType).Name+"').inV"+
				".has('"+typeof(EventorType).Name+"Id',Tokens.T.eq,_P2)"+
			".back('step4')"+
			".outE('"+typeof(EventorUsesEventorPrecision).Name+"').inV"+
				".has('"+typeof(EventorPrecision).Name+"Id',Tokens.T.eq,_P3)"+
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

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", (int)NodeFabType.Eventor);
			TestUtil.CheckParam(pQuery.Params, "_P1", vDateTime);
			TestUtil.CheckParam(pQuery.Params, "_P2", vEveTypeId);
			TestUtil.CheckParam(pQuery.Params, "_P3", vEvePrecId);

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