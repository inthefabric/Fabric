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
	public class TGetMemberOfApp : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
			".outE('"+EdgeDbName.AppDefinesMember+"').inV"+
				".has('"+PropDbName.Member_MemberId+"',Tokens.T.eq,_P1);";

		private long vAppId;
		private long vMemberId;
		private Member vMemberResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 3456;
			vMemberId = 438643;
			vMemberResult = new Member();

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vMemberResult);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			
			Assert.AreEqual(Query, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vAppId);
			TestUtil.CheckParam(cmd.Params, "_P1", vMemberId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Member result = Tasks.GetMemberOfApp(MockApiCtx.Object, vAppId, vMemberId);

			AssertDataExecution(true);
			Assert.AreEqual(vMemberResult, result, "Incorrect Result.");
		}

	}

}