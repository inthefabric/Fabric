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
	public class TFuncAsStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			var s = new FuncAsStep(p);

			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.AreEqual("as", s.Path.Script, "Incorrect Path.Script.");
			Assert.Null(s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("abc123", "as('abc123')")]
		[TestCase("x", "as('x')")]
		[TestCase("a0b1C2D3", "as('a0b1C2D3')")]
		public void SetDataAndUpdatePath(string pAlias, string pExpectSegScript) {
			var p = new Path();

			var mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabArtifact));
			p.AddSegment(mockStep.Object, "g.artifact");

			var asStep = new FuncAsStep(p);
			var sd = new StepData("As("+pAlias+")");
			asStep.SetDataAndUpdatePath(sd);

			PathSegment seg = asStep.Path.Segments[asStep.Path.Segments.Count-1];
			Assert.AreEqual(pExpectSegScript, seg.Script, "Incorrect segment Script.");
			Assert.AreEqual("FabArtifact", asStep.DtoType.Name, "Incorrect DtoType.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("(1,2)")]
		public void SetDataAndUpdatePathNoParams(string pParams) {
			var p = new Path();
			var s = new FuncAsStep(p);
			var sd = new StepData("As"+pParams);
			
			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("abcdefghi")]
		public void SetDataAndUpdatePathLength(string pAlias) {
			var p = new Path();
			var s = new FuncAsStep(p);
			var sd = new StepData("As("+pAlias+")");

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect StepException.ParamIndex.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("0abc")]
		[TestCase("123")]
		public void SetDataAndUpdatePathFormat(string pAlias) {
			var p = new Path();
			var s = new FuncAsStep(p);
			var sd = new StepData("As("+pAlias+")");
			
			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect StepException.ParamIndex.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathDuplicate() {
			const string alias = "x";
			
			var mockAs = new Mock<IFuncAsStep>();
			mockAs.SetupGet(x => x.Alias).Returns(alias);
			
			var p = new Path();
			p.RegisterAlias(mockAs.Object);
			
			var s = new FuncAsStep(p);
			var sd = new StepData("As("+alias+")");
			
			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect StepException.ParamIndex.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), true)]
		[TestCase(typeof(FabArtifact), true)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = FuncAsStep.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}