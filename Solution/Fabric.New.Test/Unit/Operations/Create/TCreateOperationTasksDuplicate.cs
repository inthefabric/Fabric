using System;
using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public class TCreateOperationTasksDuplicate {

		private static readonly Logger Log = Logger.Build<TCreateOperationTasksDuplicate>();
		private const string Prefix = "_P";

		private Mock<ICreateOperationContext> vMockCreCtx;
		private CreateOperationTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockCreCtx = new Mock<ICreateOperationContext>();
			vTasks = new CreateOperationTasks();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void TestFindDuplicate(
								Action<ICreateOperationContext> pFind, string pProp, object[] pParams) {
			string script = "unq=g.V('"+pProp+"',_P);";
			const string append = "unq?0:1;";
			const string cmdId = "1234";
			const bool cache = true;
			const bool omit = false;
			const bool cond = true;

			vMockCreCtx
				.Setup(x => x.AddQuery(It.IsAny<IWeaverQuery>(), cache, It.IsAny<string>()))
				.Callback((IWeaverQuery q, bool c, string a) => {
					TestUtil.LogWeaverScript(Log, q);
					string s = TestUtil.InsertParamIndexes(script, Prefix);
					Assert.AreEqual(s, q.Script, "Incorrect script.");
					Assert.AreEqual(append, a, "Incorrect append script.");
					TestUtil.CheckParams(q.Params, Prefix, pParams);
				});

			vMockCreCtx
				.Setup(x => x.SetupLatestCommand(omit, cond))
				.Returns(cmdId);

			vMockCreCtx
				.Setup(x => x.AddCheck(It.IsAny<DataResultCheck>()))
				.Callback((DataResultCheck c) => {
					Assert.AreEqual(cmdId, c.CommandId, "Incorrect DataResultCheck.CommandId.");

					const int i = 999;

					var mockRes = new Mock<IDataResult>();
					mockRes.Setup(x => x.GetCommandIndexByCmdId(c.CommandId)).Returns(i);

					Log.Debug("Append passing DataResultCheck...");
					mockRes.Setup(x => x.ToIntAt(i, 0)).Returns(0);
					TestUtil.CheckThrows<FabDuplicateFault>(false,
						() => c.PerformCheck(mockRes.Object));

					Log.Debug("Append failing DataResultCheck...");
					mockRes.Setup(x => x.ToIntAt(i, 0)).Returns(1);
					TestUtil.CheckThrows<FabDuplicateFault>(true,
						() => c.PerformCheck(mockRes.Object));
				});

			pFind(vMockCreCtx.Object);

			vMockCreCtx
				.Verify(x => x.AddQuery(
				It.IsAny<IWeaverQuery>(), It.IsAny<bool>(), It.IsAny<string>()), Times.Once);

			vMockCreCtx
				.Verify(x => x.SetupLatestCommand(It.IsAny<bool>(), It.IsAny<bool>()), Times.Once);

			vMockCreCtx
				.Verify(x => x.AddCheck(It.IsAny<DataResultCheck>()), Times.Once);
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