using Fabric.Api.Objects;
using Fabric.Api.Objects.Traversal;
using NUnit.Framework;
using Nancy.Testing;

namespace Fabric.Test.Integration.Api.Executors {

	/*================================================================================================*/
	public class XTraversalExecutors : XExecutorBase {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("Apps/WithId(3)")]
		[TestCase("Users/WithName(zachkinstner)")]
		public void FreeWithOneResult(string pPath) {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/"+pPath);
			AssertFabResponseData<FabVertex>(br);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Apps() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/apps");
			AssertFabResponse<FabTravAppRoot>(br);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Artifacts() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/artifacts");
			AssertFabResponse<FabTravArtifactRoot>(br);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Classes() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/classes");
			AssertFabResponse<FabTravClassRoot>(br);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Factors() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/factors");
			AssertFabResponse<FabTravFactorRoot>(br);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Instances() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/instances");
			AssertFabResponse<FabTravInstanceRoot>(br);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Members() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/members");
			AssertFabResponse<FabTravMemberRoot>(br);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Urls() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/urls");
			AssertFabResponse<FabTravUrlRoot>(br);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Users() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/users");
			AssertFabResponse<FabTravUserRoot>(br);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Vertices() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/vertices");
			AssertFabResponse<FabTravVertexRoot>(br);
		}

	}

}