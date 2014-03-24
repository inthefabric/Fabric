using System;
using Fabric.Api.Objects;
using Fabric.Domain.Enums;
using Fabric.Domain.Names;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Steps;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepEntry {

		private Mock<ITravPath> vMockPath;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockPath = new Mock<ITravPath>(MockBehavior.Strict);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabVertex), typeof(FabUser), VertexType.Id.User)]
		[TestCase(typeof(FabVertex), typeof(FabApp), VertexType.Id.App)]
		public void AddTypeFilterYes(Type pStepType, Type pPathType, VertexType.Id pVertType) {
			const string dbName = DbName.Vert.Vertex.VertexType;
			const string dbNameParam = "_P0";
			const string typeIdParam = "_P1";
			const string script = ".has("+dbNameParam+", Tokens.T.eq, "+typeIdParam+")";

			vMockPath.Setup(x => x.AddScript(script));
			vMockPath.Setup(x => x.AddParam(dbName)).Returns(dbNameParam);
			vMockPath.Setup(x => x.AddParam((byte)pVertType)).Returns(typeIdParam);

			TravStepEntry.AddTypeFilterIfNecessary(vMockPath.Object, pStepType, pPathType);

			vMockPath.Verify(x => x.AddScript(script), Times.Once);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabVertex), typeof(FabVertex))]
		[TestCase(typeof(FabUser), typeof(FabUser))]
		[TestCase(typeof(FabUser), typeof(FabVertex))]
		public void AddTypeFilterNo(Type pStepType, Type pPathType) {
			TravStepEntry.AddTypeFilterIfNecessary(vMockPath.Object, pStepType, pPathType);
			vMockPath.Verify(x => x.AddScript(It.IsAny<string>()), Times.Never);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddLimit() {
			const string script = "[0..99]";
			vMockPath.Setup(x => x.AddScript(script));

			TravStepEntry.AddLimit(vMockPath.Object);

			vMockPath.Verify(x => x.AddScript(script), Times.Once);
		}

	}

}