using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncBackStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			var s = new FuncBackStep(p);

			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.Null(s.TypeId, "TypeId should be null.");
			Assert.Null(s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1, 3, "FabFactor")]
		[TestCase(2, 4, "FabArtifact")]
		[TestCase(3, 7, "FabRoot")]
		public void SetDataAndUpdatePath(int pUriCount, int pExpectCount, string pExpectDtoType) {
			var p = new Path();

			var mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabRoot));
			p.AddSegment(mockStep.Object, "g.first"); //2 steps

			mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabArtifact));
			p.AddSegment(mockStep.Object, "second(x).has(this).and(that)"); //3 steps

			mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabFactor));
			p.AddSegment(mockStep.Object, "third(1,2)"); //1 step

			mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabDescriptor));
			p.AddSegment(mockStep.Object, "fourth.where(x,y).then(99)"); //3 steps

			var back = new FuncBackStep(p);
			var sd = new StepData("Back("+pUriCount+")");
			back.SetDataAndUpdatePath(sd);

			PathSegment seg = back.Path.Segments[back.Path.Segments.Count-1];
			Assert.AreEqual(pExpectCount, back.Count, "Incorrect Count.");
			Assert.AreEqual("back("+pExpectCount+")", seg.Script, "Incorrect segment Script.");
			Assert.AreEqual(pExpectDtoType, back.DtoType.Name, "Incorrect DtoType.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1, 2, "FabUser")]
		[TestCase(2, 4, "FabArtifact")]
		[TestCase(3, 6, "FabRoot")]
		public void SetDataAndUpdatePathFuncs(int pUriCount, int pExpectCount, string pExpectDtoType) {
			var p = new Path();

			var mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabRoot));
			p.AddSegment(mockStep.Object, "g.v(0)"); //2 steps

			mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabArtifact));
			p.AddSegment(mockStep.Object, "outE('RootContainsArtifact').inV"); //2 steps

			mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabUser));
			p.AddSegment(mockStep.Object, "inE('UserHasArtifact').outV"); //2 steps

			mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabUser));
			p.AddSegment(mockStep.Object, "dedup[0..9]"); //2 steps

			var back = new FuncBackStep(p);
			var sd = new StepData("Back("+pUriCount+")");
			back.SetDataAndUpdatePath(sd);

			PathSegment seg = back.Path.Segments[back.Path.Segments.Count-1];
			Assert.AreEqual(pExpectCount, back.Count, "Incorrect Count.");
			Assert.AreEqual("back("+pExpectCount+")", seg.Script, "Incorrect segment Script.");
			Assert.AreEqual(pExpectDtoType, back.DtoType.Name, "Incorrect DtoType.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("(1,2)")]
		public void SetDataAndUpdatePathNoParams(string pParams) {
			var p = new Path();
			var s = new FuncBackStep(p);
			var sd = new StepData("back"+pParams);
			
			StepFault se =
				TestUtil.CheckThrows<StepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathCannotConvert() {
			var p = new Path();
			var s = new FuncBackStep(p);
			var sd = new StepData("back(i)");

			StepFault se =
				TestUtil.CheckThrows<StepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamType, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect ParamIndex.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public void SetDataAndUpdatePathLessThanOne(int pCount) {
			var p = new Path();
			var s = new FuncBackStep(p);
			var sd = new StepData("back("+pCount+")");

			StepFault se =
				TestUtil.CheckThrows<StepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect ParamIndex.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathBackTooFar() {
			var p = new Path();
			p.AddSegment(null, "first");
			p.AddSegment(null, "second(x).has(x,y,z).and(1,2,3)");
			p.AddSegment(null, "third(1,2)");

			var s = new FuncBackStep(p);
			var sd = new StepData("back(3)");

			StepFault se =
				TestUtil.CheckThrows<StepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect ParamIndex.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), false)]
		[TestCase(typeof(FabArtifact), true)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = FuncBackStep.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}