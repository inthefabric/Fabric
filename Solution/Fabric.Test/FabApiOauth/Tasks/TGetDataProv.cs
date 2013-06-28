using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;
using Fabric.Test.Common;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetDataProv : TTestBase {

		private const string QueryGetUser =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
				".as('step3')"+
			".outE('"+EdgeDbName.UserDefinesMember+"').inV"+
				".as('step6')"+
			".inE('"+EdgeDbName.AppDefinesMember+"').outV"+
				".has('"+PropDbName.Artifact_ArtifactId+"',Tokens.T.eq,_P1)"+
			".back('step6')"+
			".outE('"+EdgeDbName.MemberHasMemberTypeAssign+"').inV"+
				".has('"+PropDbName.MemberTypeAssign_MemberTypeId+"',Tokens.T.eq,_P2)"+
			".back('step3');";

		private long vAppId;
		private long vDataProvUserId;
		private User vGetUserResult;

				
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 23525;
			vDataProvUserId = 3875;

			vGetUserResult = new User();

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vGetUserResult);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private User TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetDataProv(vAppId, vDataProvUserId, MockApiCtx.Object);
			}

			var task = new GetDataProv(vAppId, vDataProvUserId);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			Assert.AreEqual(QueryGetUser, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vDataProvUserId);
			TestUtil.CheckParam(cmd.Params, "_P1", vAppId);
			TestUtil.CheckParam(cmd.Params, "_P2", (long)MemberTypeId.DataProvider);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			User result = TestGo(pViaTask);

			AssertDataExecution(true);
			Assert.AreEqual(vGetUserResult, result, "Incorrect Result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidDataProvUserId() {
			vDataProvUserId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

	}

}