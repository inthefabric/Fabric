using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TIdIndexFunc {

		// IdIndexFunc is abstract, and the subclasses are all generated. These tests use
		// the ArtifactIdIndexFunc and AppIdIndexFunc subclasses as a representative cases
		// for all of the others.


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();
			var f = new ArtifactIdIndexFunc(p.Object);

			Assert.AreEqual(p.Object, f.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(FabArtifact), f.DtoType, "Incorrect DtoType.");
			Assert.Null(f.Data, "Data should be null.");

			p.Verify(x => x.AddSegment(f, "V"), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void SetDataAndUpdatePath(bool pFabType) {
			const string propName = PropDbName.Artifact_ArtifactId;
			const long idValue = 1234;
			string fabType = (byte)VertexFabType.App+"";

			var p = new Mock<IPath>();
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText == propName)))
				.Returns("_P0");
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText == idValue+"")))
				.Returns("_P1");
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText ==PropDbName.Vertex_FabType)))
				.Returns("_P2");
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText == fabType)))
				.Returns("_P3");

			IdIndexFunc f;
			Type proxyType;

			if ( pFabType ) {
				f = new AppIdIndexFunc(p.Object);
				proxyType = typeof(AppStep);
			}
			else {
				f = new ArtifactIdIndexFunc(p.Object);
				proxyType = typeof(ArtifactStep);
			}

			var sd = new StepData("ArtifactId("+idValue+")");

			////

			f.SetDataAndUpdatePath(sd);

			////

			Assert.AreEqual(proxyType, f.ProxyStep.GetType(), "Incorrect ProxyStep type.");

			p.Verify(x => x.AppendToCurrentSegment("(_P0,_P1)", false), Times.Once());

			var times = (pFabType ? Times.Once() : Times.Never());
			p.Verify(x => x.AppendToCurrentSegment("has(_P2,_P3)", true), times);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("(1,2)")]
		public void SetDataAndUpdatePathParamCount(string pParams) {
			var p = new Mock<IPath>();
			var s = new ArtifactIdIndexFunc(p.Object);
			var sd = new StepData("ArtifactId"+pParams);

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathCannotConvert() {
			var p = new Mock<IPath>();
			var s = new ArtifactIdIndexFunc(p.Object);
			var sd = new StepData("ArtifactId(asdf)");

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamType, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
		}

	}

}