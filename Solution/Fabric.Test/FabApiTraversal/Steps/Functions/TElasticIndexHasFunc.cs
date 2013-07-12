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
	public class TElasticIndexHasFunc {

		// ElasticIndexHasFunc is abstract, and the subclasses are all generated. These tests use
		// the ACrElasticIndexFunc subclass as a representative case for all of the others.


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();
			var f = new ACrElasticIndexFunc(p.Object);

			Assert.AreEqual(p.Object, f.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(FabArtifact), f.DtoType, "Incorrect DtoType.");
			Assert.Null(f.Data, "Data should be null.");

			p.Verify(x => x.AddSegment(f, "query()"), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("gt", "GREATER_THAN")]
		[TestCase("gte", "GREATER_THAN_EQUAL")]
		[TestCase("lt", "LESS_THAN")]
		[TestCase("lte", "LESS_THAN_EQUAL")]
		[TestCase("eq", "EQUAL")]
		[TestCase("neq", "NOT_EQUAL")]
		public void SetDataAndUpdatePath(string pOper, string pExpectOper) {
			const string propName = PropDbName.Artifact_Created;
			const string value = "12345";

			var p = new Mock<IPath>();
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText == propName)))
				.Returns("_P0");
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText == value)))
				.Returns("_P1");

			string script = "has(_P0,"+
				ElasticIndexFunc.CompareNamespace+pExpectOper+",_P1)";

			var f = new ACrElasticIndexFunc(p.Object);
			var sd = new StepData("ArtifactCreated("+pOper+","+value+")");

			////

			f.SetDataAndUpdatePath(sd);

			////

			Assert.AreEqual(typeof(ArtifactStep), f.ProxyStep.GetType(), "Incorrect ProxyStep type.");

			p.Verify(x => x.AddSegment(f, script), Times.Once());
			p.Verify(x => x.AddSegment(f, "vertices()"), Times.Once());
			p.Verify(x => x.AddSegment(f, "_()"), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("(1)")]
		[TestCase("(1,2,3)")]
		public void SetDataAndUpdatePathParamCount(string pParams) {
			var p = new Mock<IPath>();
			var s = new ACrElasticIndexFunc(p.Object);
			var sd = new StepData("ArtifactCreated"+pParams);

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathCannotConvert() {
			var p = new Mock<IPath>();
			var s = new ACrElasticIndexFunc(p.Object);
			var sd = new StepData("ArtifactCreated(eq,asdf)");

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamType, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(1, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathInvalidOper() {
			var p = new Mock<IPath>();
			var s = new ACrElasticIndexFunc(p.Object);
			var sd = new StepData("ArtifactCreated(asdf,1)");

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
		}

	}

}