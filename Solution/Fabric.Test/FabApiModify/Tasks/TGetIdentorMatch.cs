using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetIdentorMatch : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Root).Name+"Id',_P0)[0]"+
				".outE('"+typeof(RootContainsIdentor).Name+"').inV"+
					".has('Value',Tokens.T.eq,_P1)"+
					".as('step4')"+
				".outE('"+typeof(IdentorUsesIdentorType).Name+"').inV"+
					".has('"+typeof(IdentorType).Name+"Id',Tokens.T.eq,_P2)"+
				".back('step4');";

		private long vIdenTypeId;
		private string vValue;
		private Identor vIdentorResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vIdenTypeId = 9;
			vValue = "unique id value";
			vIdentorResult = new Identor();

			MockApiCtx
				.Setup(x => x.DbSingle<Identor>("GetIdentorMatch", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetIdentorMatch(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Identor GetIdentorMatch(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetIdentorMatch");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", 0);
			TestUtil.CheckParam(pQuery.Params, "_P1", vValue);
			TestUtil.CheckParam(pQuery.Params, "_P2", vIdenTypeId);

			return vIdentorResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Identor result = Tasks.GetIdentorMatch(MockApiCtx.Object, vIdenTypeId, vValue);

			UsageMap.AssertUses("GetIdentorMatch", 1);
			Assert.AreEqual(vIdentorResult, result, "Incorrect Result.");
		}

	}

}