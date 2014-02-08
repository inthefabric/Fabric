using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;
using Fabric.New.Operations;
using Fabric.New.Operations.Oauth;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthLogoutOperation {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;
		private Mock<IOauthLogoutTasks> vMockTasks;

		private string vToken;
		private OauthLogoutOperation vOper;
		private FabOauthLogout vExecuteResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockData = new Mock<IOperationData>();

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vMockTasks = new Mock<IOauthLogoutTasks>(MockBehavior.Strict);

			vToken = "12345678ABCDEFGH12345678abcdefgh";

			vOper = new OauthLogoutOperation();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void DoExecute() {
			vExecuteResult = vOper.Execute(vMockOpCtx.Object, vMockTasks.Object, vToken);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			var oa = new OauthAccess();

			vMockTasks
				.Setup(x => x.GetAccessToken(vMockData.Object, vToken))
				.Returns(oa);

			vMockTasks
				.Setup(x => x.DoLogout(vMockData.Object, oa));

			DoExecute();

			Assert.NotNull(vExecuteResult, "Result should be filled.");
			Assert.AreEqual(vToken, vExecuteResult.AccessToken, "Incorrect AccessToken.");
			Assert.AreEqual(1, vExecuteResult.Success, "Incorrect Success.");
		}

	}

}