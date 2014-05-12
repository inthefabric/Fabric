using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Query;
using Fabric.Operations.Web;
using Fabric.Test.Integration.Shared;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Test.Integration.Operations.Web {

	/*================================================================================================*/
	public class XWebUpdateAppDomainsOperation : IntegrationTest {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessAdd() {
			const long appId = (long)SetupAppId.KinPhoGal;
			const string addDom = "test.com";
			const string expectDoms = SetupOauth.DomGal1+"|"+SetupOauth.DomGal2+"|"+addDom;

			var op = new WebUpdateAppDomainsOperation();
			App result = op.ExecuteAdd(OpCtx, appId, addDom);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(appId, result.VertexId, "Incorrect VertexId.");
			Assert.AreEqual(expectDoms, result.OauthDomains, result.OauthDomains, addDom);

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, result.VertexId)
					.Has(x => x.OauthDomains, WeaverStepHasOp.EqualTo, expectDoms)
				.ToQuery();

			VerificationQueryFunc = () => {
				IDataResult dr = OpCtx.ExecuteForTest(verify, "AddAppDomain-Verify");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New element not verified.");
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessRemove() {
			const long appId = (long)SetupAppId.Bookmarker;
			const string removeDom = SetupOauth.DomBook1;
			const string expectDoms = SetupOauth.DomBook2;

			var op = new WebUpdateAppDomainsOperation();
			App result = op.ExecuteRemove(OpCtx, appId, removeDom);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(appId, result.VertexId, "Incorrect VertexId.");
			Assert.AreEqual(expectDoms, result.OauthDomains, "Incorrect OauthDomains.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, result.VertexId)
					.Has(x => x.OauthDomains, WeaverStepHasOp.EqualTo, expectDoms)
				.ToQuery();

			VerificationQueryFunc = () => {
				IDataResult dr = OpCtx.ExecuteForTest(verify, "RemoveAppDomain-Verify");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New element not verified.");
			};
		}

	}

}