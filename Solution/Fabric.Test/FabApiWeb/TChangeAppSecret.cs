using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Domain;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class TChangeAppSecret : TBaseWebFunc {

		private long vAppId;
		private string vCode32;

		private App vResultApp;
		private SuccessResult vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 126264;
			vCode32 = "FakeSecret";
			vResultApp = new App();

			MockApiCtx.SetupGet(x => x.Code32).Returns(vCode32);

			MockTasks
				.Setup(x => x.UpdateAppSecret(MockApiCtx.Object, vAppId, vCode32))
				.Returns(vResultApp);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new ChangeAppSecret(MockTasks.Object, vAppId);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.True(vResult.Success, "Incorrect Result.Success.");

			MockValidator.Verify(x => x.ArtifactId(vAppId, ChangeAppSecret.AppIdParam), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Failure() {
			MockTasks
				.Setup(x => x.UpdateAppSecret(MockApiCtx.Object, vAppId, vCode32))
				.Returns((App)null);

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.False(vResult.Success, "Incorrect Result.Success.");
		}

	}

}