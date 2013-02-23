﻿using System;
using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddMember : TWebTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=[];"+ //User
			"_V2=g.addVertex(["+
				typeof(Member).Name+"Id:{{NewMemberId}}L"+
			"]);"+
			"g.addEdge(_V0,_V2,_TP0);"+
			"g.addEdge(_V1,_V2,_TP1);"+
			"g.V('"+typeof(App).Name+"Id',1L)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V3,_V2,_TP2);"+
			"_V4=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:{{NewMtaId}}L,"+
				"Performed:{{UtcNowTicks}}L"+
			"]);"+
			"g.addEdge(_V0,_V4,_TP3);"+
			"g.V('"+typeof(Member).Name+"Id',1L)[0].each{_V5=g.v(it)};"+
			"g.addEdge(_V5,_V4,_TP4);"+
			"g.addEdge(_V2,_V4,_TP5);"+
			"g.V('"+typeof(MemberType).Name+"Id',4L)[0].each{_V6=g.v(it)};"+
			"g.addEdge(_V4,_V6,_TP6);";

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
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<User> userVar = GetTxVar<User>();
			IWeaverVarAlias<Member> memberVar;

			Tasks.TxAddMember(MockApiCtx.Object, TxBuild, rootVar, userVar, out memberVar);
			FinishTx();

			Assert.NotNull(memberVar, "MemberVar should not be null.");
			Assert.AreEqual("_V2", memberVar.Name, "Incorrect MemberVar name.");

			string expect = Query
				.Replace("{{NewMemberId}}", vNewMemberId+"")
				.Replace("{{NewMtaId}}", vNewMtaId+"")
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"");

			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", typeof(RootContainsMember).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", typeof(UserDefinesMember).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", typeof(AppDefinesMember).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP3", 
				typeof(RootContainsMemberTypeAssign).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP4", 
				typeof(MemberCreatesMemberTypeAssign).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP5", 
				typeof(MemberHasMemberTypeAssign).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP6", 
				typeof(MemberTypeAssignUsesMemberType).Name);
		}

	}

}