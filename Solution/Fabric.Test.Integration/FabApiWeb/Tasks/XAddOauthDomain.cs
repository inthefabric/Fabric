using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XAddOauthDomain : XWebTasks {

		private long vAppId;
		private string vDomain;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vAppId = (long)AppGal;
			vDomain = "testing.com";
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthDomain TestGo() {
			return Tasks.AddOauthDomain(ApiCtx, vAppId, vDomain);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Added() {
			OauthDomain result = TestGo();

			Assert.NotNull(result, "Result should not be null.");
			Assert.AreEqual(vDomain, result.Domain, "Incorrect Result.Domain.");

			OauthDomain newDom = GetVertex<OauthDomain>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newDom, "New OauthDomain was not created.");
			Assert.AreNotEqual(0, newDom.OauthDomainId, "Incorrect OauthDomainId.");
			Assert.AreEqual(vDomain, newDom.Domain, "Incorrect Result.Domain.");

			VertexConnections conn = GetVertexConnections(newDom);
			conn.AssertEdgeCount(0, 1);
			conn.AssertEdge<OauthDomainUsesApp, App>(true, vAppId);

			NewVertexCount = 1;
			NewEdgeCount = 1;
		}

	}

}