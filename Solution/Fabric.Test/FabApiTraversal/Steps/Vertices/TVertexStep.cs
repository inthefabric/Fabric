﻿using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiTraversal.Steps.Vertices {

	/*================================================================================================*/
	[TestFixture]
	public class TVertexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();
			var s = new TestVertexStep(p.Object);

			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(TestFabVertex), s.DtoType, "Incorrect DtoType.");
			Assert.NotNull(s.AvailableLinks, "AvailableLinks should not be null.");
			Assert.AreEqual(1, s.AvailableLinks.Count, "Incorrect AvailableLinks length.");
			Assert.AreEqual("Has", s.AvailableLinks[0].EdgeType, "Incorrect AvailableLinks.");
			Assert.Null(s.Data, "Data should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePath() {
			var p = new Mock<IPath>();
			var s = new TestVertexStep(p.Object);
			var d = new StepData("HasArtifact");

			s.SetDataAndUpdatePath(d);

			Assert.AreEqual(d, s.Data, "Incorrect Data.");
			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetKeyIndexScript() {
			const long typeId = 14265126;
			
			var p = new Mock<IPath>();
			p.Setup(x => x.AddParam(It.IsAny<IWeaverQueryVal>())).Returns("_P0");

			var s = new TestVertexStep(p.Object);
			s.SetDataAndUpdatePath(new StepData("HasArtifact"));

			Assert.AreEqual("g.V('TestVertexStepId',_P0)",
				s.GetKeyIndexScript(typeId), "Incorrect result.");
		}

	}

}