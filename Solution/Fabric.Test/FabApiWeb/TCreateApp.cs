using Fabric.Api.Web;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateApp : TBaseWebFunc {

		private string vName;
		private long vUserId;

		private IWeaverVarAlias<App> vOutAppVar;
		private App vResultApp;
		private App vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "New Test App";
			vUserId = 987654;

			vOutAppVar = GetTxVar<App>("APP");

			MockTasks
				.Setup(x => x.TxAddApp(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vName,
						It.IsAny<IWeaverVarAlias<Root>>(),
						vUserId,
						out vOutAppVar
					)
				);

			vResultApp = new App();
			var findUser = new User { UserId = vUserId };

			MockTasks
				.Setup(x => x.GetUser(MockApiCtx.Object, vUserId))
				.Returns(findUser);
			
			MockApiCtx.SetupGet(x => x.AppId).Returns((long)AppId.FabricSystem);

			MockApiCtx
				.Setup(x => x.DbSingle<App>("CreateAppTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateAppTx(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private App CreateAppTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			const string expectPartial = 
				"g.V('RootId',0)[0].each{_V0=g.v(it)};"+
				"APP;";

			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			return vResultApp;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateApp(MockTasks.Object, MockModTasks.Object, vName, vUserId);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			TestGo();

			Assert.AreEqual(vResultApp, vResult, "Incorrect Result.");

			MockValidator.Verify(x => x.AppName(vName, CreateApp.NameParam), Times.Once());
			MockValidator.Verify(x => x.UserId(vUserId, CreateApp.UserIdParam), Times.Once());

			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Artifact> artVar;

			MockTasks
				.Verify(x => x.TxAddDataProvMember(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						It.IsAny<IWeaverVarAlias<Root>>(),
						vOutAppVar,
						vUserId,
						out memVar
					),
					Times.Once()
				);

			MockModTasks
				.Verify(x => x.TxAddArtifact<App, AppHasArtifact>(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						ArtifactTypeId.App,
						It.IsAny<IWeaverVarAlias<Root>>(),
						vOutAppVar,
						It.IsAny<IWeaverVarAlias<Member>>(),
						out artVar
					),
					Times.Once()
				);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(2)]
		public void ErrAppPrevented(long pAppId) {
			MockApiCtx.SetupGet(x => x.AppId).Returns(pAppId);
			TestUtil.CheckThrows<FabPreventedFault>(true, TestGo);
		}
		
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
			MockTasks
				.Setup(x => x.GetUser(MockApiCtx.Object, vUserId))
				.Returns((User)null);

			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}

	}

}