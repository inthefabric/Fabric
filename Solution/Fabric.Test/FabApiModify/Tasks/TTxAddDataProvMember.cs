using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddDataProvMember : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=[];"+ //App
			"_V2=g.addVertex(["+
				typeof(Member).Name+"Id:0L"+
			"]);"+
			"g.addEdge(_V0,_V2,_TP0);"+
			"g.V('"+typeof(User).Name+"Id',{{UserId}}L)[0].each{_V3=g.v(it)};"+
			"g.addEdge(_V3,_V2,_TP1);"+
			"g.addEdge(_V1,_V2,_TP2);"+
			"_V4=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:0L,"+
				"Performed:0L"+
			"]);"+
			"g.addEdge(_V0,_V4,_TP3);"+
			"g.V('MemberId',1L)[0].each{_V5=g.v(it)};"+
			"g.addEdge(_V5,_V4,_TP4);"+
			"g.addEdge(_V2,_V4,_TP5);"+
			"g.V('"+typeof(MemberType).Name+"Id',8L)[0].each{_V6=g.v(it)};"+
			"g.addEdge(_V4,_V6,_TP6);";

		private long vUserId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vUserId = 2532;
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

			string expect = Query.Replace("{{UserId}}", vUserId+"");
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