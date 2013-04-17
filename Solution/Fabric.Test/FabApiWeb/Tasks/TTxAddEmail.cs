using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TTxAddEmail : TWebTasks {

		private const string Query = 
			"_V0=g.addVertex(["+
				PropDbName.Email_EmailId+":_TP,"+
				PropDbName.Email_Address+":_TP,"+
				PropDbName.Email_Created+":_TP,"+
				PropDbName.Node_FabType+":_TP"+
			"]);";

		private string vAddress;
		private DateTime vUtcNow;
		private long vNewEmailId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAddress = "test@test.com";
			vUtcNow = DateTime.UtcNow;
			vNewEmailId = 43562742344;

			MockApiCtx.Setup(x => x.GetSharpflakeId<Email>()).Returns(vNewEmailId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void BuildTx() {
			IWeaverVarAlias<Email> emailVar;

			Tasks.TxAddEmail(MockApiCtx.Object, TxBuild, vAddress, out emailVar);
			FinishTx();

			Assert.NotNull(emailVar, "EmailVar should not be null.");
			Assert.AreEqual("_V0", emailVar.Name, "Incorrect EmailVar name.");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, TxBuild.Transaction.Script, "Incorrect Script.");

			TestUtil.CheckParams(TxBuild.Transaction.Params, "_TP", new object[] {
				vNewEmailId,
				vAddress,
				vUtcNow.Ticks,
				(int)NodeFabType.Email
			});
		}

	}

}