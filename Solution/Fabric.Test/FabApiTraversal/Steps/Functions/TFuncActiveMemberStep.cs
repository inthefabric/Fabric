using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncActiveMemberStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			long appId = 1234;
			long userId = 9876;
			var p = new Path() { AppId = appId, UserId = userId };
			var s = new FuncActiveMemberStep(p);
			
			string expectScript = 
				"V('"+typeof(User).Name+"Id',"+userId+"L)[0]"+
				".outE('"+typeof(UserDefinesMember).Name+"').inV"+
				".inE('"+typeof(AppDefinesMember).Name+"').outV"+
					".has('"+typeof(App).Name+"Id',Tokens.T.eq,"+appId+"L)"+
				".back(3)";
			
			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.AreEqual(expectScript, s.Path.Script, "Incorrect Path.Script.");
			Assert.Null(s.TypeId, "TypeId should be null.");
			Assert.AreEqual(typeof(FabMember), s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
			Assert.False(s.UseLocalData, "Incorrect UseLocalData.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("", true)]
		[TestCase("(1)", false)]
		[TestCase("(1,2)", false)]
		public void SetDataAndUpdatePath(string pParams, bool pPass) {
			var p = new Path();
			var s = new FuncActiveMemberStep(p);
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