using Fabric.New.Domain;
using Fabric.New.Operations;
using Fabric.New.Operations.Oauth;
using Fabric.New.Operations.Oauth.Access;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthAccessTasks {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;

		private OauthAccessTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockData = new Mock<IOperationData>();

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vTasks = new OauthAccessTasks();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AssertFault(TestDelegate pDelegate, AccessErrors pError, AccessErrorDescs pDesc) {
			OauthException oe = TestUtil.Throws<OauthException>(pDelegate);

			Assert.NotNull(oe.OauthError, "OauthError should filled.");
			Assert.AreEqual(pError+"", oe.OauthError.Error, "Invalid OauthError.Error");
			Assert.AreEqual(OauthAccessTasks.ErrDescStrings[(int)pDesc]+"",
				oe.OauthError.ErrorDesc, "Invalid OauthError.ErrorDesc");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAppErrBadSecret() {
			const long appId = 1234512523;
			const string secret = "asdugalsdgualsdkgulsdkug";

			vMockData
				.Setup(x => x.Get<App>(It.IsAny<IWeaverQuery>(), "OauthAccess-VerifyApp"))
				.Returns((App)null);

			AssertFault(() => vTasks.GetApp(vMockData.Object, appId, secret),
				AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
		}

	}

}