using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Moq;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	public abstract class TBaseModifyFunc : TTestBase {

		protected Mock<IModifyTasks> MockTasks { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			MockTasks = new Mock<IModifyTasks>();
			base.SetUp();
			MockTasks.SetupGet(x => x.Validator).Returns(MockValidator.Object);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void SetUpMember(long pAppId, long pUserId, Member pMember=null) {
			base.SetUpMember(pAppId, pUserId, pMember);
			MockTasks.Setup(x => x.GetValidMemberByContext(MockApiCtx.Object)).Returns(ApiCtxMember);
		}

	}

}