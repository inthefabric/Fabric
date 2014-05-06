using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Util;
using Fabric.Operations;
using Fabric.Operations.Web;
using Fabric.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Web {

	/*================================================================================================*/
	[TestFixture]
	public class TWebUpdateUserPasswordOperation {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;

		private User vUser;
		private string vOldPass;
		private string vNewPass;
		private WebUpdateUserPasswordOperation vOper;
		private SuccessResult vExecuteResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vUser = new User();
			vUser.VertexId = 1234125;
			vOldPass = "oldPassword";
			vNewPass = "newPassword";

			vMockData = new Mock<IOperationData>(MockBehavior.Strict);
			vMockData.Setup(x => x.GetVertexById<User>(vUser.VertexId)).Returns(vUser);

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vOper = new WebUpdateUserPasswordOperation();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void DoExecute() {
			vExecuteResult = vOper.Execute(vMockOpCtx.Object, vUser.VertexId, vOldPass, vNewPass);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			vUser.Password = DataUtil.HashPassword(vOldPass);
			
			const string expectScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
					".sideEffect{"+
						"it.setProperty('"+DbName.Vert.User.Password+"',_P);"+
					"};";

			var expectParams = new List<object> {
				vUser.VertexId,
				DataUtil.HashPassword(vNewPass)
			};

			vMockData
				.Setup(x => x.Get<User>(It.IsAny<IWeaverQuery>(), "Web-UpdateUserPassword"))
				.Callback((IWeaverScript q, string n) => 
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns(vUser);

			DoExecute();

			Assert.NotNull(vExecuteResult, "Result should be filled.");
			Assert.True(vExecuteResult.Success, "Incorrect Success.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPasswordMismatch() {
			vUser.Password = "different";
			TestUtil.Throws<FabPreventedFault>(DoExecute);
		}

	}

}