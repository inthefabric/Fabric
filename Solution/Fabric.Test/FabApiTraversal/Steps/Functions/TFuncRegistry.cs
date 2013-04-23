using System;
using System.Collections.Generic;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncRegistry {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, new[] { "/ActiveApp", "/ActiveUser", "/ActiveMember", "/As" })]
		[TestCase(false, new[] { "activeapp", "activeuser", "activemember", "as" })]
		public void GetAvailableFuncsForRoot(bool pUri, string[] pExpect) {
			var p = new Mock<IPath>();
			var art = new RootStep(p.Object);
			List<string> result = FuncRegistry.GetAvailableFuncs(art, pUri, true);
			Assert.AreEqual(pExpect, result, "Incorrect result.");

			result = FuncRegistry.GetAvailableFuncs(typeof(FabRoot), pUri, true);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, new[] { "/As", "/Back", "/Limit", "/WhereId",
			"/WhereApp", "/WhereClass", "/WhereInstance", "/WhereUrl", "/WhereUser" })]
		[TestCase(false, new[] { "as", "back", "limit", "whereid",
			"whereapp", "whereclass", "whereinstance", "whereurl", "whereuser" })]
		public void GetAvailableFuncsForArtifact(bool pUri, string[] pExpect) {
			var p = new Mock<IPath>();
			var art = new ArtifactStep(p.Object);

			List<string> result = FuncRegistry.GetAvailableFuncs(art, pUri, true);
			Assert.AreEqual(pExpect, result, "Incorrect result.");

			result = FuncRegistry.GetAvailableFuncs(typeof(FabArtifact), pUri, true);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void GetAvailableFuncsNotFabNode(bool pUri) {
			TestUtil.CheckThrows<Exception>(true, () =>
				FuncRegistry.GetAvailableFuncs(typeof(string), pUri, true));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("activeapp", typeof(FuncActiveAppStep))]
		[TestCase("activeuser", typeof(FuncActiveUserStep))]
		[TestCase("activemember", typeof(FuncActiveMemberStep))]
		[TestCase("back", typeof(FuncBackStep))]
		[TestCase("limit", typeof(FuncLimitStep))]
		public void GetFuncStep(string pCommand, Type pExpectType) {
			var p = new Mock<IPath>();
			IStep result = FuncRegistry.GetFuncStep(pCommand, p.Object);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(pExpectType, result.GetType(), "Incorrect result type.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetFuncStepNotFound() {
			IStep result = FuncRegistry.GetFuncStep("abcd", null);
			Assert.Null(result, "Result should be null.");
		}

	}

}