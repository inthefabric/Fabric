using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XGetUserByName : IntegTestBase {

		private string vName;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private User TestGo() {
			return new ModifyTasks().GetUserByName(Context, vName);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("ZachKinstner")]
		[TestCase("MELkins")]
		public void Found(string pName) {
			vName = pName;

			User result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vName.ToLower(), result.Name.ToLower(), "Incorrect Name.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("zachkinstnerr")]
		[TestCase("melkin")]
		public void NotFound(string pName) {
			vName = pName;

			User result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}