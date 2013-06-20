using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetClassByNameDisamb : TModifyTasks {

		private const string QueryStart = "g.V('"+PropDbName.Class_NameKey+"',_P0).scatter()";

		private const string QueryNoDisamb = QueryStart+
			".hasNot('"+PropDbName.Class_Disamb+"');";

		private const string QueryDisamb = QueryStart+
			".filter{"+
				"_DI=it.getProperty('"+PropDbName.Class_Disamb+"');"+
				"(_DI && _DI.toLowerCase()==_P1);"+
			"};";

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
				.Returns((string s, IWeaverQuery tx) => GetClass(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Class GetClass(IWeaverQuery pTx) {
			TestUtil.LogWeaverScript(pTx);
			UsageMap.Increment("GetClassByNameDisamb");

			string expect = (vDisamb != null ? QueryDisamb : QueryNoDisamb);

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_P0", vName.ToLower());

			if ( vDisamb != null ) {
				TestUtil.CheckParam(pTx.Params, "_P1", vDisamb.ToLower());
			}

			return vClassResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pNullDisamb) {
			if ( pNullDisamb ) {
				vDisamb = null;
			}

			Class result = Tasks.GetClassByNameDisamb(MockApiCtx.Object, vName, vDisamb);

			UsageMap.AssertUses("GetClassByNameDisamb", 1);
			Assert.AreEqual(vClassResult, result, "Incorrect Result.");
		}

	}

}