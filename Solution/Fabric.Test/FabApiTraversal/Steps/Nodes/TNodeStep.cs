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
			var p = new Path();
			var s = new TestNodeStep(p);

			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(TestFabNode), s.DtoType, "Incorrect DtoType.");
			Assert.NotNull(s.AvailableLinks, "AvailableLinks should not be null.");
			Assert.AreEqual(1, s.AvailableLinks.Count, "Incorrect AvailableLinks length.");
			Assert.AreEqual("Has", s.AvailableLinks[0].RelType, "Incorrect AvailableLinks[0].");
			Assert.Null(s.Data, "Data should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePath() {
			IStep step = new Mock<IStep>().Object;
			var p = new Path();
			p.AddSegment(step, "test");

			var s = new TestNodeStep(p);
			var d = new StepData("HasArtifact");
			s.SetDataAndUpdatePath(d);

			Assert.AreEqual(d, s.Data, "Incorrect Data.");
			Assert.AreEqual(p, s.Path, "Incorrect Path.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetKeyIndexScript() {
			IStep step = new Mock<IStep>().Object;
			var p = new Path();
			p.AddSegment(step, "test");

			var s = new TestNodeStep(p);
			s.SetDataAndUpdatePath(new StepData("HasArtifact"));

			const long typeId = 14265126;

			Assert.AreEqual("g.V('TestNodeStepId',"+typeId+"L)[0]",
				s.GetKeyIndexScript(typeId), "Incorrect result.");
		}

	}

}