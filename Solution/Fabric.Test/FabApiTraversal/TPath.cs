using System;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal {

	/*================================================================================================*/
	[TestFixture]
	public class TPath {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			Assert.AreEqual("", p.Script, "Incorrect Script.");
			Assert.AreEqual(0, p.GetSegmentCount(), "Incorrect GetSegmentCount().");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
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
			Mock<IStep> mockStep;

			TestAddSegmentToPath(p, script0, out mockStep);
			TestAddSegmentToPath(p, script1, out mockStep);
			TestAddSegmentToPath(p, script2, out mockStep);
			TestAddSegmentToPath(p, script3, out mockStep);
			TestAddSegmentToPath(p, script4, out mockStep);
			TestAddSegmentToPath(p, script5, out mockStep);

			Assert.AreEqual(expect, p.Script, "Incorrect final Script.");
			Assert.AreEqual(6, p.GetSegmentCount(), "Incorrect final GetSegmentCount().");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AddSegmentShortcut() {
			var p = new Path();
			const long typeId = 125235;
			string expectShortcut = "g.V('ArtifactId',"+typeId+"L)[0]";
			const string script0 = "g.v(0)";
			const string script3 = "outE('ArtifactUsesArtifactType').inV";
			string expectScript = expectShortcut+"."+script3;
			Mock<IStep> mockStep;

			var nodeStep = new Mock<INodeStep>();
			nodeStep.Setup(x => x.GetKeyIndexScript(typeId)).Returns(expectShortcut);

			var whereId = new Mock<IFuncWhereIdStep>();
			whereId.SetupGet(x => x.Id).Returns(typeId);

			TestAddSegmentToPath(p, script0, out mockStep);
			p.AddSegment(nodeStep.Object, "XXX");
			p.AddSegment(whereId.Object, "XXX");
			TestAddSegmentToPath(p, script3, out mockStep);

			Assert.AreEqual(expectScript, p.Script, "Incorrect final Script.");
			Assert.AreEqual(4, p.GetSegmentCount(), "Incorrect final GetSegmentCount().");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase("		 ")]
		public void AddSegmentNullEmpty(string pScript) {
			TestUtil.CheckThrows<Exception>(true, () => new Path().AddSegment(null, pScript));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
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
			const string script3A = "back";
			const string script3B = "(2)";
			const string expect = script0A+"."+script0B+"."+
				script1A+"."+script1B+"."+script1C+"."+script2+"."+script3A+script3B;
			Mock<IStep> mockStep;

			TestAddSegmentToPath(p, script0A, out mockStep);
			TestAppendToPathSegment(p, script0B);

			TestAddSegmentToPath(p, script1A, out mockStep);
			TestAppendToPathSegment(p, script1B);
			TestAppendToPathSegment(p, script1C);

			TestAddSegmentToPath(p, script2, out mockStep);

			TestAddSegmentToPath(p, script3A, out mockStep);
			TestAppendToPathSegment(p, script3B, false);

			Assert.AreEqual(expect, p.Script, "Incorrect final Script.");
			Assert.AreEqual(4, p.GetSegmentCount(), "Incorrect final GetSegmentCount().");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AppendToCurrentSegmentNoSegments() {
			TestUtil.CheckThrows<Exception>(true, () => new Path().AppendToCurrentSegment("inV"));
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase("		 ")]
		public void AppendToCurrentSegmentNullEmpty(string pScript) {
			TestUtil.CheckThrows<Exception>(true, () => new Path().AppendToCurrentSegment(pScript));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetSegmentIndexOfStep() {
			var p = new Path();

			var s0 = new Mock<IStep>();
			s0.SetupGet(x => x.Path).Returns(p);
			IStep step0 = s0.Object;

			var s1 = new Mock<IStep>();
			s1.SetupGet(x => x.Path).Returns(p);
			IStep step1 = s1.Object;

			var s2 = new Mock<IStep>();
			s2.SetupGet(x => x.Path).Returns(p);
			IStep step2 = s2.Object;

			var s3 = new Mock<IStep>();
			s3.SetupGet(x => x.Path).Returns(p);
			IStep step3 = s3.Object;


			p.AddSegment(step0, "0");
			p.AddSegment(step1, "1");
			p.AddSegment(step2, "2");
			p.AddSegment(step3, "3");

			Assert.AreEqual(0, p.GetSegmentIndexOfStep(step0), "Incorrect index for step 0.");
			Assert.AreEqual(1, p.GetSegmentIndexOfStep(step1), "Incorrect index for step 1.");
			Assert.AreEqual(2, p.GetSegmentIndexOfStep(step2), "Incorrect index for step 2.");
			Assert.AreEqual(3, p.GetSegmentIndexOfStep(step3), "Incorrect index for step 3.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetSegmentIndexOfStepNone() {
			var p = new Path();

			var s0 = new Mock<IStep>();
			s0.SetupGet(x => x.Path).Returns(p);
			IStep step0 = s0.Object;

			Assert.AreEqual(-1, p.GetSegmentIndexOfStep(step0), "Incorrect index for step 0.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void TestAddSegmentToPath(IPath pPath, string pScript, out Mock<IStep> pStep) {
			string origScript = pPath.Script;
			int origSegCount = pPath.GetSegmentCount();
			string expectScript = origScript+(origScript == "" ? "" : ".")+pScript;
			int expectSegIndex = origSegCount;

			pStep = new Mock<IStep>();
			pPath.AddSegment(pStep.Object, pScript);

			Assert.AreEqual(expectScript, pPath.Script, "Incorrect Script.");
			Assert.AreEqual(origSegCount+1, pPath.GetSegmentCount(), "Incorrect GetSegmentCount().");

			IPathSegment seg = pPath.GetSegmentAt(expectSegIndex);
			Assert.AreEqual(pStep.Object, seg.Step, "Incorrect Segemnts["+expectSegIndex+"].Step.");
			Assert.AreEqual(pScript, seg.Script, "Incorrect Segemnts["+expectSegIndex+"].Script.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void TestAppendToPathSegment(IPath pPath, string pScript, bool pAddDot=true) {
			int origSegCount = pPath.GetSegmentCount();
			int expectSegIndex = origSegCount-1;
			string origSegScript = pPath.GetSegmentAt(expectSegIndex).Script;
			string expectScript = pPath.Script+(pPath.Script == "" || !pAddDot ? "" : ".")+pScript;
			string expectSegScript = origSegScript+(pAddDot ? "." : "")+pScript;
			IStep origStep = pPath.GetSegmentAt(expectSegIndex).Step;

			pPath.AppendToCurrentSegment(pScript, pAddDot);

			Assert.AreEqual(expectScript, pPath.Script, "Incorrect Script.");
			Assert.AreEqual(origSegCount, pPath.GetSegmentCount(), "Incorrect GetSegmentCount().");

			IPathSegment seg = pPath.GetSegmentAt(expectSegIndex);
			Assert.AreEqual(origStep, seg.Step, "Incorrect Segemnts["+expectSegIndex+"].Step.");
			Assert.AreEqual(expectSegScript, seg.Script,
				"Incorrect Segemnts["+expectSegIndex+"].Script.");
		}

	}

}