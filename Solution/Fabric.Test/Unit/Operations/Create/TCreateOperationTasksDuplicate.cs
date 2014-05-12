using System;
using Fabric.Domain;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Broadcast;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Faults;
using Fabric.Operations.Create;
using Fabric.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public class TCreateOperationTasksDuplicate {

		private static readonly Logger Log = Logger.Build<TCreateOperationTasksDuplicate>();
		private const string Prefix = "_P";
		private const string DupVar = "d";

		private Mock<ICreateOperationBuilder> vMockBuild;
		private CreateOperationTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockBuild = new Mock<ICreateOperationBuilder>(MockBehavior.Strict);
			vMockBuild.Setup(x => x.GetNextAliasName()).Returns(DupVar);

			vTasks = new CreateOperationTasks();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void TestFindDuplicate(Mock<ICreateOperationBuilder> pMockCreCtx,
													Action<ICreateOperationBuilder> pFind,
													string pScript, string pAppend, object[] pParams) {
			const string cmdId = "1234";
			const bool cache = true;
			const bool omit = false;
			const bool cond = true;

			pMockCreCtx
				.Setup(x => x.AddQuery(It.IsAny<IWeaverQuery>(), cache, It.IsAny<string>()))
				.Callback((IWeaverQuery q, bool c, string a) => {
					TestUtil.LogWeaverScript(Log, q);
					string s = TestUtil.InsertParamIndexes(pScript, Prefix);
					Assert.AreEqual(s, q.Script, "Incorrect script.");
					Assert.AreEqual(pAppend, a, "Incorrect append script.");
					TestUtil.CheckParams(q.Params, Prefix, pParams);
				});

			pMockCreCtx
				.Setup(x => x.SetupLatestCommand(omit, cond))
				.Returns(cmdId);

			pMockCreCtx
				.Setup(x => x.AddCheck(It.IsAny<IDataResultCheck>()))
				.Callback((IDataResultCheck c) => {
					Assert.AreEqual(cmdId, c.CommandId, "Incorrect DataResultCheck.CommandId.");

					const int i = 999;

					var mockRes = new Mock<IDataResult>(MockBehavior.Strict);
					mockRes.Setup(x => x.GetCommandIndexByCmdId(c.CommandId)).Returns(i);

					Log.Debug("Append passing DataResultCheck...");
					mockRes.Setup(x => x.ToIntAt(i, 0)).Returns(1);
					TestUtil.CheckThrows<FabDuplicateFault>(false,
						() => c.PerformCheck(mockRes.Object));

					Log.Debug("Append failing DataResultCheck...");
					mockRes.Setup(x => x.ToIntAt(i, 0)).Returns(0);
					TestUtil.CheckThrows<FabDuplicateFault>(true,
						() => c.PerformCheck(mockRes.Object));
				});

			pFind(pMockCreCtx.Object);

			pMockCreCtx
				.Verify(x => x.AddQuery(
				It.IsAny<IWeaverQuery>(), It.IsAny<bool>(), It.IsAny<string>()), Times.Once);

			pMockCreCtx
				.Verify(x => x.SetupLatestCommand(It.IsAny<bool>(), It.IsAny<bool>()), Times.Once);

			pMockCreCtx
				.Verify(x => x.AddCheck(It.IsAny<IDataResultCheck>()), Times.Once);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestFindDuplicate(
								Action<ICreateOperationBuilder> pFind, string pProp, object[] pParams) {
			TestFindDuplicate(vMockBuild, pFind, DupVar+"=g.V('"+pProp+"',_P);",
				DupVar+"?0:1;", pParams);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FindDuplicateAppNameKey() {
			var app = new App { NameKey = "This is my NameKey" };

			TestFindDuplicate(
				x => vTasks.FindDuplicateAppNameKey(x, app),
				DbName.Vert.App.NameKey,
				new object[] { app.NameKey }
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FindDuplicateUrlFullPath() {
			var url = new Url { FullPath = "http://www.TEST.com" };

			TestFindDuplicate(
				x => vTasks.FindDuplicateUrlFullPath(x, url),
				DbName.Vert.Url.FullPath,
				new object[] { url.FullPath }
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void FindDuplicateUserNameKey() {
			var user = new User { NameKey = "This is my NameKey" };

			TestFindDuplicate(
				x => vTasks.FindDuplicateUserNameKey(x, user),
				DbName.Vert.User.NameKey,
				new object[] { user.NameKey }
			);
		}

	}

}