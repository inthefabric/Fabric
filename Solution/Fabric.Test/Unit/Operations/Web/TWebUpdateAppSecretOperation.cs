using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Domain.Names;
using Fabric.Operations;
using Fabric.Operations.Web;
using Fabric.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Web {

	/*================================================================================================*/
	[TestFixture]
	public class TWebUpdateAppSecretOperation {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;

		private App vApp;
		private string vSecret;
		private WebUpdateAppSecretOperation vOper;
		private SuccessResult vExecuteResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vApp = new App();
			vApp.VertexId = 1234125;
			vSecret = "123456789012345678901234567890ab";

			vMockData = new Mock<IOperationData>(MockBehavior.Strict);

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);
			vMockOpCtx.SetupGet(x => x.Code32).Returns(vSecret);

			vOper = new WebUpdateAppSecretOperation();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void DoExecute() {
			vExecuteResult = vOper.Execute(vMockOpCtx.Object, vApp.VertexId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			const string expectScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
					".sideEffect{"+
						"it.setProperty('"+DbName.Vert.App.Secret+"',_P);"+
					"};";

			var expectParams = new List<object> {
				vApp.VertexId,
				vSecret
			};

			vMockData
				.Setup(x => x.Get<App>(It.IsAny<IWeaverQuery>(), "Web-UpdateAppSecret"))
				.Callback((IWeaverScript q, string n) => 
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns(vApp);

			DoExecute();

			Assert.NotNull(vExecuteResult, "Result should be filled.");
			Assert.True(vExecuteResult.Success, "Incorrect Success.");
		}

	}

}