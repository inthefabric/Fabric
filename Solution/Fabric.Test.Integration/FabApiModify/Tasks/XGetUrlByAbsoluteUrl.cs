using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetUrlByAbsoluteUrl : XModifyTasks {

		private string vAbsoluteUrl;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Url TestGo() {
			return Tasks.GetUrlByAbsoluteUrl(ApiCtx, vAbsoluteUrl);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("http://zachkinstner.COM")]
		[TestCase("Http://Google.Com")]
		public void Found(string pName) {
			vAbsoluteUrl = pName;

			Url result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vAbsoluteUrl.ToLower(), result.AbsoluteUrl.ToLower(), "Incorrect Name.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("http://zachkinstner.co")]
		[TestCase("http://gooogle.com")]
		public void NotFound(string pName) {
			vAbsoluteUrl = pName;

			Url result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}