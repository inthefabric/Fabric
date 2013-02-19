using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Test.FabApiModify.Tasks;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddUser : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=[];"+ //Email
			"_V2=g.addVertex(["+
				typeof(User).Name+"Id:{{NewUserId}}L,"+
				"Name:_TP0,"+
				"Password:_TP1"+
			"]);"+
			"g.addEdge(_V0,_V2,_TP2);"+
			"g.addEdge(_V2,_V1,_TP3);";

		private string vName;
		private string vPassword;
		private long vNewUserId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "NewUser";
			vPassword = "TestPassword";
			vNewUserId = 346137173314;

			MockApiCtx.Setup(x => x.GetSharpflakeId<User>()).Returns(vNewUserId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<Email> emailVar = GetTxVar<Email>();
			IWeaverVarAlias<User> userVar;

			Tasks.TxAddUser(MockApiCtx.Object, TxBuild,
				vName, vPassword, rootVar, emailVar, out userVar);
			FinishTx();

			Assert.NotNull(userVar, "UserVar should not be null.");
			Assert.AreEqual("_V2", userVar.Name, "Incorrect UserVar name.");

			string expect = Query
				.Replace("{{NewUserId}}", vNewUserId+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", FabricUtil.HashPassword(vPassword));
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", typeof(RootContainsUser).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", typeof(UserUsesEmail).Name);
		}

	}

}