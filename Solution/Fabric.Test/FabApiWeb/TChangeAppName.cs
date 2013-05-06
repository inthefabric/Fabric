using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class TChangeAppName : TBaseWebFunc {

		private long vAppId;
		private string vName;

		private App vResultApp;
		private SuccessResult vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 126264;
			vName = "New App Name";
			vResultApp = new App();

			MockTasks
				.Setup(x => x.GetAppByName(MockApiCtx.Object, vName))
				.Returns((App)null);

			MockTasks
				.Setup(x => x.UpdateAppName(MockApiCtx.Object, vAppId, vName))
				.Returns(vResultApp);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new ChangeAppName(MockTasks.Object, vAppId, vName);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.True(vResult.Success, "Incorrect Result.Success.");

			MockValidator.Verify(x => x.ArtifactId(vAppId, ChangeAppName.AppIdParam), Times.Once());
			MockValidator.Verify(x => x.AppName(vName, ChangeAppName.NameParam), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Failure() {
			MockTasks
				.Setup(x => x.UpdateAppName(MockApiCtx.Object, vAppId, vName))
				.Returns((App)null);

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.False(vResult.Success, "Incorrect Result.Success.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicateName() {
			MockTasks
				.Setup(x => x.GetAppByName(MockApiCtx.Object, vName))
				.Returns(new App());

			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}

	}

}