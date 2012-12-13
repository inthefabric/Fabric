using System;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiPaths.Steps.Nodes {

	/*================================================================================================*/
	[TestFixture]
	public class TNodeStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			var s = new TestNodeStep(p);
			var expectAvail = new[] { "HasThing" };

			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.Null(s.TypeId, "TypeId should be null.");
			Assert.AreEqual(typeof(TestFabNode), s.DtoType, "Incorrect DtoType.");
			Assert.AreEqual(expectAvail, s.AvailableSteps, "Incorrect AvailableSteps.");
			Assert.Null(s.Data, "Data should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("HasArtifact", null)]
		[TestCase("HasArtifact(1)", 1L)]
		[TestCase("hasARTIFACT(999,888)", 999L)]
		[TestCase("hasArtifact( 33 , asdf )", 33L)]
		public void SetData(string pStepText, long? pExpectTypeId) {
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
			TestUtil.CheckThrows<Exception>(true, () => { s.SetDataAndUpdatePath(d); });
		}

	}

}