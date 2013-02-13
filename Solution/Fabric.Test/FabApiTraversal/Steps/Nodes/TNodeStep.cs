using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Test.Common;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Nodes {

	/*================================================================================================*/
	[TestFixture]
	public class TNodeStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();
			var s = new TestNodeStep(p.Object);

			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(TestFabNode), s.DtoType, "Incorrect DtoType.");
			Assert.NotNull(s.AvailableLinks, "AvailableLinks should not be null.");
			Assert.AreEqual(1, s.AvailableLinks.Count, "Incorrect AvailableLinks length.");
			Assert.AreEqual("Has", s.AvailableLinks[0].RelType, "Incorrect AvailableLinks[0].");
			Assert.Null(s.Data, "Data should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePath() {
			var p = new Mock<IPath>();
			var s = new TestNodeStep(p.Object);
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
			var s = new TestNodeStep(p.Object);

			s.SetDataAndUpdatePath(new StepData("HasArtifact"));

			Assert.AreEqual("g.V('TestNodeStepId',"+typeId+"L)[0]",
				s.GetKeyIndexScript(typeId), "Incorrect result.");
		}

	}

}