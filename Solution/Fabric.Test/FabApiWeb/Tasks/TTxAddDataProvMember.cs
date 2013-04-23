using System;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddDataProvMember : TWebTasks {

		private const string Query = 
			"_V0=[];"+ //App
			"_V1=g.addVertex(["+
				PropDbName.Member_MemberId+":_TP,"+
				PropDbName.Node_FabType+":_TP"+
			"]);"+
			"_V2=g.V('"+PropDbName.User_UserId+"',_TP).next();"+
			"g.addEdge(_V2,_V1,_TP);"+
			"g.addEdge(_V0,_V1,_TP);"+
			"_V3=g.addVertex(["+
				PropDbName.MemberTypeAssign_MemberTypeAssignId+":_TP,"+
				PropDbName.MemberTypeAssign_MemberTypeId+":_TP,"+
				PropDbName.NodeForAction_Performed+":_TP,"+
				PropDbName.Node_FabType+":_TP"+
			"]);"+
			"_V4=g.V('"+PropDbName.Member_MemberId+"',_TP).next();"+
			"g.addEdge(_V4,_V3,_TP);"+
			"g.addEdge(_V1,_V3,_TP);";

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
			IWeaverVarAlias<App> appVar = GetTxVar<App>();
			IWeaverVarAlias<Member> memberVar;

			Tasks.TxAddDataProvMember(MockApiCtx.Object, TxBuild, appVar, vUserId, out memberVar);
			FinishTx();

			Assert.NotNull(memberVar, "MemberVar should not be null.");
			Assert.AreEqual("_V1", memberVar.Name, "Incorrect MemberVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vNewMemberId,
				(int)NodeFabType.Member,
				vUserId,
				RelDbName.UserDefinesMember,
				RelDbName.AppDefinesMember,
				vNewMtaId,
				(long)MemberTypeId.DataProvider,
				vUtcNow.Ticks,
				(int)NodeFabType.MemberTypeAssign,
				(long)SetupUsers.MemberTypeAssignId.FabFabDataBySystem,
				RelDbName.MemberCreatesMemberTypeAssign,
				RelDbName.MemberHasMemberTypeAssign
			});
		}

	}

}