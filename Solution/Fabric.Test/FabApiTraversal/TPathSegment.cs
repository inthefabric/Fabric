using System;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal {

	/*================================================================================================*/
	[TestFixture]
	public class TPathSegment {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("g.v(0)")]
		[TestCase("x")]
		public void New(string pScript) {
			IStep step = new Mock<IStep>().Object;
			var ps = new PathSegment(step, pScript);

			Assert.AreEqual(pScript, ps.Script, "Incorrect Script.");
			Assert.AreEqual(step, ps.Step, "Incorrect Step.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		[TestCase("	\n	")]
		public void NewInvalidScript(string pScript) {
			IStep step = new Mock<IStep>().Object;
			TestUtil.CheckThrows<Exception>(true, () => new PathSegment(step, pScript));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("inV", true)]
		[TestCase("outE('RootContainsArtifact')", true)]
		[TestCase("[0..2]", false)]
		public void Append(string pScript, bool pAddDot) {
			IStep step = new Mock<IStep>().Object;
			const string origScript = "g.v(0)";

			var ps = new PathSegment(step, origScript);
			ps.Append(pScript, pAddDot);

			Assert.AreEqual(origScript+(pAddDot ? "." : "")+pScript, ps.Script, "Incorrect Script.");
			Assert.AreEqual(step, ps.Step, "Incorrect Step.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		[TestCase("	\n	")]
		public void AppendInvalidScript(string pScript) {
			IStep step = new Mock<IStep>().Object;
			var ps = new PathSegment(step, "x");
			TestUtil.CheckThrows<Exception>(true, () => ps.Append(pScript));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("x", 1)]
		[TestCase("inV.outE('RootContainsArtifact')", 2)]
		[TestCase("1.2.3.4(a,b,c).5.6", 6)]
		[TestCase("test[0..9]", 2)]
		[TestCase("g.V.dedup[0..9].back(2)", 5)]
		public void SubstepCount(string pScript, int pExpectCount) {
			IStep step = new Mock<IStep>().Object;
			var ps = new PathSegment(step, pScript);
			Assert.AreEqual(pExpectCount, ps.SubstepCount, "Incorrect SubstepCount.");
		}

	}

}