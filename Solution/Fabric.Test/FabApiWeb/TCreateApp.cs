using System;
using Fabric.Api.Web;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateApp : TBaseWebFunc {

		private string vName;
		private long vUserId;

		private IWeaverVarAlias<App> vOutAppVar;
		private Action<IWeaverVarAlias<Member>> vOutSetMemAction;
		private IWeaverVarAlias<Member> vResultMemAlias;
		private App vResultApp;
		private App vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "New Test App";
			vUserId = 987654;

			vOutAppVar = TestUtil.GetTxVar<App>("APP");
			vOutSetMemAction = (x => vResultMemAlias = x);
			IWeaverVarAlias<Member> memVar = new Mock<IWeaverVarAlias<Member>>().Object;

			MockTasks
				.Setup(x => x.TxAddApp(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vName,
						vUserId,
						out vOutAppVar,
						out vOutSetMemAction
					)
				);

			MockTasks
				.Setup(x => x.TxAddDataProvMember(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vOutAppVar,
						vUserId,
						out memVar
					)
				);

			vResultApp = new App();
			var findUser = new User { ArtifactId = vUserId };
			
			MockApiCtx.SetupGet(x => x.AppId).Returns((long)AppId.FabricSystem);

			var mda = MockDataAccess.Create(x => {});
			mda.MockResult.SetupToElement(findUser);
			MockDataList.Add(mda);
			
			mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vResultApp);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			const string expectPartial = "APP;";
			Assert.AreEqual(expectPartial, cmd.Script, "Incorrect partial script.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateApp(MockTasks.Object, vName, vUserId);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			vResultMemAlias = null;
			TestGo();

			Assert.AreEqual(vResultApp, vResult, "Incorrect Result.");
			Assert.NotNull(vResultMemAlias, "ResultMemAlias should not be null.");

			MockValidator.Verify(x => x.AppName(vName, CreateApp.NameParam), Times.Once());
			MockValidator.Verify(x => x.ArtifactId(vUserId, CreateApp.UserIdParam), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicateApp() {
			MockTasks
				.Setup(x => x.GetAppByName(MockApiCtx.Object, vName))
				.Returns(new App());

			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrUserNotFound() {
			MockDataList[0].MockResult.SetupToElement<User>(null);
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}

	}

}