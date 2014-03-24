using System;
using System.Collections.Generic;
using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Cache;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Operations;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations {

	/*================================================================================================*/
	[TestFixture]
	public class TOperationData {

		private static readonly Logger Log = Logger.Build<TOperationData>();

		private const string BasicScript = "g.v(1)";
		private const string GetVertexByIdScript = "g.V('"+DbName.Vert.Vertex.VertexId+"',_P0);";

		private MockDataAccess vMockAcc;
		private Mock<IDataAccessFactory> vMockFact;
		private Mock<IMetricsManager> vMockMet;
		private Mock<IMemCache> vMockCache;

		private IOperationData vData;
		private IWeaverQuery vBasicQuery;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockAcc = MockDataAccess.Create(mda => {
				MockDataAccessCmd cmd = mda.GetCommand(0);
				Assert.AreEqual(BasicScript+";", cmd.Script, "Incorrect Query.Script.");
				TestUtil.CheckParams(cmd.Params, "_P", new List<object>());
			});

			vMockFact = new Mock<IDataAccessFactory>(MockBehavior.Strict);
			vMockFact.Setup(x => x.Create(null, false, true)).Returns(vMockAcc.Object);

			vMockMet = new Mock<IMetricsManager>(MockBehavior.Strict);
			vMockMet.Setup(x => x.Counter(It.IsAny<string>(), It.IsAny<long>()));
			vMockMet.Setup(x => x.Timer(It.IsAny<string>(), It.IsAny<long>()));
			vMockMet.Setup(x => x.Mean(It.IsAny<string>(), It.IsAny<long>()));

			vMockCache = new Mock<IMemCache>(MockBehavior.Strict);

			vData = new OperationData(new Guid(), vMockFact.Object, vMockMet.Object, vMockCache.Object);

			vBasicQuery = new WeaverQuery();
			vBasicQuery.FinalizeQuery(BasicScript);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			Assert.AreEqual(0, vData.DbQueryExecutionCount, "Incorrect DbQueryExecutionCount.");
			Assert.AreEqual(0, vData.DbQueryMillis, "Incorrect DbQueryMillis.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("sess", false, false)]
		[TestCase(null, true, true)]
		public void NewData(string pSessId, bool pCmdId, bool pCmdTimers) {
			vMockFact.Setup(x => x.Create(pSessId, pCmdId, pCmdTimers)).Returns(vMockAcc.Object);

			IDataAccess result = vData.Build(pSessId, pCmdId, pCmdTimers);
			Assert.AreEqual(vMockAcc.Object, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Execute() {
			IDataResult result = vData.Execute(vBasicQuery, "TEST");
			Assert.AreEqual(vMockAcc.MockResult.Object, result, "Incorrect result.");
			Assert.AreEqual(1, vData.DbQueryExecutionCount, "Incorrect DbQueryExecutionCount.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Get() {
			var app = new App();
			vMockAcc.MockResult.SetupToElement(app);

			App result = vData.Get<App>(vBasicQuery, "TEST");
			Assert.AreEqual(app, result, "Incorrect result.");
			Assert.AreEqual(1, vData.DbQueryExecutionCount, "Incorrect DbQueryExecutionCount.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetList() {
			var list = new List<App>();
			vMockAcc.MockResult.SetupToElementList(list);

			IList<App> result = vData.GetList<App>(vBasicQuery, "TEST");
			Assert.AreEqual(list, result, "Incorrect result.");
			Assert.AreEqual(1, vData.DbQueryExecutionCount, "Incorrect DbQueryExecutionCount.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false)]
		[TestCase(true)]
		public void GetVertexById(bool pFound) {
			const long id = 13241235;
			var app = (pFound ? new App() : null);

			vMockAcc = MockDataAccess.Create(mda => {
				MockDataAccessCmd cmd = mda.GetCommand(0);
				Assert.AreEqual(GetVertexByIdScript, cmd.Script, "Incorrect Query.Script.");
				TestUtil.CheckParams(cmd.Params, "_P", new List<object>{ id });
			});
			vMockAcc.MockResult.SetupToElement(app);
			vMockCache.Setup(x => x.FindVertex<App>(id)).Returns((App)null);
			vMockCache.Setup(x => x.AddVertex(app, null));
			vMockCache.Setup(x => x.RemoveVertex<App>(id)).Returns((App)null);
			vMockFact.Setup(x => x.Create(null, false, true)).Returns(vMockAcc.Object);

			App result = vData.GetVertexById<App>(id);

			Assert.AreEqual(app, result, "Incorrect result.");
			vMockCache.Verify(x => x.FindVertex<App>(id), Times.Once);

			if ( pFound ) {
				vMockCache.Verify(x => x.RemoveVertex<App>(id), Times.Never);
				vMockCache.Verify(x => x.AddVertex(app, null), Times.Once);
			}
			else {
				vMockCache.Verify(x => x.RemoveVertex<App>(id), Times.Once);
				vMockCache.Verify(x => x.AddVertex(app, null), Times.Never);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetVertexByIdCached() {
			const long id = 13241235;
			var app = new App();

			vMockCache.Setup(x => x.FindVertex<App>(id)).Returns(app);

			App result = vData.GetVertexById<App>(id);
			Assert.AreEqual(app, result, "Incorrect result.");

			vMockCache.Verify(x => x.RemoveVertex<App>(id), Times.Never);
			vMockCache.Verify(x => x.AddVertex(app, null), Times.Never);
		}

	}

}