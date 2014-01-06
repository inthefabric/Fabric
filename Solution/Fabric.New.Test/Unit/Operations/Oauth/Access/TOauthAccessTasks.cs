using System.Collections.Generic;
using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Operations;
using Fabric.New.Operations.Oauth;
using Fabric.New.Operations.Oauth.Access;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Oauth.Access {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthAccessTasks {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;

		private OauthAccessTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockData = new Mock<IOperationData>();

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vTasks = new OauthAccessTasks();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AssertFault(TestDelegate pDelegate, AccessErrors pError, AccessErrorDescs pDesc) {
			OauthException oe = TestUtil.Throws<OauthException>(pDelegate);

			Assert.NotNull(oe.OauthError, "OauthError should filled.");
			Assert.AreEqual(pError+"", oe.OauthError.Error, "Invalid OauthError.Error");
			Assert.AreEqual(OauthAccessTasks.ErrDescStrings[(int)pDesc]+"",
				oe.OauthError.ErrorDesc, "Invalid OauthError.ErrorDesc");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAppErrBadSecret() {
			const long appId = 1234512523;
			const string secret = "asdugalsdgualsdkgulsdkug";

			vMockData
				.Setup(x => x.Get<App>(It.IsAny<IWeaverQuery>(), "OauthAccess-GetApp"))
				.Returns((App)null);

			AssertFault(() => vTasks.GetApp(vMockData.Object, appId, secret),
				AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAppSuccess() {
			const long appId = 1234512523;
			const string secret = "asdugalsdgualsdkgulsdkug";
			var app = new App();

			const string expectScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
					".has('"+DbName.Vert.App.Secret+"',Tokens.T.eq,_P);";

			var expectParams = new List<object> {
				appId,
				secret
			};

			vMockData
				.Setup(x => x.Get<App>(It.IsAny<IWeaverQuery>(), "OauthAccess-GetApp"))
				.Callback((IWeaverScript q, string n) => 
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns(app);

			App result = vTasks.GetApp(vMockData.Object, appId, secret);

			Assert.AreEqual(app, result, "Incorrect result.");
		}

	}

}