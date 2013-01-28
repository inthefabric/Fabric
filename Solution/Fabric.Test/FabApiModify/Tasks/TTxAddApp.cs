﻿using Fabric.Domain;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddApp : TModifyTasks {

		private static readonly string Query = 
			"_V0=[];"+ //Root
			"_V1=g.V('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
				".outE('"+typeof(UserUsesEmail).Name+"').inV;"+
			"_V2=g.addVertex(["+
				typeof(App).Name+"Id:0L,"+
				"Name:_TP0"+
			"]);"+
			"g.addEdge(_V0,_V2,_TP1);"+
			"g.addEdge(_V2,_V1,_TP2);";

		private string vName;
		private long vUserId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "NewApp";
			vUserId = 9876;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Root> rootVar = GetTxVar<Root>();
			IWeaverVarAlias<App> appVar;

			Tasks.TxAddApp(MockApiCtx.Object, TxBuild, vName, rootVar, vUserId, out appVar);
			FinishTx();

			Assert.NotNull(appVar, "AppVar should not be null.");
			Assert.AreEqual("_V2", appVar.Name, "Incorrect AppVar name.");

			string expect = Query.Replace("{{UserId}}", vUserId+"");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP0", vName);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP1", typeof(RootContainsApp).Name);
			TestUtil.CheckParam(TxBuild.Transaction.Params, "_TP2", typeof(AppUsesEmail).Name);
		}

	}

}