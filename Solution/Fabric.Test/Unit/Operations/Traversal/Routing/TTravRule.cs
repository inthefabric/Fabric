using System;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Traversal;
using Fabric.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Traversal.Routing {

	/*================================================================================================*/
	[TestFixture]
	public class TTravRule {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var mockStep = new Mock<ITravStep>(MockBehavior.Strict);
			Type fromType = typeof(FabArtifact);
			Type toType = typeof(FabFactor);

			var r = new TravRule(mockStep.Object, fromType, toType);

			Assert.AreEqual(mockStep.Object, r.Step, "Incorrect Step.");
			Assert.AreEqual(fromType, r.FromType, "Incorrect FromType.");
			Assert.AreEqual(toType, r.ToType, "Incorrect ToType.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null, null)]
		[TestCase(typeof(FabFactor), "FabFactor")]
		public void ToFabTravStep(Type pToType, string pExpectReturn) {
			const string cmd = "MyCommand";

			var mockStep = new Mock<ITravStep>(MockBehavior.Strict);
			mockStep.SetupGet(x => x.Command).Returns(cmd);

			var mockRule = new Mock<ITravRule>(MockBehavior.Strict);
			mockRule.SetupGet(x => x.Step).Returns(mockStep.Object);
			mockRule.SetupGet(x => x.ToType).Returns(pToType);

			FabTravStep result = TravRule.ToFabTravStep(mockRule.Object);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(cmd, result.Name, "Incorrect Name.");
			Assert.AreEqual("/"+cmd, result.Uri, "Incorrect Uri.");
			Assert.AreEqual(pExpectReturn, result.Return, "Incorrect Return.");
		}

	}

}