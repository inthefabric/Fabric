using Fabric.Api.Objects;
using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Query;
using Fabric.Operations.Create;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Test.Integration.Operations.Create {

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

			CheckNewVertex(result, VertexType.Id.OauthAccess);
			Assert.AreEqual(vCreateOauthAccess.Expires, result.Expires, "Incorrect Expires.");
			Assert.AreEqual(vCreateOauthAccess.Refresh, result.Refresh, "Incorrect Refresh.");
			Assert.AreEqual(vCreateOauthAccess.Token, result.Token, "Incorrect Token.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<OauthAccess>(x => x.VertexId, result.VertexId)
				.AuthenticatesMember.ToMember
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo,
						vCreateOauthAccess.AuthenticatesMemberId)
				.AuthenticatedByOauthAccesses
					.Has(x => x.Timestamp, WeaverStepHasOp.EqualTo, result.Timestamp)
				.ToOauthAccess
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, result.VertexId)
				.ToQuery();

			NewVertexCount = 1;
			NewEdgeCount = 2;
			SetNewElementQuery(verify);
		}

	}

}