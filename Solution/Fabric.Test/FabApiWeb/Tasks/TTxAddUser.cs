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
			"_V0=[];"+ //Email
			"_V1=[];"+ //Member
			"_V2=g.addVertex(["+
				typeof(User).Name+"Id:_TP,"+
				"Name:_TP,"+
				"Password:_TP,"+
				"ArtifactId:_TP,"+
				"Created:_TP,"+
				"FabType:_TP"+
			"]);"+
			"g.addEdge(_V2,_V0,_TP);"+
			"g.addEdge(_V1,_V2,_TP);";

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
			Assert.AreEqual("_V2", userVar.Name, "Incorrect UserVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vNewUserId,
				vName,
				FabricUtil.HashPassword(vPassword),
				vNewArtifactId,
				vUtcNow.Ticks,
				(int)NodeFabType.User,
				typeof(UserUsesEmail).Name,
				typeof(MemberCreatesArtifact).Name
			});
		}

	}

}