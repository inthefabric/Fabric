using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Faults;
using Fabric.Operations;
using Fabric.Operations.Web;
using Fabric.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Web {

	/*================================================================================================*/
	[TestFixture]
	public class TWebUpdateAppNameOperation {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;

		private App vApp;
		private string vNewName;
		private int vUniqueChecks;
		private WebUpdateAppNameOperation vOper;
		private SuccessResult vExecuteResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vApp = new App();
			vApp.VertexId = 1234125;
			vApp.Name = "MyAppName";
			vApp.NameKey = "myappname";

			vNewName = "MyNewAppName";
			vUniqueChecks = 0;

			vMockData = new Mock<IOperationData>(MockBehavior.Strict);

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vOper = new WebUpdateAppNameOperation();

			////

			const string expectUniqueScript = "g.V('"+DbName.Vert.App.NameKey+"',_P);";

			var expectUniqueParams = new List<object> {
				vNewName.ToLower()
			};

			vMockData
				.Setup(x => x.Get<App>(It.IsAny<IWeaverQuery>(), "Web-GetAppByName"))
				.Callback((IWeaverScript q, string n) => {
					TestUtil.CheckWeaverScript(q, expectUniqueScript, "_P", expectUniqueParams);
					++vUniqueChecks;
				})
				.Returns(vApp);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void DoExecute() {
			vExecuteResult = vOper.Execute(vMockOpCtx.Object, vApp.VertexId, vNewName);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			const string expectUpdateScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
					".sideEffect{"+
						"it.setProperty('"+DbName.Vert.App.Name+"',_P);"+
						"it.setProperty('"+DbName.Vert.App.NameKey+"',_P);"+
					"};";

			var expectUpdateParams = new List<object> {
				vApp.VertexId,
				vNewName,
				vNewName.ToLower()
			};

			vMockData
				.Setup(x => x.Get<App>(It.IsAny<IWeaverQuery>(), "Web-UpdateAppName"))
				.Callback((IWeaverScript q, string n) => 
					TestUtil.CheckWeaverScript(q, expectUpdateScript, "_P", expectUpdateParams))
				.Returns(vApp);

			////
			
			DoExecute();

			Assert.NotNull(vExecuteResult, "Result should be filled.");
			Assert.True(vExecuteResult.Success, "Incorrect Success.");
			Assert.AreEqual(1, vUniqueChecks, "The uniqueness query was not executed.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicate() {
			vApp.Name = vNewName;
			TestUtil.Throws<FabDuplicateFault>(DoExecute);
			Assert.AreEqual(1, vUniqueChecks, "The uniqueness query was not executed.");
		}

	}

}