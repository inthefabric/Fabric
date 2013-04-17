using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncActiveUserStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			const long userId = 1234;
			
			var p = new Mock<IPath>();
			p.SetupGet(x => x.UserId).Returns(userId);
			p.Setup(x => x.AddParam(It.IsAny<IWeaverQueryVal>())).Returns("_P0");

			var s = new FuncActiveUserStep(p.Object);
			
			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(FabUser), s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
			Assert.False(s.UseLocalData, "Incorrect UseLocalData.");

			string script = "V('"+PropDbName.User_UserId+"',_P0)";
			p.Verify(x => x.AddSegment(s, script), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("", true)]
		[TestCase("(1)", false)]
		[TestCase("(1,2)", false)]
		public void SetDataAndUpdatePath(string pParams, bool pPass) {
			var p = new Mock<IPath>();
			var s = new FuncActiveUserStep(p.Object);
			var sd = new StepData("ActiveUser"+pParams);
			
			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(!pPass, () => s.SetDataAndUpdatePath(sd));
				
			if ( !pPass ) {
				Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), true)]
		[TestCase(typeof(FabArtifact), false)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = FuncActiveUserStep.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}