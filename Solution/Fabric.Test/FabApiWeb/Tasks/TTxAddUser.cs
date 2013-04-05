using System;
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
			"_V1=[];"+ //Email
			"_V2=[];"+ //Member
			"_V3=g.addVertex(["+
				typeof(User).Name+"Id:_TP0,"+
				"Name:_TP1,"+
				"Password:_TP2,"+
				"ArtifactId:_TP3,"+
				"Created:_TP4,"+
				"FabType:_TP5"+
			"]);"+
			"g.addEdge(_V0,_V3,_TP6);"+
			"g.addEdge(_V3,_V1,_TP7);"+
			"g.addEdge(_V2,_V3,_TP8);";

		private string vName;
		private string vPassword;
		private long vNewUserId;
		private long vNewArtifactId;
		private DateTime vUtcNow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "NewUser";
			vPassword = "TestPassword";
			vNewUserId = 346137173314;
			vNewArtifactId = 27357427;
			vUtcNow = DateTime.UtcNow;

			MockApiCtx.Setup(x => x.GetSharpflakeId<User>()).Returns(vNewUserId);
			MockApiCtx.Setup(x => x.GetSharpflakeId<Artifact>()).Returns(vNewArtifactId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Email> emailVar = GetTxVar<Email>();
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>();
			IWeaverVarAlias<User> userVar;
			Action<IWeaverVarAlias<Member>> setMem;

			Tasks.TxAddUser(MockApiCtx.Object, TxBuild,
				vName, vPassword, emailVar, out userVar, out setMem);
			setMem(memVar);
			FinishTx();

			Assert.NotNull(userVar, "UserVar should not be null.");
			Assert.AreEqual("_V3", userVar.Name, "Incorrect UserVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewUserId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", FabricUtil.HashPassword(vPassword));
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", vNewArtifactId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", vUtcNow.Ticks);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", (int)NodeFabType.User);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", typeof(UserUsesEmail).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP8", typeof(MemberCreatesArtifact).Name);
		}

	}

}