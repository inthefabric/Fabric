using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations;
using Fabric.New.Operations.Traversal;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Traversal {

	/*================================================================================================*/
	[TestFixture]
	public class TTraversalOperation {

		// These tests cover more than just the TraversalOperation code. Attempts to remove dependencies
		// resulted in over-complicated structures. For now, these tests will be sufficient.

		private long vAuthMemId;
		private Mock<IOperationAuth> vMockAuth;
		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;
		private TraversalOperation vOper;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vAuthMemId = 134632634;

			vMockAuth = new Mock<IOperationAuth>(MockBehavior.Strict);
			vMockAuth.SetupGet(x => x.ActiveMemberId).Returns(vAuthMemId);

			vMockData = new Mock<IOperationData>(MockBehavior.Strict);

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Auth).Returns(vMockAuth.Object);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vOper = new TraversalOperation();
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteAndGetResultSteps() {
			const long vertId = 987654;
			const string queryName = "Trav-vertices-withid";
			string pathText = "Vertices/WithId("+vertId+")";

			const string expectScript = "g.V.has(_P, Tokens.T.eq, _P)[0..99][0..99];";
			var expectValues = new List<object> { DbName.Vert.Vertex.VertexId, vertId };

			var dto = new DataDto();
			dto.Id = "A";
			dto.VertexType = VertexType.Id.Vertex;
			dto.Properties = new Dictionary<string, string>();
			dto.Properties.Add(DbName.Vert.Vertex.VertexId, vertId+"");
			dto.Properties.Add(DbName.Vert.Vertex.VertexType, (byte)dto.VertexType+"");
			dto.Properties.Add(DbName.Vert.Vertex.Timestamp, "1236546735");

			var vertDtos = new List<IDataDto> { dto };

			var mockRes = new Mock<IDataResult>(MockBehavior.Strict);
			mockRes.Setup(x => x.ToDtoList()).Returns(vertDtos);

			vMockData
				.Setup(x => x.Execute(It.IsAny<WeaverQuery>(), queryName))
				.Returns(mockRes.Object)
				.Callback((IWeaverQuery q, string name) => 
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectValues));

			IList<FabElement> result = vOper.Execute(vMockOpCtx.Object, pathText);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(1, result.Count, "Incorrect result count.");

			Assert.AreEqual(typeof(FabVertex), result[0].GetType(), "Incorrect result[0] type.");

			FabVertex v = (FabVertex)result[0];
			Assert.AreEqual(vertId, v.Id, "Incorrect result[0].Id.");

			////

			IList<FabTravStep> resultSteps = vOper.GetResultSteps();
			Assert.NotNull(resultSteps, "Result steps should be filled.");
			Assert.Less(0, resultSteps.Count, "Incorrect result steps count.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExecuteRootAndGetResultSteps() {
			const string pathText = "Users";

			IList<FabElement> result = vOper.Execute(vMockOpCtx.Object, pathText);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(0, result.Count, "Incorrect result count.");

			////

			IList<FabTravStep> resultSteps = vOper.GetResultSteps();
			Assert.NotNull(resultSteps, "Result steps should be filled.");
			Assert.Less(0, resultSteps.Count, "Incorrect result steps count.");

			vMockData.Verify(x => x.Execute(It.IsAny<WeaverQuery>(), It.IsAny<string>()), Times.Never);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorInvalidStep() {
			FabStepFault f = TestUtil.Throws<FabStepFault>(
				() => vOper.Execute(vMockOpCtx.Object, "Users/BadStep(123)"));

			TestUtil.AssertContains("Fault.Message", f.Message, "not valid");
			TestUtil.AssertContains("Fault.Message", f.Message, "BadStep");
		}

	}

}