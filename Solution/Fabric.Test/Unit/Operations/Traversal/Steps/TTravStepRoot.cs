using System;
using Fabric.Api.Objects.Traversal;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Steps;
using Fabric.Test.Unit.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepRoot : TTravStep {

		private Type vToType;
		private TravStepRoot<FabTravFactorRoot> vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();

			vToType = typeof(FabTravFactorRoot);
			vStep = new TravStepRoot<FabTravFactorRoot>("cmd");

			MockItem.Setup(x => x.VerifyParamCount(0, -1));
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

			MockPath.Verify(x => x.AddScript(It.IsAny<string>()), Times.Never);
		}

	}

}