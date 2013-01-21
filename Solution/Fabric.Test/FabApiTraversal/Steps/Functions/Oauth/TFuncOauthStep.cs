using System;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps.Functions.Oauth;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Functions.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncOauthStep : TFuncOauthFinal {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override FuncOauthFinal NewStep(Path pPath) {
			return new FuncOauthStep(pPath);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), true)]
		[TestCase(typeof(FabOauth), false)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = FuncOauthStep.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}