using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Query;
using Fabric.Infrastructure.Util;
using Fabric.Operations.Web;
using Fabric.Test.Integration.Shared;
using Fabric.Test.Unit.Shared;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Test.Integration.Operations.Web {

	/*================================================================================================*/
	public class XWebUpdateUserPasswordOperation : IntegrationTest {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			const long userId = (long)SetupUserId.Zach;
			const string newPass = "myTestPassword";

			var op = new WebUpdateUserPasswordOperation();
			SuccessResult result = op.Execute(OpCtx, userId, "asdfasdf", newPass);

			Assert.NotNull(result, "Result should be filled.");
			Assert.True(result.Success, "Incorrect Success.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.VertexId, userId)
					.Has(x => x.Password, WeaverStepHasOp.EqualTo, DataUtil.HashPassword(newPass))
				.ToQuery();

			VerificationQueryFunc = () => {
				IDataResult dr = OpCtx.ExecuteForTest(verify, "UpdateUserPassword-Verify");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New element not verified.");
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPasswordMismatch() {
			IsReadOnlyTest = true;
			const long userId = (long)SetupUserId.Zach;

			var op = new WebUpdateUserPasswordOperation();
			TestUtil.Throws<FabPreventedFault>(() => op.Execute(OpCtx, userId, "x", "newPassword"));
		}

	}

}