using Fabric.Api.Modify.Tasks;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	public class XBaseModifyFunc : IntegTestBase {

		protected ModifyTasks Tasks { get; private set; }

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			Tasks = new ModifyTasks();
		}

	}

}