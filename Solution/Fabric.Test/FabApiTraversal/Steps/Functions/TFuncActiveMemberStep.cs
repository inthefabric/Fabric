using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncActiveMemberStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			const long appId = 1234;
			const long userId = 9876;
			
			var p = new Mock<IPath>();
			p.SetupGet(x => x.AppId).Returns(appId);
			p.SetupGet(x => x.UserId).Returns(userId);
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => (long)v.Original == userId)))
				.Returns("_P0");
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => (long)v.Original == appId)))
				.Returns("_P1");

			var s = new FuncActiveMemberStep(p.Object);
			
			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(FabMember), s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
			Assert.False(s.UseLocalData, "Incorrect UseLocalData.");

			string script = 
				"V('"+typeof(User).Name+"Id',_P0)"+
				".outE('"+typeof(UserDefinesMember).Name+"').inV"+
				".inE('"+typeof(AppDefinesMember).Name+"').outV"+
					".has('"+typeof(App).Name+"Id',Tokens.T.eq,_P1)"+
				".back(3)[0]";

			p.Verify(x => x.AddSegment(s, script), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("", true)]
		[TestCase("(1)", false)]
		[TestCase("(1,2)", false)]
		public void SetDataAndUpdatePath(string pParams, bool pPass) {
			var p = new Mock<IPath>();
			var s = new FuncActiveMemberStep(p.Object);
			var sd = new StepData("ActiveMember"+pParams);
			
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
			bool result = FuncActiveMemberStep.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}