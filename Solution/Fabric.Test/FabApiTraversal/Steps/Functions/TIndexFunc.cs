using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Functions;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), true)]
		[TestCase(typeof(FabArtifact), false)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = IndexFunc.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}