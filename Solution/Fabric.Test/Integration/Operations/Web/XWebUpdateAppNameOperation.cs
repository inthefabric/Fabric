using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Query;
using Fabric.Operations.Web;
using Fabric.Test.Integration.Shared;
using Fabric.Test.Unit.Shared;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Test.Integration.Operations.Web {

	/*================================================================================================*/
	public class XWebUpdateAppNameOperation : IntegrationTest {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			const long appId = (long)SetupAppId.KinPhoGal;
			const string newName = "TestName";

			var op = new WebUpdateAppNameOperation();
			SuccessResult result = op.Execute(OpCtx, appId, newName);

			Assert.NotNull(result, "Result should be filled.");
			Assert.True(result.Success, "Incorrect Success.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, appId)
					.Has(x => x.Name, WeaverStepHasOp.EqualTo, newName)
					.Has(x => x.NameKey, WeaverStepHasOp.EqualTo, newName.ToLower())
				.ToQuery();

			VerificationQueryFunc = () => {
				IDataResult dr = OpCtx.Data.Execute(verify, "Test-UpdateAppName");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New element not verified.");
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicate() {
			IsReadOnlyTest = true;

			const long appId = (long)SetupAppId.KinPhoGal;
			const string newName = "The Bookmarker";

			var op = new WebUpdateAppNameOperation();
			TestUtil.Throws<FabDuplicateFault>(() => op.Execute(OpCtx, appId, newName));
		}

	}

}