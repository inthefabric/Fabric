using System;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddDataProvMember : TWebTasks {

		private const string Query = 
			"_V0=[];"+ //App
			"_V1=g.addVertex(["+
				PropDbName.Member_MemberId+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_V2=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"_PROP=[:];"+
			"g.addEdge(_V2,_V1,_TP,_PROP);"+
			"_PROP=[:];"+
			"g.addEdge(_V0,_V1,_TP,_PROP);"+
			"_V3=g.addVertex(["+
				PropDbName.MemberTypeAssign_MemberTypeAssignId+":_TP,"+
				PropDbName.MemberTypeAssign_MemberTypeId+":_TP,"+
				PropDbName.VertexForAction_Performed+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_V4=g.V('"+PropDbName.Member_MemberId+"',_TP).next();"+
			"_PROP=[:];"+
			"g.addEdge(_V4,_V3,_TP,_PROP);"+
			"_PROP=[:];"+
			"g.addEdge(_V1,_V3,_TP,_PROP);";

		private long vUserId;
		private long vNewMemberId;
		private long vNewMtaId;
		private DateTime vUtcNow;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vUserId = 2532;
			vNewMemberId = 43562742344;
			vNewMtaId = 346137173314;
			vUtcNow = DateTime.UtcNow;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Member>()).Returns(vNewMemberId);
			MockApiCtx.Setup(x => x.GetSharpflakeId<MemberTypeAssign>()).Returns(vNewMtaId);
			MockApiCtx.Setup(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<App> appVar = GetTxVar<App>("_V0");
			IWeaverVarAlias<Member> memberVar;

			Tasks.TxAddDataProvMember(MockApiCtx.Object, TxBuild, appVar, vUserId, out memberVar);
			FinishTx();

			Assert.NotNull(memberVar, "MemberVar should not be null.");
			Assert.AreEqual("_V1", memberVar.Name, "Incorrect MemberVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vNewMemberId,
				(byte)VertexFabType.Member,
				vUserId,
				EdgeDbName.UserDefinesMember,
				EdgeDbName.AppDefinesMember,
				vNewMtaId,
				(long)MemberTypeId.DataProvider,
				vUtcNow.Ticks,
				(byte)VertexFabType.MemberTypeAssign,
				(long)SetupUsers.MemberTypeAssignId.FabFabDataBySystem,
				EdgeDbName.MemberCreatesMemberTypeAssign,
				EdgeDbName.MemberHasMemberTypeAssign
			});
		}

	}

}