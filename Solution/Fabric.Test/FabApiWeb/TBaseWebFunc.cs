using Fabric.Api.Web.Tasks;
using Moq;

namespace Fabric.Test.FabApiWeb {

	/*================================================================================================*/
	public abstract class TBaseWebFunc : TTestBase {

		protected Mock<IWebTasks> MockTasks { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			MockTasks = new Mock<IWebTasks>();
			base.SetUp();
			MockTasks.SetupGet(x => x.Validator).Returns(MockValidator.Object);
		}

	}

}