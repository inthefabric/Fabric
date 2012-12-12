using System;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiPaths {

	/*================================================================================================*/
	[TestFixture]
	public class TPath {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			Assert.AreEqual("", p.Script, "Incorrect Script.");
			Assert.NotNull(p.Segments, "Segments should not be null.");
			Assert.AreEqual(0, p.Segments.Count, "Incorrect Segments.Count.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddSegment() {
			var p = new Path();
			const string script0 = "g.v(0)";
			const string script1 = "outE('RootContainsArtifact')";
			const string script2 = "inV";
			const string script3 = "has('ArtifactId',Tokens.T.eq,5L)";
			const string script4 = "outE('ArtifactUsesArtifactType')";
			const string script5 = "inV";
			const string expect = script0+"."+script1+"."+script2+"."+script3+"."+script4+"."+script5;
			IStep step;

			AddSegmentToPath(p, script0, out step);
			AddSegmentToPath(p, script1, out step);
			AddSegmentToPath(p, script2, out step);
			AddSegmentToPath(p, script3, out step);
			AddSegmentToPath(p, script4, out step);
			AddSegmentToPath(p, script5, out step);

			Assert.AreEqual(expect, p.Script, "Incorrect final Script.");
			Assert.AreEqual(6, p.Segments.Count, "Incorrect final Segments.Count.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AppendToCurrentSegment() {
			var p = new Path();
			const string script0A = "g.v(0)";
			const string script0B = "outE('RootContainsArtifact')";
			const string script1A = "inV";
			const string script1B = "has('ArtifactId',Tokens.T.eq,5L)";
			const string script1C = "outE('ArtifactUsesArtifactType')";
			const string script2 = "inV";
			const string expect = 
				script0A+"."+script0B+"."+script1A+"."+script1B+"."+script1C+"."+script2;
			IStep step;

			AddSegmentToPath(p, script0A, out step);
			AppendToPathSegment(p, script0B);

			AddSegmentToPath(p, script1A, out step);
			AppendToPathSegment(p, script1B);
			AppendToPathSegment(p, script1C);

			AddSegmentToPath(p, script2, out step);

			Assert.AreEqual(expect, p.Script, "Incorrect final Script.");
			Assert.AreEqual(3, p.Segments.Count, "Incorrect final Segments.Count.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AppendToCurrentSegmentNoSegments() {
			TestUtil.CheckThrows<Exception>(true, () => new Path().AppendToCurrentSegment("inV"));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void AddSegmentToPath(Path pPath, string pScript, out IStep pStep) {
			string origScript = pPath.Script;
			int origSegCount = pPath.Segments.Count;
			string expectScript = origScript+(origScript == "" ? "" : ".")+pScript;
			int expectSegIndex = origSegCount;

			pStep = new Mock<IStep>().Object;
			pPath.AddSegment(pStep, pScript);

			Assert.AreEqual(expectScript, pPath.Script, "Incorrect Script.");
			Assert.AreEqual(origSegCount+1, pPath.Segments.Count, "Incorrect Segments.Count.");

			PathSegment seg = pPath.Segments[expectSegIndex];
			Assert.AreEqual(pStep, seg.Step, "Incorrect Segemnts["+expectSegIndex+"].Step.");
			Assert.AreEqual(pScript, seg.Script, "Incorrect Segemnts["+expectSegIndex+"].Script.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void AppendToPathSegment(Path pPath, string pScript) {
			int origSegCount = pPath.Segments.Count;
			int expectSegIndex = origSegCount-1;
			string origSegScript = pPath.Segments[expectSegIndex].Script;
			string expectScript = pPath.Script+(pPath.Script == "" ? "" : ".")+pScript;
			string expectSegScript = origSegScript+"."+pScript;
			IStep origStep = pPath.Segments[expectSegIndex].Step;

			pPath.AppendToCurrentSegment(pScript);

			Assert.AreEqual(expectScript, pPath.Script, "Incorrect Script.");
			Assert.AreEqual(origSegCount, pPath.Segments.Count, "Incorrect Segments.Count.");

			PathSegment seg = pPath.Segments[expectSegIndex];
			Assert.AreEqual(origStep, seg.Step, "Incorrect Segemnts["+expectSegIndex+"].Step.");
			Assert.AreEqual(expectSegScript, seg.Script,
				"Incorrect Segemnts["+expectSegIndex+"].Script.");
		}

	}

}