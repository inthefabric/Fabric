using System.Collections.Generic;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Operations.Create;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateOperationBuilder {

		private const string LatestCmdId = "12345";

		private Mock<IDataAccess> vMockDataAcc;
		private CreateOperationBuilder vCreCtx;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockDataAcc = new Mock<IDataAccess>(); //does not need MockBehavior.Strict
			vMockDataAcc.Setup(x => x.GetLatestCommandId()).Returns(LatestCmdId);

			vCreCtx = new CreateOperationBuilder();
			vCreCtx.SetDataAccess(vMockDataAcc.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false, null)]
		[TestCase(false, "my.append.script")]
		[TestCase(true, null)]
		[TestCase(true, "my.append.script")]
		public void AddQuery(bool pCache, string pAppend) {
			var mockQ = new Mock<IWeaverQuery>(MockBehavior.Strict);

			vCreCtx.AddQuery(mockQ.Object, pCache, pAppend);

			vMockDataAcc
				.Verify(x => x.AddQuery(mockQ.Object, pCache), Times.Once);

			if ( pAppend == null ) {
				vMockDataAcc
					.Verify(x => x.AppendScriptToLatestCommand(It.IsAny<string>()), Times.Never);
			}
			else {
				vMockDataAcc
					.Verify(x => x.AppendScriptToLatestCommand(pAppend), Times.Once);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false, false)]
		[TestCase(false, true)]
		[TestCase(true, false)]
		[TestCase(true, true)]
		public void SetupLatestCommand(bool pOmit, bool pNewCond) {
			string result = vCreCtx.SetupLatestCommand(pOmit, pNewCond);

			Assert.AreEqual(LatestCmdId, result, "Incorrect result.");

			vMockDataAcc
				.Verify(x => x.OmitResultsOfLatestCommand(), (pOmit ? Times.Once() : Times.Never()));

			vMockDataAcc
				.Verify(x => x.AddConditionsToLatestCommand(It.IsAny<string>()), Times.Never);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false, false)]
		[TestCase(false, true)]
		[TestCase(true, false)]
		[TestCase(true, true)]
		public void SetupLatestCommandCondition(bool pFirstCond, bool pNextCond) {
			const string nextCmdId = "nextCmd";
			var cmdResults = new Queue<string>(new[] { LatestCmdId, nextCmdId });

			vMockDataAcc.Setup(x => x.GetLatestCommandId()).Returns(cmdResults.Dequeue);

			string firstResult = vCreCtx.SetupLatestCommand(false, pFirstCond);
			string nextResult = vCreCtx.SetupLatestCommand(false, pNextCond);

			Assert.AreEqual(LatestCmdId, firstResult, "Incorrect first result.");
			Assert.AreEqual(nextCmdId, nextResult, "Incorrect next result.");

			if ( pFirstCond ) {
				vMockDataAcc
					.Verify(x => x.AddConditionsToLatestCommand(LatestCmdId), Times.Once);
			}
			else {
				vMockDataAcc
					.Verify(x => x.AddConditionsToLatestCommand(It.IsAny<string>()), Times.Never);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void StartSession() {
			vCreCtx.StartSession();

			vMockDataAcc.Verify(x => x.AddSessionStart(), Times.Once);
			vMockDataAcc.Verify(x => x.GetLatestCommandId(), Times.Once);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false)]
		[TestCase(true)]
		public void CommitAndCloseSession(bool pFirstCond) {
			const string commitCmdId = "commitCmd";
			const string closeCmdId = "closeCmd";
			var cmdResults = new Queue<string>();
			
			if ( pFirstCond ) {
				cmdResults.Enqueue(LatestCmdId);
			}
			
			cmdResults.Enqueue(commitCmdId);
			cmdResults.Enqueue(closeCmdId);

			if ( pFirstCond ) {
				string firstResult = vCreCtx.SetupLatestCommand(false, true);
				Assert.AreEqual(LatestCmdId, firstResult, "Incorrect first result.");
			}

			vCreCtx.CommitAndCloseSession();

			vMockDataAcc.Verify(x => x.AddSessionCommit(), Times.Once);
			vMockDataAcc.Verify(x => x.AddSessionClose(), Times.Once);
			vMockDataAcc.Verify(x => x.GetLatestCommandId(), Times.Exactly(pFirstCond ? 3 : 2));

			if ( pFirstCond ) {
				vMockDataAcc
					.Verify(x => x.AddConditionsToLatestCommand(LatestCmdId), Times.Once);
			}
			else {
				vMockDataAcc
					.Verify(x => x.AddConditionsToLatestCommand(It.IsAny<string>()), Times.Never);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1)]
		[TestCase(99)]
		public void AddAndPerformChecks(int pCount) {
			var mockChecks = new List<Mock<IDataResultCheck>>();
			var mockRes = new Mock<IDataResult>(MockBehavior.Strict);

			for ( int i = 0 ; i < pCount ; ++i ) {
				var mc = new Mock<IDataResultCheck>(MockBehavior.Strict);
				mc.Setup(x => x.PerformCheck(mockRes.Object));
				mockChecks.Add(mc);
			}

			foreach ( Mock<IDataResultCheck> mc in mockChecks ) {
				vCreCtx.AddCheck(mc.Object);
			}

			vCreCtx.PerformChecks(mockRes.Object);

			foreach ( Mock<IDataResultCheck> mc in mockChecks ) {
				mc.Verify(x => x.PerformCheck(mockRes.Object), Times.Once);
			}
		}

	}

}