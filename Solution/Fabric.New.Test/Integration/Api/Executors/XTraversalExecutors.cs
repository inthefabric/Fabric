using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Nancy.Testing;
using NUnit.Framework;

namespace Fabric.New.Test.Integration.Api.Executors {

	/*================================================================================================*/
	public class XTraversalExecutors : XExecutorBase {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("Apps/WithId(1)")]
		[TestCase("Users/WithName(zachkinstner)")]
		public void Free(string pPath) {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/"+pPath);
			AssertFabResponse<FabObject>(br);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Apps() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/apps");
			FabTravAppRoot result = AssertFabResponseData<FabTravAppRoot>(br);
			Assert.AreEqual(typeof(FabApp), result.GetBaseType(), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Artifacts() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/artifacts");
			FabTravArtifactRoot result = AssertFabResponseData<FabTravArtifactRoot>(br);
			Assert.AreEqual(typeof(FabArtifact), result.GetBaseType(), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Classes() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/classes");
			FabTravClassRoot result = AssertFabResponseData<FabTravClassRoot>(br);
			Assert.AreEqual(typeof(FabClass), result.GetBaseType(), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Factors() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/factors");
			FabTravFactorRoot result = AssertFabResponseData<FabTravFactorRoot>(br);
			Assert.AreEqual(typeof(FabFactor), result.GetBaseType(), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Instances() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/instances");
			FabTravInstanceRoot result = AssertFabResponseData<FabTravInstanceRoot>(br);
			Assert.AreEqual(typeof(FabInstance), result.GetBaseType(), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Members() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/members");
			FabTravMemberRoot result = AssertFabResponseData<FabTravMemberRoot>(br);
			Assert.AreEqual(typeof(FabMember), result.GetBaseType(), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Urls() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/urls");
			FabTravUrlRoot result = AssertFabResponseData<FabTravUrlRoot>(br);
			Assert.AreEqual(typeof(FabUrl), result.GetBaseType(), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Users() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/users");
			FabTravUserRoot result = AssertFabResponseData<FabTravUserRoot>(br);
			Assert.AreEqual(typeof(FabUser), result.GetBaseType(), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Vertices() {
			IsReadOnlyTest = true;

			BrowserResponse br = Get("trav/vertices");
			FabTravVertexRoot result = AssertFabResponseData<FabTravVertexRoot>(br);
			Assert.AreEqual(typeof(FabVertex), result.GetBaseType(), "Incorrect result.");
		}

	}

}