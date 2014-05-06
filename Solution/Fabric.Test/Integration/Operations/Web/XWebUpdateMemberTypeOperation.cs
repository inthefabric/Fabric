using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Domain.Enums;
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
	public class XWebUpdateMemberTypeOperation : IntegrationTest {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			const long memId = (long)SetupMemberId.BookZach;
			const MemberType.Id newType = MemberType.Id.Staff;

			var op = new WebUpdateMemberTypeOperation();
			Member result = op.Execute(OpCtx, memId, newType);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(memId, result.VertexId, "Incorrect VertexId.");
			Assert.AreEqual((byte)newType, result.MemberType, "Incorrect MemberType.");

			IWeaverQuery memQ = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, memId)
					.Has(x => x.MemberType, WeaverStepHasOp.EqualTo, (byte)newType)
				.ToQuery();

			IWeaverQuery userDefMemQ = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.VertexId, (byte)SetupUserId.Zach)
				.DefinesMembers
					.Has(x => x.AppId, WeaverStepHasOp.EqualTo, (byte)SetupAppId.Bookmarker)
					.Has(x => x.MemberType, WeaverStepHasOp.EqualTo, (byte)newType)
					.ToMember
				.ToQuery();

			IWeaverQuery appDefMemQ = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, (byte)SetupAppId.Bookmarker)
				.DefinesMembers
					.Has(x => x.UserId, WeaverStepHasOp.EqualTo, (byte)SetupUserId.Zach)
					.Has(x => x.MemberType, WeaverStepHasOp.EqualTo, (byte)newType)
					.ToMember
				.ToQuery();

			VerificationQueryFunc = () => {
				IDataResult dr = OpCtx.Data.Execute(memQ, "Test-UpdateMemType1");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New element not verified (1).");

				dr = OpCtx.Data.Execute(userDefMemQ, "Test-UpdateMemType2");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New element not verified (2).");

				dr = OpCtx.Data.Execute(appDefMemQ, "Test-UpdateMemType3");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New element not verified (3).");
			};
		}

	}

}