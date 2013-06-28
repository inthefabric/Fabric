using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;
using Fabric.Test.Common;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetMemberTypeAssignByMember : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.Member_MemberId+"',_P0)"+
			".outE('"+EdgeDbName.MemberHasMemberTypeAssign+"').inV;";

		private long vMemberId;
		private MemberTypeAssign vMtaResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vMemberId = 43864313;
			vMtaResult = new MemberTypeAssign();

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vMtaResult);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			Assert.AreEqual(Query, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vMemberId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			MemberTypeAssign result = Tasks.GetMemberTypeAssignByMember(MockApiCtx.Object, vMemberId);

			AssertDataExecution(true);
			Assert.AreEqual(vMtaResult, result, "Incorrect Result.");
		}

	}

}