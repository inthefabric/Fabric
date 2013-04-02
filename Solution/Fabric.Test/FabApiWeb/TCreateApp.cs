using System;
using Fabric.Api.Web;
using Fabric.Domain;
using Fabric.Infrastructure;
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
		private Action<IWeaverVarAlias<Member>> vOutSetMemAction;
		private IWeaverVarAlias<Member> vResultMemAlias;
		private App vResultApp;
		private App vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vName = "New Test App";
			vUserId = 987654;

			vOutAppVar = GetTxVar<App>("APP");
			vOutSetMemAction = (x => vResultMemAlias = x);
			IWeaverVarAlias<Member> memVar = new Mock<IWeaverVarAlias<Member>>().Object;

			MockTasks
				.Setup(x => x.TxAddApp(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vName,
						It.IsAny<IWeaverVarAlias<Root>>(),
						vUserId,
						out vOutAppVar,
						out vOutSetMemAction
					)
				);

			MockTasks
				.Setup(x => x.TxAddDataProvMember(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						It.IsAny<IWeaverVarAlias<Root>>(),
						vOutAppVar,
						vUserId,
						out memVar
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
				"g.V('RootId',_TP0)[0].each{_V0=g.v(it)};"+
				"APP;";

			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", 0);
			return vResultApp;
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
			MockValidator.Verify(x => x.UserId(vUserId, CreateApp.UserIdParam), Times.Once());
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
			MockTasks
				.Setup(x => x.GetUser(MockApiCtx.Object, vUserId))
				.Returns((User)null);

			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}

	}

}