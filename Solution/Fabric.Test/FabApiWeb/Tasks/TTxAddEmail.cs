using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddEmail : TWebTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=g.addVertex(["+
				typeof(Email).Name+"Id:{{NewEmailId}}L,"+
				"Address:'{{Address}}',"+
				"Created:0L"+
			"]);"+
			"g.addEdge(_V0,_V1,'"+typeof(RootContainsEmail).Name+"');";

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
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<Email> emailVar;

			Tasks.TxAddEmail(MockApiCtx.Object, TxBuild, vAddress, rootVar, out emailVar);
			FinishTx();

			Assert.NotNull(emailVar, "EmailVar should not be null.");
			Assert.AreEqual("_V1", emailVar.Name, "Incorrect EmailVar name.");

			string expect = Query
				.Replace("{{NewEmailId}}", vNewEmailId+"")
				.Replace("{{Address}}", vAddress);
				
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
		}

	}

}