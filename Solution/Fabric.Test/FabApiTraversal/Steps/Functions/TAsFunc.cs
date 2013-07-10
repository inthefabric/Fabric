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
	public class TAsFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();
			var s = new AsFunc(p.Object);

			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
			Assert.Null(s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");

			p.Verify(x => x.AddSegment(s, "as"), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("abc123", "('abc123')")]
		[TestCase("x", "('x')")]
		[TestCase("a0b1C2D3", "('a0b1C2D3')")]
		public void SetDataAndUpdatePath(string pAlias, string pExpectScript) {
			var proxy = new Mock<IStep>();
			var proxySeg = new Mock<IPathSegment>();
			proxySeg.SetupGet(x => x.Step).Returns(proxy.Object);

			var p = new Mock<IPath>();
			p.Setup(x => x.GetSegmentBeforeLast(1)).Returns(proxySeg.Object);

			var asStep = new AsFunc(p.Object);
			var sd = new StepData("As("+pAlias+")");

			////

			asStep.SetDataAndUpdatePath(sd);

			////

			Assert.AreEqual(proxy.Object, asStep.ProxyStep, "Incorrect ProxyStep.");

			p.Verify(x => x.AppendToCurrentSegment(pExpectScript, false), Times.Once());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("(1,2)")]
		public void SetDataAndUpdatePathNoParams(string pParams) {
			var p = new Mock<IPath>();
			var s = new AsFunc(p.Object);
			var sd = new StepData("As"+pParams);
			
			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("abcdefghi")]
		public void SetDataAndUpdatePathLength(string pAlias) {
			var p = new Mock<IPath>();
			var s = new AsFunc(p.Object);
			var sd = new StepData("As("+pAlias+")");

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
			var s = new AsFunc(p.Object);
			var sd = new StepData("As("+pAlias+")");
			
			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathDuplicate() {
			const string alias = "x";
			
			var mockAs = new Mock<IFuncAsStep>();
			mockAs.SetupGet(x => x.Alias).Returns(alias);
			
			var p = new Mock<IPath>();
			p.Setup(x => x.GetAlias(alias)).Returns(mockAs.Object); //non-null result

			var s = new AsFunc(p.Object);
			var sd = new StepData("As("+alias+")");
			
			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), false)]
		[TestCase(typeof(FabArtifact), true)]
		[TestCase(typeof(FabClass), true)]
		[TestCase(typeof(FabFactor), true)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = AsFunc.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}