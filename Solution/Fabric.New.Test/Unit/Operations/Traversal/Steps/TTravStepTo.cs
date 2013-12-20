using System;
using Fabric.New.Api.Objects;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Steps;
using Fabric.New.Test.Unit.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepTo : TTravStep {

		private string vVertTypeProp;
		private VertexType.Id vVertType;
		private string vVertTypePropParam;
		private string vVertTypeParam;
		private string vScript;
		private Type vToType;
		private TravStepTo<FabFactor, FabArtifact> vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();

			vVertType = VertexType.Id.Factor;
			vVertTypeProp = DbName.Vert.Vertex.VertexType;
			vVertTypePropParam = "_P0";
			vVertTypeParam = "_P1";
			vScript = ".has("+vVertTypePropParam+", Tokens.T.eq, "+vVertTypeParam+")";
			vToType = typeof(FabArtifact);
			vStep = new TravStepTo<FabFactor, FabArtifact>("cmd", vVertType);

			MockItem.Setup(x => x.VerifyParamCount(0, -1));

			MockPath.Setup(x => x.AddParam(vVertTypeProp)).Returns(vVertTypePropParam);
			MockPath.Setup(x => x.AddParam(vVertType)).Returns(vVertTypeParam);
			MockPath.Setup(x => x.AddScript(vScript));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override ITravStep GetStep() {
			return vStep;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Type GetToType() {
			return vToType;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckSuccess(bool pSuccess) {
			Times t = (pSuccess ? Times.Once() : Times.Never());

			MockItem.Verify(x => x.VerifyParamCount(0, -1), Times.Once);

			MockPath.Verify(x => x.AddParam(vVertType), t);
			MockPath.Verify(x => x.AddParam(vVertTypeProp), t);
			MockPath.Verify(x => x.AddScript(vScript), t);
		}

	}

}