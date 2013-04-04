using System;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddDataProvMember : TWebTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=[];"+ //App
			"_V2=g.addVertex(["+
				typeof(Member).Name+"Id:_TP0"+
			"]);"+
			"g.addEdge(_V0,_V2,_TP1);"+
			"_V3=g.V('"+typeof(User).Name+"Id',_TP2)[0].next();"+
			"g.addEdge(_V3,_V2,_TP3);"+
			"g.addEdge(_V1,_V2,_TP4);"+
			"_V4=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:_TP5,"+
				"Performed:_TP6"+
			"]);"+
			"g.addEdge(_V0,_V4,_TP7);"+
			"_V5=g.V('"+typeof(Member).Name+"Id',_TP8)[0].next();"+
			"g.addEdge(_V5,_V4,_TP9);"+
			"g.addEdge(_V2,_V4,_TP10);"+
			"_V6=g.V('"+typeof(MemberType).Name+"Id',_TP11)[0].next();"+
			"g.addEdge(_V4,_V6,_TP12);";

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
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<App> appVar = GetTxVar<App>();
			IWeaverVarAlias<Member> memberVar;

			Tasks.TxAddDataProvMember(MockApiCtx.Object, TxBuild,
				rootVar, appVar, vUserId, out memberVar);
			FinishTx();

			Assert.NotNull(memberVar, "MemberVar should not be null.");
			Assert.AreEqual("_V2", memberVar.Name, "Incorrect MemberVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewMemberId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", typeof(RootContainsMember).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", vUserId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", typeof(UserDefinesMember).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", typeof(AppDefinesMember).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", vNewMtaId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", vUtcNow.Ticks);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", 
				typeof(RootContainsMemberTypeAssign).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP8",
				(long)SetupUsers.MemberTypeAssignId.FabFabDataBySystem);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP9", 
				typeof(MemberCreatesMemberTypeAssign).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP10", 
				typeof(MemberHasMemberTypeAssign).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP11", (long)MemberTypeId.DataProvider);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP12", 
				typeof(MemberTypeAssignUsesMemberType).Name);
		}

	}

}