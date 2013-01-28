using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XGetAppByName : IntegTestBase {

		private string vName;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private App TestGo() {
			return new ModifyTasks().GetAppByName(Context, vName);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("KINSTNER photo GallerY")]
		[TestCase("fabric system")]
		public void Found(string pName) {
			vName = pName;

			App result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vName.ToLower(), result.Name.ToLower(), "Incorrect Name.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("Kinstner Photo Galleryy")]
		[TestCase("Kinstner Photo Galler")]
		public void NotFound(string pName) {
			vName = pName;

			App result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}