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
	public class TTxAddMember : TWebTasks {

		private static readonly string Query = 
			"_V1=[];"+ //User
			"_V2=g.addVertex(["+
				typeof(Member).Name+"Id:_TP0,"+
				"FabType:_TP1"+
			"]);"+
			"g.addEdge(_V0,_V2,_TP2);"+
			"g.addEdge(_V1,_V2,_TP3);"+
			"_V3=g.V('"+typeof(App).Name+"Id',_TP4)[0].next();"+
			"g.addEdge(_V3,_V2,_TP5);"+
			"_V4=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:_TP6,"+
				"Performed:_TP7,"+
				"FabType:_TP8"+
			"]);"+
			"g.addEdge(_V0,_V4,_TP9);"+
			"_V5=g.V('"+typeof(Member).Name+"Id',_TP10)[0].next();"+
			"g.addEdge(_V5,_V4,_TP11);"+
			"g.addEdge(_V2,_V4,_TP12);"+
			"_V6=g.V('"+typeof(MemberType).Name+"Id',_TP13)[0].next();"+
			"g.addEdge(_V4,_V6,_TP14);";

		private long vNewMemberId;
		private long vNewMtaId;
		private DateTime vUtcNow;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
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
			IWeaverVarAlias<User> userVar = GetTxVar<User>();
			IWeaverVarAlias<Member> memberVar;

			Tasks.TxAddMember(MockApiCtx.Object, TxBuild, userVar, out memberVar);
			FinishTx();

			Assert.NotNull(memberVar, "MemberVar should not be null.");
			Assert.AreEqual("_V2", memberVar.Name, "Incorrect MemberVar name.");

			Assert.AreEqual(Query, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vNewMemberId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", (int)NodeFabType.Member);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", typeof(UserDefinesMember).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", (long)SetupUsers.AppId.FabSys);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", typeof(AppDefinesMember).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", vNewMtaId);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP7", vUtcNow.Ticks);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP8", (int)NodeFabType.MemberTypeAssign);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP10",
				(long)SetupUsers.MemberId.FabFabData);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP11", 
				typeof(MemberCreatesMemberTypeAssign).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP12", 
				typeof(MemberHasMemberTypeAssign).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP13", (long)MemberTypeId.Member);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP14", 
				typeof(MemberTypeAssignUsesMemberType).Name);
		}

	}

}