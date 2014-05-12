using Fabric.Api.Objects.Oauth;
using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Query;
using Fabric.Operations.Oauth;
using Fabric.Test.Integration.Shared;
using Fabric.Test.Unit.Shared;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.Operations.Oauth {

	/*================================================================================================*/
	public class XOauthLogoutOperation : IntegrationTest {

		private OauthLogoutTasks vTasks;
		private string vToken;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			vTasks = new OauthLogoutTasks();
			vToken = SetupOauth.TokenFabZach;
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthLogout ExecuteOperation() {
			var op = new OauthLogoutOperation();
			return op.Execute(OpCtx, vTasks, vToken);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			FabOauthLogout result = ExecuteOperation();

			Assert.AreEqual(1, result.Success, "Incorrect Success.");
			Assert.AreEqual(vToken, result.AccessToken, "Incorrect AccessToken.");

			VerificationQueryFunc = () => {
				IWeaverQuery q1 = Weave.Inst.Graph
					.V.ExactIndex<Member>(x => x.VertexId, (long)SetupMemberId.FabZach)
					.AuthenticatedByOauthAccesses.ToOauthAccess
						.Has(x => x.Token)
					.ToQuery();

				IWeaverQuery q2 = Weave.Inst.Graph
					.V.ExactIndex<Member>(x => x.VertexId, (long)SetupMemberId.FabZach)
					.AuthenticatedByOauthAccesses.ToOauthAccess
						.Has(x => x.Refresh)
					.ToQuery();

				IDataResult dr1 = OpCtx.ExecuteForTest(q1, "OauthLogoutOperation-Token");
				IDataResult dr2 = OpCtx.ExecuteForTest(q2, "OauthLogoutOperation-Refresh");

				Assert.AreEqual(0, dr1.GetCommandResultCount(), "Tokens were not cleared.");
				Assert.AreEqual(0, dr2.GetCommandResultCount(), "Refresh were not cleared.");
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNoTokenMatch() {
			IsReadOnlyTest = true;
			vToken = "12345678901234567890123456789012";
			OauthException e = TestUtil.Throws<OauthException>(() => ExecuteOperation());

			Assert.AreEqual(LogoutErrors.invalid_request.ToString(), e.OauthError.Error,
				"Incorrect Error.");
			Assert.AreEqual(OauthLogoutTasks.ErrDescStrings[(int)LogoutErrorDescs.NoTokenMatch],
				e.OauthError.ErrorDesc, "Incorrect ErrorDesc.");
		}

	}

}