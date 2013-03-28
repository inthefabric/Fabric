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
				typeof(Url).Name+"Id:_TP0,"+
				"Name:_TP1,"+
				"AbsoluteUrl:_TP2"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP3);";

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

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewUrlId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vAbsoluteUrl);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", typeof(RootContainsUrl).Name);
		}

	}

}