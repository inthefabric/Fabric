using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Functions;
using Fabric.Api.Paths.Steps.Nodes;
using Fabric.Test.Common;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiPaths {

	/*================================================================================================*/
	[TestFixture]
	public class TPathRouter {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test")]
		[TestCase("0")]
		public void GetPath1(string pUri) {
			string[] parts = pUri.Split('/');
			var mockStep0 = new Mock<IStep>();
			var mockStep1 = new Mock<IStep>();
			var mockStepLast = new Mock<TestFinalStep>();

			mockStep0.Setup(x => x.GetNextStep(parts[0], true)).Returns(mockStep1.Object);
			mockStep1.Setup(x => x.GetNextStep(FuncLimitStep.DefaultStepText, true))
				.Returns(mockStepLast.Object);

			IFinalStep resultStep = PathRouter.GetPath(mockStep0.Object, pUri);

			Assert.AreEqual(mockStepLast.Object, resultStep, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("this/a/test/path")]
		[TestCase("0/1/2/3")]
		[TestCase("ContainsArtifactList/InUserHas/InMemberListUses/CreatedFactorList")]
		public void GetPath4(string pUri) {
			string[] parts = pUri.Split('/');
			var mockStep0 = new Mock<IStep>();
			var mockStep1 = new Mock<IStep>();
			var mockStep2 = new Mock<IStep>();
			var mockStep3 = new Mock<IStep>();
			var mockStep4 = new Mock<IStep>();
			var mockStepLast = new Mock<TestFinalStep>();

			mockStep0.Setup(x => x.GetNextStep(parts[0], true)).Returns(mockStep1.Object);
			mockStep1.Setup(x => x.GetNextStep(parts[1], true)).Returns(mockStep2.Object);
			mockStep2.Setup(x => x.GetNextStep(parts[2], true)).Returns(mockStep3.Object);
			mockStep3.Setup(x => x.GetNextStep(parts[3], true)).Returns(mockStep4.Object);
			mockStep4.Setup(x => x.GetNextStep(FuncLimitStep.DefaultStepText, true))
				.Returns(mockStepLast.Object);

			IFinalStep resultStep = PathRouter.GetPath(mockStep0.Object, pUri);

			Assert.AreEqual(mockStepLast.Object, resultStep, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("Limit(0,30)")]
		[TestCase("Limit(10,5)")]
		public void GetPath1WithIncludedFinalStep(string pUri) {
			string[] parts = pUri.Split('/');
			var mockStep0 = new Mock<IStep>();
			var mockStep1 = new Mock<TestFinalStep>();

			mockStep0.Setup(x => x.GetNextStep(parts[0], true)).Returns(mockStep1.Object);

			IFinalStep resultStep = PathRouter.GetPath(mockStep0.Object, pUri);

			Assert.AreEqual(mockStep1.Object, resultStep, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test/Limit(0,30)")]
		[TestCase("asdf/Limit(10,5)")]
		public void GetPath2WithIncludedFinalStep(string pUri) {
			string[] parts = pUri.Split('/');
			var mockStep0 = new Mock<IStep>();
			var mockStep1 = new Mock<IStep>();
			var mockStep2 = new Mock<TestFinalStep>();

			mockStep0.Setup(x => x.GetNextStep(parts[0], true)).Returns(mockStep1.Object);
			mockStep1.Setup(x => x.GetNextStep(parts[1], true)).Returns(mockStep2.Object);

			IFinalStep resultStep = PathRouter.GetPath(mockStep0.Object, pUri);

			Assert.AreEqual(mockStep2.Object, resultStep, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewRootStep() {
			RootStep rs = PathRouter.NewRootStep();

			Assert.NotNull(rs, "Result should be filled.");
			Assert.NotNull(rs.Path, "Result.Path should be filled.");
			Assert.AreEqual("g.v(0)", rs.Path.Script, "Incorrect Path.Script.");
			Assert.AreEqual(1, rs.Path.Segments.Count, "Incorrect Path.Segments.Count.");
		}

	}

}