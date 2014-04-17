using System.Collections.Generic;
using Fabric.Api.Objects;
using Fabric.Operations.Traversal;
using Fabric.Test.Integration.Shared;
using NUnit.Framework;

namespace Fabric.Test.Integration.Operations.Traversal {

	/*================================================================================================*/
	public class XTraversalOperation : IntegrationTest { //TEST: XTraversalOperation


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
			UsesElasticSearch = true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("zachkinstner")]
		[TestCase("ZACHkinstner")]
		[TestCase("melkins")]
		public void UsersWithName(string pName) {
			var t = new TraversalOperation();
			IList<FabElement> results = t.Execute(OpCtx, "Users/WithName("+pName+")");

			Assert.NotNull(results, "Results should be filled.");
			Assert.AreEqual(1, results.Count, "Incorrect results count.");

			FabUser user = (results[0] as FabUser);
			Assert.NotNull(user, "Result should be a FabUser.");
			Assert.AreEqual(pName.ToLower(), user.Name.ToLower(), "Incorrect user Name.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void TakeResultCount() {
			var t = new TraversalOperation();
			IList<FabElement> results = t.Execute(OpCtx, "Users/WhereTimestamp(gt,1)/Take(3)");

			Assert.NotNull(results, "Results should be filled.");
			Assert.AreEqual(3, results.Count, "Incorrect results count.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void EntryResultCount() {
			var t = new TraversalOperation();
			IList<FabElement> results = t.Execute(OpCtx, "Vertices/WhereTimestamp(gt,1)");

			Assert.NotNull(results, "Results should be filled.");
			Assert.AreEqual(100, results.Count, "Incorrect results count.");
		}

	}

}