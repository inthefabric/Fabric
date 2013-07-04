using System;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddUser : TWebTasks {

		private const string Query = 
			"_V0=[];"+ //Email
			"_V1=[];"+ //Member
			"_V2=g.addVertex(["+
				PropDbName.User_Name+":_TP,"+
				PropDbName.User_NameKey+":_TP,"+
				PropDbName.User_Password+":_TP,"+
				PropDbName.Artifact_ArtifactId+":_TP,"+
				PropDbName.Artifact_Created+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_PROP=[:];"+
			"g.addEdge(_V2,_V0,_TP,_PROP);"+
			"_PROP=[:];"+
			"_TRY=[A_Cr:_V2];"+
			TestUtil.TryPropScript+
			"g.addEdge(_V1,_V2,_TP,_PROP);";

		private string vName;
		private string vPassword;
		private long vNewArtifactId;
		private DateTime vUtcNow;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "NewUser";
			vPassword = "TestPassword";
			vNewArtifactId = 27357427;
			vUtcNow = DateTime.UtcNow;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Artifact>()).Returns(vNewArtifactId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Email> emailVar = GetTxVar<Email>("_V0");
			IWeaverVarAlias<Member> memVar = GetTxVar<Member>("_V1");
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
				vName,
				vName.ToLower(),
				FabricUtil.HashPassword(vPassword),
				vNewArtifactId,
				vUtcNow.Ticks,
				(byte)VertexFabType.User,
				EdgeDbName.UserUsesEmail,
				EdgeDbName.MemberCreatesArtifact
			});
		}

	}

}