using System;
using System.Collections.Generic;
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
			var p = new Mock<IPath>();
			var s = new FuncBackStep(p.Object);

			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
			Assert.Null(s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");

			p.Verify(x => x.AddSegment(s, "back"), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePath() {
			const string alias = "X";
			const int backI = 8;
			var list = new List<int>();
			const string script = "('"+alias+"')";

			var p = new Mock<IPath>();
			var asStep = new Mock<IFuncAsStep>();
			var func = new FuncBackStep(p.Object);

			p.Setup(x => x.GetAlias(alias)).Returns(asStep.Object);
			p.Setup(x => x.GetSegmentIndexOfStep(func)).Returns(backI);
			p.Setup(x => x.GetSegmentIndexOfStep(asStep.Object)).Returns(2);
			p.Setup(x => x.GetSegmentIndexesWithStepType<FuncBackStep>(backI)).Returns(list);

			var sd = new StepData("Back("+alias+")");

			////

			func.SetDataAndUpdatePath(sd);

			////

			Assert.AreEqual(asStep.Object, func.ProxyStep, "Incorrect ProxyStep.");

			p.Verify(x => x.AppendToCurrentSegment(script, false), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathInvalid() {
			const string alias = "X";
			const string beforeAlias = "A";
			const int backI = 8;
			const int beforeBackI = 6;
			const int asI = 4;
			const int beforeAsI = 2;

			var list = new List<int>();
			list.Add(beforeBackI);

			var p = new Mock<IPath>();
			var asStep = new Mock<IFuncAsStep>();
			var beforeAsStep = new Mock<IFuncAsStep>();
			var backStep = new FuncBackStep(p.Object);
			var beforeBackStep = new Mock<IFuncBackStep>();
			beforeBackStep.SetupGet(x => x.Alias).Returns(beforeAlias);
			
			var beforeBackSegment = new Mock<IPathSegment>();
			beforeBackSegment.SetupGet(x => x.Step).Returns(beforeBackStep.Object);

			p.Setup(x => x.GetAlias(alias)).Returns(asStep.Object);
			p.Setup(x => x.GetSegmentIndexOfStep(backStep)).Returns(backI);
			p.Setup(x => x.GetSegmentIndexOfStep(asStep.Object)).Returns(asI);
			p.Setup(x => x.GetSegmentAt(beforeBackI)).Returns(beforeBackSegment.Object);
			p.Setup(x => x.GetAlias(beforeAlias)).Returns(beforeAsStep.Object);
			p.Setup(x => x.GetSegmentIndexOfStep(beforeAsStep.Object)).Returns(beforeAsI);
			p.Setup(x => x.GetSegmentIndexesWithStepType<IFuncBackStep>(backI)).Returns(list);

			var sd = new StepData("Back("+alias+")");

			////

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => backStep.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.InvalidStep, se.ErrCode, "Incorrect ErrCode.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("(1,2)")]
		public void SetDataAndUpdatePathParamCount(string pParams) {
			var p = new Mock<IPath>();
			var s = new FuncBackStep(p.Object);
			var sd = new StepData("Back"+pParams);
			
			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("abcdefghi")]
		public void SetDataAndUpdatePathLength(string pAlias) {
			var p = new Mock<IPath>();
			var s = new FuncBackStep(p.Object);
			var sd = new StepData("Back("+pAlias+")");

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("0abc")]
		[TestCase("123")]
		public void SetDataAndUpdatePathFormat(string pAlias) {
			var p = new Mock<IPath>();
			var s = new FuncBackStep(p.Object);
			var sd = new StepData("Back("+pAlias+")");

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("abc")]
		public void SetDataAndUpdatePathNoMatch(string pAlias) {
			var p = new Mock<IPath>();
			var s = new FuncBackStep(p.Object);
			var sd = new StepData("Back("+pAlias+")");

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
			Assert.AreNotEqual(-1, se.Message.IndexOf(pAlias), "Incorrect StepFault.Message.");
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