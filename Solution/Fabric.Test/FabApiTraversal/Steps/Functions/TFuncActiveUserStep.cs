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
	public class TFuncActiveUserStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			long userId = 1234;
			var p = new Path() { UserId = userId };
			var s = new FuncActiveUserStep(p);
			
			string expectScript = "V('"+typeof(User).Name+"Id',"+userId+"L)[0]";
			
			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.AreEqual(expectScript, s.Path.Script, "Incorrect Path.Script.");
			Assert.AreEqual(typeof(FabUser), s.DtoType, "Incorrect DtoType.");
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
			var s = new FuncActiveUserStep(p);
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