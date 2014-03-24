using Fabric.New.Api.Objects;
using NUnit.Framework;
using Nancy.Testing;

namespace Fabric.New.Test.Integration.Api.Executors {

	/*================================================================================================*/
	public class XMenuExecutors : XExecutorBase {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Home() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("");
			FabClass result = AssertFabResponseData<FabClass>(br);
			Assert.AreEqual("Fabric API", result.Name, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Meta() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("meta");
			FabClass result = AssertFabResponseData<FabClass>(br);
			Assert.AreEqual("Meta", result.Name, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Mod() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("mod");
			FabClass result = AssertFabResponseData<FabClass>(br);
			Assert.AreEqual("Modify", result.Name, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Oauth() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("oauth");
			FabClass result = AssertFabResponseData<FabClass>(br);
			Assert.AreEqual("OAuth", result.Name, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Trav() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav");
			FabClass result = AssertFabResponseData<FabClass>(br);
			Assert.AreEqual("Traversal", result.Name, "Incorrect result.");
		}
		
	}

}