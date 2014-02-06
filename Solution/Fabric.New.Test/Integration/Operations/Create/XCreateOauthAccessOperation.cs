using Fabric.New.Api.Objects;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Operations.Create;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.New.Test.Integration.Operations.Create {

	/*================================================================================================*/
	public class XCreateOauthAccessOperation : XCreateOperation<OauthAccess> {

		private CreateFabOauthAccess vCreateOauthAccess;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vCreateOauthAccess = new CreateFabOauthAccess();
			vCreateOauthAccess.AuthenticatesMemberId = (long)SetupMemberId.FabZach;
			vCreateOauthAccess.Expires = 92387523598;
			vCreateOauthAccess.Refresh = "12345678901234567890123456789012";
			vCreateOauthAccess.Token = "abcd5678901234567890123456789XYZ";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override OauthAccess ExecuteOperation() {
			var op = new CreateOauthAccessOperation();
			return op.Execute(OpCtx, Build, Tasks, vCreateOauthAccess);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			OauthAccess result = ExecuteOperation();

			Assert.AreNotEqual(0, result.Id, "Incorrect Id.");
			Assert.AreNotEqual(0, result.VertexType, "Incorrect VertexType.");
			Assert.AreNotEqual(0, result.Timestamp, "Incorrect Timestamp.");
			Assert.AreEqual(vCreateOauthAccess.Expires, result.Expires, "Incorrect Expires.");
			Assert.AreEqual(vCreateOauthAccess.Refresh, result.Refresh, "Incorrect Refresh.");
			Assert.AreEqual(vCreateOauthAccess.Token, result.Token, "Incorrect Token.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<OauthAccess>(x => x.VertexId, result.VertexId)
				.AuthenticatesMember.ToMember
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo,
						vCreateOauthAccess.AuthenticatesMemberId)
				.AuthenticatedByOauthAccesses.ToOauthAccess
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, result.VertexId)
				.ToQuery();

			NewVertexCount = 1;
			NewEdgeCount = 2;
			SetNewElementQuery(verify);
		}

	}

}