using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddUrl : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=g.addVertex(["+
				typeof(Url).Name+"Id:{{NewUrlId}}L,"+
				"Name:_TP0,"+
				"AbsoluteUrl:_TP1"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP2);";

		private string vAbsoluteUrl;
		private string vName;
		private long vNewUrlId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAbsoluteUrl = "http://www.mywebsite.com";
			vName = "My Web Site";
			vNewUrlId = 79875647;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Url>()).Returns(vNewUrlId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<Url> urlVar;

			Tasks.TxAddUrl(MockApiCtx.Object, TxBuild, vAbsoluteUrl, vName, rootVar, out urlVar);
			FinishTx();

			Assert.NotNull(urlVar, "UrlVar should not be null.");
			Assert.AreEqual("_V1", urlVar.Name, "Incorrect UrlVar name.");

			string expect = Query
				.Replace("{{NewUrlId}}", vNewUrlId+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vAbsoluteUrl);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", typeof(RootContainsUrl).Name);
		}

	}

}