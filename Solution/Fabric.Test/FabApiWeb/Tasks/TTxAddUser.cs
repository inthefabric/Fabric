using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddUser : TWebTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=[];"+ //Email
			"_V2=g.addVertex(["+
				typeof(User).Name+"Id:{{NewUserId}}L,"+
				"Name:'{{Name}}',"+
				"Password:'{{Password}}'"+
			"]);"+
			"g.addEdge(_V0,_V2,'"+typeof(RootContainsUser).Name+"');"+
			"g.addEdge(_V2,_V1,'"+typeof(UserUsesEmail).Name+"');";

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
				.Replace("{{NewUserId}}", vNewUserId+"")
				.Replace("{{Name}}", vName)
				.Replace("{{Password}}", FabricUtil.HashPassword(vPassword));

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
		}

	}

}