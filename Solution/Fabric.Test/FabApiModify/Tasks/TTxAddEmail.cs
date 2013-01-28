using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddEmail : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=g.addVertex(["+
				typeof(Email).Name+"Id:0L,"+
				"Address:_TP0,"+
				"Created:0L"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP1);";

		private string vAddress;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAddress = "test@test.com";
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<Email> emailVar;

			Tasks.TxAddEmail(MockApiCtx.Object, TxBuild, vAddress, rootVar, out emailVar);
			FinishTx();

			Assert.NotNull(emailVar, "EmailVar should not be null.");
			Assert.AreEqual("_V1", emailVar.Name, "Incorrect EmailVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vAddress);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", typeof(RootContainsEmail).Name);
		}

	}

}