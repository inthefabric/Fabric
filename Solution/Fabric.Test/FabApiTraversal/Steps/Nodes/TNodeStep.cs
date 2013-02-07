using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Common;
using Fabric.Test.Util;
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
			Assert.Null(s.TypeId, "TypeId should be null.");
			Assert.AreEqual(typeof(TestFabNode), s.DtoType, "Incorrect DtoType.");
			Assert.NotNull(s.AvailableLinks, "AvailableLinks should not be null.");
			Assert.AreEqual(1, s.AvailableLinks.Count, "Incorrect AvailableLinks length.");
			Assert.AreEqual("Has", s.AvailableLinks[0].RelType, "Incorrect AvailableLinks[0].");
			Assert.Null(s.Data, "Data should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("HasArtifact", null)]
		[TestCase("HasArtifact(1)", 1L)]
		[TestCase("hasARTIFACT(999,888)", 999L)]
		[TestCase("hasArtifact( 33 , asdf )", 33L)]
		public void SetDataAndUpdatePath(string pStepText, long? pExpectTypeId) {
			IStep step = new Mock<IStep>().Object;
			var p = new Path();
			p.AddSegment(step, "test");
			string origPathScript = p.Script;

			var s = new TestNodeStep(p);
			var d = new StepData(pStepText);
			s.SetDataAndUpdatePath(d);

			Assert.AreEqual(d, s.Data, "Incorrect Data.");
			Assert.AreEqual(p, s.Path, "Incorrect Path.");

			if ( pExpectTypeId == null ) {
				Assert.Null(s.TypeId, "TypeId should be null.");
			}
			else {
				Assert.NotNull(s.TypeId, "TypeId should be filled.");
				Assert.AreEqual((long)pExpectTypeId, (long)s.TypeId, "Incorrect TypeId.");

				Assert.AreEqual(origPathScript+".has('TestNodeStepId',Tokens.T.eq,"+pExpectTypeId+"L)",
					s.Path.Script, "Incorrect Path.Script.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("HasArtifact(1.0)")]
		[TestCase("HasArtifact(1.1)")]
		[TestCase("HasArtifact(x)")]
		[TestCase("HasArtifact(9999a)")]
		[TestCase("HasArtifact(4F)")]
		[TestCase("HasArtifact(4f)")]
		[TestCase("HasArtifact(4L)")]
		[TestCase("HasArtifact(4l)")]
		public void SetDataInvalidParam(string pStepText) {
			var s = new TestNodeStep(new Path());
			var d = new StepData(pStepText);

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(d) );
			Assert.AreEqual(FabFault.Code.IncorrectParamType, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect ParamIndex.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("HasArtifact", null)]
		[TestCase("HasArtifact(123)", 123L)]
		public void GetKeyIndexScript(string pStepText, long? pExpectTypeId) {
			IStep step = new Mock<IStep>().Object;
			var p = new Path();
			p.AddSegment(step, "test");

			var s = new TestNodeStep(p);
			s.SetDataAndUpdatePath(new StepData(pStepText));

			Assert.AreEqual("g.V('TestNodeStepId',"+pExpectTypeId+"L)",
				s.GetKeyIndexScript(), "Incorrect result.");
		}

	}

}