using Fabric.Api.Modify.Tasks;
using Fabric.Api.Web.Tasks;

namespace Fabric.Test.Integration.FabApiWeb {

	/*================================================================================================*/
	public class XBaseWebFunc : IntegTestBase {

		protected IWebTasks Tasks { get; private set; }
		protected IModifyTasks ModTasks { get; private set; }

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			Tasks = new WebTasks();
			ModTasks = new ModifyTasks();
		}

	}

}