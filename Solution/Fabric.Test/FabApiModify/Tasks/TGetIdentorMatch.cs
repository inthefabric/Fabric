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
			"g.V('"+typeof(Root).Name+"Id',0)[0]"+
				".outE('"+typeof(RootContainsIdentor).Name+"').inV"+
					".has('Value',Tokens.T.eq,'{{IdenValue}}')"+
					".as('step4')"+
				".outE('"+typeof(IdentorUsesIdentorType).Name+"').inV"+
					".has('"+typeof(IdentorType).Name+"Id',Tokens.T.eq,{{IdenTypeId}}L)"+
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

			string expect = Query
				.Replace("{{IdenTypeId}}", vIdenTypeId+"")
				.Replace("{{IdenValue}}", vValue);

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

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