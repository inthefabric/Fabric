using Fabric.Api.Web;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class TAddOauthDomain : TBaseWebFunc {

		private long vAppId;
		private string vDomain;

		private App vResultApp;
		private OauthDomain vResultDomain;
		private OauthDomain vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 126264;
			vDomain = "testing.com";

			vResultApp = new App();
			vResultDomain = new OauthDomain();

			MockApiCtx
				.Setup(x => x.DbVertexById<App>(vAppId))
				.Returns(vResultApp);

			MockTasks
				.Setup(x => x.GetOauthDomainByDomain(MockApiCtx.Object, vAppId, vDomain))
				.Returns((OauthDomain)null);

			MockTasks
				.Setup(x => x.AddOauthDomain(MockApiCtx.Object, vAppId, vDomain))
				.Returns(vResultDomain);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new AddOauthDomain(MockTasks.Object, vAppId, vDomain);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.AreEqual(vResultDomain, vResult, "Incorrect result.");

			MockValidator.Verify(x => x.ArtifactId(vAppId, AddOauthDomain.AppIdParam), Times.Once());
			MockValidator.Verify(x => x.OauthDomainDomain(vDomain, AddOauthDomain.DomainParam),
				Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAppNotFound() {
			MockApiCtx.Setup(x => x.DbVertexById<App>(vAppId)).Returns((App)null);
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicateDomain() {
			MockTasks
				.Setup(x => x.GetOauthDomainByDomain(MockApiCtx.Object, vAppId, vDomain))
				.Returns(new OauthDomain());

			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}

	}

}