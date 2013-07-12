using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetUrlByPath : XModifyTasks {

		private string vPath;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Url TestGo() {
			return Tasks.GetUrlByPath(ApiCtx, vPath);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("http://zachkinstner.COM")]
		[TestCase("Http://Google.Com")]
		public void Found(string pName) {
			vPath = pName;

			Url result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vPath.ToLower(), result.FullPath.ToLower(), "Incorrect Name.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("http://zachkinstner.co")]
		[TestCase("http://gooogle.com")]
		public void NotFound(string pName) {
			vPath = pName;

			Url result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}