using System;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps.Functions.Oauth;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Functions.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncOauthAtrStep : TFuncOauthFinal {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override FuncOauthFinal NewStep(Path pPath) {
			return new FuncOauthAtrStep(pPath);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), false)]
		[TestCase(typeof(FabOauth), true)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = FuncOauthAtrStep.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}