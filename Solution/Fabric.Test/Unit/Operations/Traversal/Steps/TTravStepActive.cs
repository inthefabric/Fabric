using System;
using Fabric.Api.Objects;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Faults;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Steps;
using Fabric.Test.Unit.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepActive : TTravStep {

		private long? vMemId;
		private string vVertIdProp;
		private string vVertIdParam;
		private string vMemIdParam;
		private string vScript;
		private Type vToType;
		private TravStepActive vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();

			vMemId = 34223462346;
			vVertIdProp = DbName.Vert.Vertex.VertexId;
			vVertIdParam = "_P0";
			vMemIdParam = "_P1";
			vScript = ".has("+vVertIdParam+", "+vMemIdParam+")";
			vToType = typeof(FabMember);
			vStep = new TravStepActive();

			MockItem.Setup(x => x.VerifyParamCount(0, -1));

			MockPath.SetupGet(x => x.MemberId).Returns(vMemId);
			MockPath.Setup(x => x.AddParam(vVertIdProp)).Returns(vVertIdParam);
			MockPath.Setup(x => x.AddParam(vMemId)).Returns(vMemIdParam);
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

			MockPath.Verify(x => x.AddParam(vVertIdProp), t);
			MockPath.Verify(x => x.AddParam(vMemId), t);
			MockPath.Verify(x => x.AddScript(vScript), t);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorNoActiveMember() {
			vMemId = null;
			MockPath.SetupGet(x => x.MemberId).Returns(vMemId);

			var f = new FabStepFault(FabFault.Code.InvalidStep, 0, "", "");
			SetupFault(f, "active");

			CheckConsumePathThrows(f);
		}

	}

}