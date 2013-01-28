using Fabric.Api.Modify.Tasks;
using Fabric.Infrastructure.Api;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	public abstract class TModifyTasks {

		protected ModifyTasks Tasks { get; private set; }
		protected Mock<IApiContext> MockApiCtx { get; private set; }
		protected UsageMap UsageMap { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			Tasks = new ModifyTasks();
			UsageMap = new UsageMap();
			MockApiCtx = new Mock<IApiContext>();

			TestSetUp();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected abstract void TestSetUp();

	}

}