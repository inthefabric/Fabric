using Fabric.Api.Web.Tasks;
using Fabric.Infrastructure.Weaver;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	public class XWebTasks : IntegTestBase {

		protected IWebTasks Tasks { get; private set; }
		protected TxBuilder TxBuild { get; private set; }

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			Tasks = new WebTasks();
			TxBuild = new TxBuilder();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void FinishTx() {
			TxBuild.Finish();
			//TestUtil.LogWeaverScript(TxBuild.Transaction);
		}

	}

}