using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetActiveFactorFromMember : TModifyTasks {

		private const string Query = 
			"g.V('"+PropDbName.Factor_FactorId+"',_P0)"+
				".hasNot('"+PropDbName.Factor_Deleted+"')"+
				".as('step4')"+
			".inE('"+EdgeDbName.MemberCreatesFactor+"').outV"+
				".has('"+PropDbName.Member_MemberId+"',Tokens.T.eq,_P1)"+
			".back('step4');";

		private long vFactorId;
		private long vMemberId;
		private Factor vFactorResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactorId = 3456;
			vMemberId = 43266;
			vFactorResult = new Factor();

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vFactorResult);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			Assert.AreEqual(Query, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vFactorId);
			TestUtil.CheckParam(cmd.Params, "_P1", vMemberId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Factor result = Tasks.GetActiveFactorFromMember(MockApiCtx.Object, vFactorId, vMemberId);

			AssertDataExecution(true);
			Assert.AreEqual(vFactorResult, result, "Incorrect Result.");
		}

	}

}