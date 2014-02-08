using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Operations.Oauth;
using Fabric.New.Operations.Oauth.Logout;
using Fabric.New.Test.Integration.Shared;
using Fabric.New.Test.Unit.Shared;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;

namespace Fabric.New.Test.Integration.Operations.Oauth.Logout {

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

				IDataResult dr1 = OpCtx.Data.Execute(q1, "Test-OauthLogoutOperation");
				IDataResult dr2 = OpCtx.Data.Execute(q2, "Test-OauthLogoutOperation");

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