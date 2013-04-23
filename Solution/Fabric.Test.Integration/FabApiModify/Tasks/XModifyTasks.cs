using Fabric.Api.Modify.Tasks;
using Fabric.Infrastructure.Weaver;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	public class XModifyTasks : IntegTestBase {

		protected ModifyTasks Tasks { get; private set; }
		protected TxBuilder TxBuild { get; private set; }

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			Tasks = new ModifyTasks();
			TxBuild = new TxBuilder();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void FinishTx() {
			TxBuild.Finish();
			//TestUtil.LogWeaverScript(TxBuild.Transaction);
		}

	}

}