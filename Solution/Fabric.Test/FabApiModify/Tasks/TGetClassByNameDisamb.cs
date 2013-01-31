using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetClassByNameDisamb : TModifyTasks {

		private readonly static string QueryStart =
			"g.V('RootId',0)[0]"+
				".outE('"+typeof(RootContainsClass).Name+"').inV"+
				".filter{it.getProperty('Name').toLowerCase()==NAME}";

		private readonly static string QueryNoDisamb = QueryStart+";";

		private readonly static string Query = QueryStart+
				".filter{it.getProperty('Disamb').toLowerCase()==DISAMB};";

		private string vName;
		private string vDisamb;
		private Class vClassResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "My Class";
			vDisamb = "The awesome version";
			vClassResult = new Class();

			MockApiCtx
				.Setup(x => x.DbSingle<Class>("GetClassByNameDisamb", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetClass(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Class GetClass(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetClassByNameDisamb");

			string expect = Query;

			if ( vDisamb == null ) {
				expect = QueryNoDisamb;
			}

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "NAME", vName.ToLower());

			if ( vDisamb != null ) {
				TestUtil.CheckParam(pQuery.Params, "DISAMB", vDisamb.ToLower());
			}

			return vClassResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			UsageMap.AssertUses("GetClassByNameDisamb", 1);
			Assert.AreEqual(vClassResult, result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessNoDisamb() {
			vDisamb = null;
			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			UsageMap.AssertUses("GetClassByNameDisamb", 1);
			Assert.AreEqual(vClassResult, result, "Incorrect Result.");
		}

	}

}