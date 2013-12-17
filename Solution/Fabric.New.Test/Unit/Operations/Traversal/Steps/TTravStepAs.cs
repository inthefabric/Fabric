using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Steps;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepAs {

		private static readonly Logger Log = Logger.Build<TTravStepAs>();

		private string vAlias;
		private string vAliasParam;
		private string vScript;
		private Type vToType;
		private Mock<ITravPathItem> vMockItem;
		private Mock<ITravPath> vMockPath;
		private TravStepAs vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vAlias = "test";
			vAliasParam = "_P0";
			vScript = ".as("+vAliasParam+")";
			vToType = typeof(FabFactor);

			vMockItem = new Mock<ITravPathItem>(MockBehavior.Strict);
			vMockItem.Setup(x => x.VerifyParamCount(1, -1));
			vMockItem.Setup(x => x.GetParamAt<string>(0)).Returns(vAlias);

			var items = new List<ITravPathItem>();
			items.Add(vMockItem.Object);

			vMockPath = new Mock<ITravPath>(MockBehavior.Strict);
			vMockPath.Setup(x => x.ConsumeSteps(1, vToType)).Returns(items);
			vMockPath.Setup(x => x.HasAlias(vAlias)).Returns(false);
			vMockPath.Setup(x => x.AddAlias(vAlias));
			vMockPath.Setup(x => x.AddParam(vAlias)).Returns(vAliasParam);
			vMockPath.Setup(x => x.AddScript(vScript));

			vStep = new TravStepAs();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CheckSuccess(bool pSuccess) {
			Times t = (pSuccess ? Times.Once() : Times.Never());

			vMockPath.Verify(x => x.AddAlias(vAlias), t);
			vMockPath.Verify(x => x.AddParam(vAlias), t);
			vMockPath.Verify(x => x.AddScript(vScript), t);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			vStep.ConsumePath(vMockPath.Object, vToType);
			CheckSuccess(true);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorDuplicateAlias() {
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);

			vMockPath.Setup(x => x.HasAlias(vAlias)).Returns(true);

			vMockItem
				.Setup(x => x.NewStepFault(f.ErrCode, It.IsAny<string>(), f.ParamIndex, null))
				.Returns(f);

			FabStepFault faultResult = TestUtil.Throws<FabStepFault>(
				() => vStep.ConsumePath(vMockPath.Object, vToType));

			Assert.AreEqual(f, faultResult, "Incorrect fault result.");
			CheckSuccess(false);
		}

	}

}