using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal {

	/*================================================================================================*/
	[TestFixture]
	public class TPathRouter {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test")]
		[TestCase("test/")]
		[TestCase("0")]
		public void GetPath1(string pUri) {
			string[] parts = pUri.Split('/');
			var mockStep0 = new Mock<IStep>();
			var mockStep1 = new Mock<IStep>();
			var mockStepLast = new Mock<TestFinalStep>();

			mockStep0.Setup(x => x.GetNextStep(parts[0], true, null)).Returns(mockStep1.Object);
			mockStep1.Setup(x => x.GetNextStep(FuncLimitStep.DefaultStepText, true, null))
				.Returns(mockStepLast.Object);

			IFinalStep resultStep = PathRouter.GetPath(mockStep0.Object, pUri);

			Assert.AreEqual(mockStepLast.Object, resultStep, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("this/a/test/path")]
		[TestCase("this/a/test/path/")]
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

			mockStep0.Setup(x => x.GetNextStep(parts[0], true, null)).Returns(mockStep1.Object);
			mockStep1.Setup(x => x.GetNextStep(parts[1], true, null)).Returns(mockStep2.Object);
			mockStep2.Setup(x => x.GetNextStep(parts[2], true, null)).Returns(mockStep3.Object);
			mockStep3.Setup(x => x.GetNextStep(parts[3], true, null)).Returns(mockStep4.Object);
			mockStep4.Setup(x => x.GetNextStep(FuncLimitStep.DefaultStepText, true, null))
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

			mockStep0.Setup(x => x.GetNextStep(parts[0], true, null)).Returns(mockStep1.Object);

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

			mockStep0.Setup(x => x.GetNextStep(parts[0], true, null)).Returns(mockStep1.Object);
			mockStep1.Setup(x => x.GetNextStep(parts[1], true, null)).Returns(mockStep2.Object);

			IFinalStep resultStep = PathRouter.GetPath(mockStep0.Object, pUri);

			Assert.AreEqual(mockStep2.Object, resultStep, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void NewRootStep(bool pStartAtRoot) {
			const long appId = 1234;
			const long userId = 65432;
			RootStep rs = PathRouter.NewRootStep(pStartAtRoot, appId, userId);

			Assert.NotNull(rs, "Result should be filled.");
			Assert.NotNull(rs.Path, "Result.Path should be filled.");
			Assert.NotNull(rs.Data, "Result.Data should be filled.");
			Assert.AreEqual("Root", rs.Data.RawString, "Incorrect Result.Data.RawString.");

			if ( pStartAtRoot ) {
				Assert.AreEqual("g.V('RootId',_P0)[0]", rs.Path.Script, "Incorrect Path.Script.");
				TestUtil.CheckParam(rs.Path.Params, "_P0", 0);
			}
			else {
				Assert.AreEqual("g", rs.Path.Script, "Incorrect Path.Script.");
			}

			Assert.AreEqual(1, rs.Path.GetSegmentCount(), "Incorrect Path.GetSegmentCount().");
			Assert.AreEqual(appId, rs.Path.AppId, "Incorrect Path.AppId.");
			Assert.AreEqual(userId, rs.Path.UserId, "Incorrect Path.UserId.");
		}

	}

}