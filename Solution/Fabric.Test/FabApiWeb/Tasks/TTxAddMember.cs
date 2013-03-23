using System;
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
			"g.addEdge(_V0,_V2,'"+typeof(RootContainsMember).Name+"');"+
			"g.addEdge(_V1,_V2,'"+typeof(UserDefinesMember).Name+"');"+
			"g.V('"+typeof(App).Name+"Id',1L)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V3,_V2,'"+typeof(AppDefinesMember).Name+"');"+
			"_V4=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:{{NewMtaId}}L,"+
				"Performed:{{UtcNowTicks}}L"+
			"]);"+
			"g.addEdge(_V0,_V4,'"+typeof(RootContainsMemberTypeAssign).Name+"');"+
			"g.V('"+typeof(Member).Name+"Id',1L)[0].each{_V5=g.v(it)};"+
			"g.addEdge(_V5,_V4,'"+typeof(MemberCreatesMemberTypeAssign).Name+"');"+
			"g.addEdge(_V2,_V4,'"+typeof(MemberHasMemberTypeAssign).Name+"');"+
			"g.V('"+typeof(MemberType).Name+"Id',4L)[0].each{_V6=g.v(it)};"+
			"g.addEdge(_V4,_V6,'"+typeof(MemberTypeAssignUsesMemberType).Name+"');";

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
		}

	}

}