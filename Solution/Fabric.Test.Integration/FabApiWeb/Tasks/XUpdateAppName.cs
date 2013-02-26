using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XUpdateAppName : XWebTasks {

		private long vAppId;
		private string vName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vAppId = (long)AppGal;
			vName = "MyNewName!";
		}

		/*--------------------------------------------------------------------------------------------*/
		private App TestGo() {
			return Tasks.UpdateAppName(ApiCtx, vAppId, vName);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Updated() {
			App oldApp = GetNode<App>(vAppId);
			Assert.NotNull(oldApp, "Target App is missing.");
			Assert.AreNotEqual(vName, oldApp.Name, "Target App.Name is incorrect.");

			App result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vAppId, result.AppId, "Incorrect AppId.");
			Assert.AreEqual(vName, result.Name, "Incorrect Name.");

			App upApp = GetNode<App>(vAppId);
			Assert.AreEqual(vName, upApp.Name, "Target App.Name not updated.");
		}

	}

}