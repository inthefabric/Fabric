using System.Collections.Generic;
using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Cache;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Operations;
using Fabric.New.Test.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations {

	/*================================================================================================*/
	[TestFixture]
	public class TOperationContextDataExt {

		private static readonly Logger Log = Logger.Build<TOperationContextDataExt>();

		private const string BasicScript = "g.v(1)";
		private const string GetVertexByIdScript = "g.V('"+DbName.Vert.Vertex.VertexId+"',_P0);";

		private MockDataAccess vMockAcc;
		private Mock<IOperationContext> vMockCtx;
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

			vMockCtx = new Mock<IOperationContext>();
			vMockCtx.Setup(x => x.NewData(null, false, true)).Returns(vMockAcc.Object);

			vBasicQuery = new WeaverQuery();
			vBasicQuery.FinalizeQuery(BasicScript);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Execute() {
			IDataResult result = vMockCtx.Object.Execute(vBasicQuery, "TEST");
			Assert.AreEqual(vMockAcc.MockResult.Object, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Get() {
			var app = new App();
			vMockAcc.MockResult.SetupToElement(app);

			App result = vMockCtx.Object.Get<App>(vBasicQuery, "TEST");
			Assert.AreEqual(app, result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetList() {
			var list = new List<App>();
			vMockAcc.MockResult.SetupToElementList(list);

			IList<App> result = vMockCtx.Object.GetList<App>(vBasicQuery, "TEST");
			Assert.AreEqual(list, result, "Incorrect result.");
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

			var mockMemCache = new Mock<IMemCache>();
			var mockCache = new Mock<ICacheManager>();
			mockCache.SetupGet(x => x.Memory).Returns(mockMemCache.Object);

			vMockCtx = new Mock<IOperationContext>();
			vMockCtx.Setup(x => x.NewData(null, false, true)).Returns(vMockAcc.Object);
			vMockCtx.SetupGet(x => x.Cache).Returns(mockCache.Object);

			App result = vMockCtx.Object.GetVertexById<App>(id);

			Assert.AreEqual(app, result, "Incorrect result.");
			mockMemCache.Verify(x => x.FindVertex<App>(id), Times.Once);

			if ( pFound ) {
				mockMemCache.Verify(x => x.RemoveVertex<App>(id), Times.Never);
				mockMemCache.Verify(x => x.AddVertex(app, null), Times.Once);
			}
			else {
				mockMemCache.Verify(x => x.RemoveVertex<App>(id), Times.Once);
				mockMemCache.Verify(x => x.AddVertex(app, null), Times.Never);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetVertexByIdCached() {
			const long id = 13241235;
			var app = new App();

			var mockMemCache = new Mock<IMemCache>();
			mockMemCache.Setup(x => x.FindVertex<App>(id)).Returns(app);

			var mockCache = new Mock<ICacheManager>();
			mockCache.SetupGet(x => x.Memory).Returns(mockMemCache.Object);

			vMockCtx = new Mock<IOperationContext>();
			vMockCtx.SetupGet(x => x.Cache).Returns(mockCache.Object);

			App result = vMockCtx.Object.GetVertexById<App>(id);
			Assert.AreEqual(app, result, "Incorrect result.");

			vMockCtx.Verify(x => x.NewData(null, false, true), Times.Never);
			mockMemCache.Verify(x => x.RemoveVertex<App>(id), Times.Never);
			mockMemCache.Verify(x => x.AddVertex(app, null), Times.Never);
		}

	}

}