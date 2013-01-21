using System;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps.Functions.Oauth;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Functions.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncOauthAtStep : TFuncOauthFinal {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override FuncOauthFinal NewStep(Path pPath) {
			return new FuncOauthAtStep(pPath);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), false)]
		[TestCase(typeof(FabOauth), true)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = FuncOauthAtStep.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}