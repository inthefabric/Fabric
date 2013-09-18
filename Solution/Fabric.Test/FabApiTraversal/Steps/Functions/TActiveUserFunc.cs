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
	public class TActiveUserFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();

			var s = new ActiveUserFunc(p.Object);

			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(FabUser), s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
			Assert.False(s.UseLocalData, "Incorrect UseLocalData.");

			p.Verify(x => x.AddSegment(s, "V"), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePath() {
			const string propName = PropDbName.Artifact_ArtifactId;
			const long idValue = 1234;

			var p = new Mock<IPath>();
			p.SetupGet(x => x.UserId).Returns(idValue);
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText == propName)))
				.Returns("_P0");
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => v.RawText == idValue+"")))
				.Returns("_P1");

			var f = new ActiveUserFunc(p.Object);
			var sd = new StepData("ActiveUser()");

			////

			f.SetDataAndUpdatePath(sd);

			////

			Assert.AreEqual(typeof(UserStep), f.ProxyStep.GetType(), "Incorrect ProxyStep type.");

			p.Verify(x => x.AppendToCurrentSegment("(_P0,_P1)", false), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("", true)]
		[TestCase("(1)", false)]
		[TestCase("(1,2)", false)]
		public void SetDataAndUpdatePathParamCount(string pParams, bool pPass) {
			var p = new Mock<IPath>();
			var s = new ActiveUserFunc(p.Object);
			var sd = new StepData("ActiveUser"+pParams);

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(!pPass, () => s.SetDataAndUpdatePath(sd));

			if ( !pPass ) {
				Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
			}
		}

	}

}