using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactor : TModifyTasks {

		private const string Query = 
			"g.V('"+PropDbName.Factor_FactorId+"',_P0)"+
				".sideEffect{"+
					"it.setProperty('{{PropName}}',_P1);"+
				"};";

		private Factor vFactor;
		private bool vCompleted;
		private bool vDeleted;

		private DateTime vUtcNow;
		private Factor vFactorResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 3456 };
			vCompleted = false;
			vDeleted = false;

			vUtcNow = DateTime.UtcNow;
			vFactorResult = new Factor();

			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vFactorResult);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			string expect = Query
				.Replace("{{PropName}}", 
					(vCompleted ? PropDbName.Factor_Completed : PropDbName.Factor_Deleted));

			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vFactor.FactorId);
			TestUtil.CheckParam(cmd.Params, "_P1", vUtcNow.Ticks);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, false)]
		[TestCase(false, true)]
		public void Success(bool pCompleted, bool pDeleted) {
			vCompleted = pCompleted;
			vDeleted = pDeleted;

			Factor result = Tasks.UpdateFactor(MockApiCtx.Object, vFactor, vCompleted, vDeleted);

			AssertDataExecution(true);
			Assert.AreEqual(vFactorResult, result, "Incorrect Result.");
		}

	}

}