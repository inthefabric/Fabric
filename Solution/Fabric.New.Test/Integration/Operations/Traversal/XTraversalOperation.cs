using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Operations.Traversal;
using Fabric.New.Test.Integration.Shared;
using NUnit.Framework;

namespace Fabric.New.Test.Integration.Operations.Traversal {

	/*================================================================================================*/
	public class XTraversalOperation : IntegrationTest {

		private static readonly Logger Log = Logger.Build<XTraversalOperation>();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("zachkinstner")]
		[TestCase("ZACHkinstner")]
		[TestCase("melkins")]
		public void UsersWithName(string pName) {
			var t = new TraversalOperation();
			t.Perform(OpCtx, "Users/WithName("+pName+")");
			IList<FabElement> results = t.GetResult();

			Assert.NotNull(results, "Results should be filled.");
			Assert.AreEqual(1, results.Count, "Incorrect results count.");

			FabUser user = (results[0] as FabUser);
			Assert.NotNull(user, "Result should be a FabUser.");
			Assert.AreEqual(pName.ToLower(), user.Name.ToLower(), "Incorrect user Name.");
		}

	}

}