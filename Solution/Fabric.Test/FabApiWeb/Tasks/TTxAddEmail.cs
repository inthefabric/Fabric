using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddEmail : TWebTasks {

		private static readonly string Query = 
			"_V1=g.addVertex(["+
				typeof(Email).Name+"Id:_TP0,"+
				"Address:_TP1,"+
				"Created:_TP2,"+
				"FabType:_TP3"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP4);";

		private string vAddress;
		private long vNewEmailId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAddress = "test@test.com";
			vNewEmailId = 43562742344;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Email>()).Returns(vNewEmailId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Email> emailVar;

			Tasks.TxAddEmail(MockApiCtx.Object, TxBuild, vAddress, out emailVar);
			FinishTx();

			Assert.NotNull(emailVar, "EmailVar should not be null.");
			Assert.AreEqual("_V1", emailVar.Name, "Incorrect EmailVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewEmailId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vAddress);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", 0);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", (int)NodeFabType.Email);
		}

	}

}