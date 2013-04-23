using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XUpdateAppSecret : XWebTasks {

		private long vAppId;
		private string vSecret;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vAppId = (long)AppGal;
			vSecret = "abcdefgHIJKLMNOPqrsTUVwxyz12345678";
		}

		/*--------------------------------------------------------------------------------------------*/
		private App TestGo() {
			return Tasks.UpdateAppSecret(ApiCtx, vAppId, vSecret);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Updated() {
			App oldApp = GetNode<App>(vAppId);
			Assert.NotNull(oldApp, "Target App is missing.");
			Assert.AreNotEqual(vSecret, oldApp.Secret, "Target App.Secret is incorrect.");

			App result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vAppId, result.AppId, "Incorrect AppId.");
			Assert.AreEqual(vSecret, result.Secret, "Incorrect Secret.");

			App upApp = GetNode<App>(vAppId);
			Assert.AreEqual(vSecret, upApp.Secret, "Target App.Secret not updated.");
		}

	}

}