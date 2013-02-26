using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class TRemoveOauthDomain : TBaseWebFunc {

		private long vAppId;
		private long vOauthDomainId;

		private SuccessResult vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 126264;
			vOauthDomainId = 4362346;

			MockTasks
				.Setup(x => x.DeleteOauthDomain(MockApiCtx.Object, vAppId, vOauthDomainId))
				.Returns(true);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new RemoveOauthDomain(MockTasks.Object, vAppId, vOauthDomainId);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.True(vResult.Success, "Incorrect result.");

			MockValidator.Verify(x => x.AppId(vAppId, RemoveOauthDomain.AppIdParam), Times.Once());
			MockValidator.Verify(x => x.OauthDomainId(vOauthDomainId,
				RemoveOauthDomain.OauthDomainIdParam), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Failure() {
			MockTasks
				.Setup(x => x.DeleteOauthDomain(MockApiCtx.Object, vAppId, vOauthDomainId))
				.Returns(false);

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.False(vResult.Success, "Incorrect result.");
		}

	}

}