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
	public class XWebUpdateAppSecretOperation : IntegrationTest {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			const long appId = (long)SetupAppId.KinPhoGal;
			
			var op = new WebUpdateAppSecretOperation();
			SuccessResult result = op.Execute(OpCtx, appId);

			Assert.NotNull(result, "Result should be filled.");
			Assert.True(result.Success, "Incorrect Success.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, appId)
					.Has(x => x.Name, WeaverStepHasOp.NotEqualTo, SetupUsers.KinPhoGalSecret)
				.ToQuery();

			VerificationQueryFunc = () => {
				IDataResult dr = OpCtx.Data.Execute(verify, "Test-UpdateAppSecret");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New element not verified.");
			};
		}

	}

}