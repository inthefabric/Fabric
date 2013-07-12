using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TExactIndexFunc {

		// ExactIndexFunc is abstract, and the subclasses are all generated. These tests use
		// the ApNKExactIndexFunc subclass as a representative case for all of the others.


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();
			var f = new ApNKExactIndexFunc(p.Object);

			Assert.AreEqual(p.Object, f.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(FabApp), f.DtoType, "Incorrect DtoType.");
			Assert.Null(f.Data, "Data should be null.");

			p.Verify(x => x.AddSegment(f, "V"), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePath() {
			const string appName = "TEST app";

			var p = new Mock<IPath>();
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText == PropDbName.App_NameKey)))
				.Returns("_P0");
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText == appName.ToLower())))
				.Returns("_P1");

			var f = new ApNKExactIndexFunc(p.Object);
			var sd = new StepData("AppName("+appName+")");

			////

			f.SetDataAndUpdatePath(sd);

			////

			Assert.AreEqual(typeof(AppStep), f.ProxyStep.GetType(), "Incorrect ProxyStep type.");

			p.Verify(x => x.AppendToCurrentSegment("(_P0,_P1)", false), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("(1,2)")]
		public void SetDataAndUpdatePathParamCount(string pParams) {
			var p = new Mock<IPath>();
			var s = new ApNKExactIndexFunc(p.Object);
			var sd = new StepData("AppName"+pParams);

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), true)]
		[TestCase(typeof(FabArtifact), false)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = ExactIndexFunc.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}