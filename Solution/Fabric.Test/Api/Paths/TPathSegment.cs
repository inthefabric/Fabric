using System;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.Api.Paths {

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
		[TestCase("inV")]
		[TestCase("outE('RootContainsArtifact')")]
		public void Append(string pScript) {
			IStep step = new Mock<IStep>().Object;
			string origScript = "g.v(0)";

			var ps = new PathSegment(step, origScript);
			ps.Append(pScript);

			Assert.AreEqual(origScript+"."+pScript, ps.Script, "Incorrect Script.");
			Assert.AreEqual(step, ps.Step, "Incorrect Step.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		[TestCase("	\n	")]
		public void NewInvalidScript(string pScript) {
			IStep step = new Mock<IStep>().Object;
			TestUtil.CheckThrows<Exception>(true, () => new PathSegment(step, pScript));
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

	}

}