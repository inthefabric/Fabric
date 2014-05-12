using System;
using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Faults;
using Fabric.Operations;
using Fabric.Operations.Create;
using Fabric.Test.Integration.Shared;
using Fabric.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.Operations.Create {
	
	/*================================================================================================*/
	public static class XCreateOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void CheckNewVertex(Vertex pVertex, VertexType.Id pType) {
			Assert.NotNull(pVertex.Id, "Incorrect Id.");
			Assert.Less(1L, pVertex.VertexId, "Incorrect VertexId.");
			Assert.AreEqual((byte)pType, pVertex.VertexType, "Incorrect VertexType.");
			Assert.Less(DateTime.UtcNow.AddMinutes(-1).Ticks, pVertex.Timestamp, "Incorrect Timestamp.");
		}

	};


	/*================================================================================================*/
	public abstract class XCreateOperation<T> : IntegrationTest where T : Vertex {

		protected CreateOperationBuilder Build;
		protected CreateOperationTasks Tasks;

		protected long CreatorId;
		protected Mock<IOperationAuth> vMockAuth;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			VerificationQueryFunc = null;
			CreatorId = (long)SetupMemberId.FabZach;

			vMockAuth = new Mock<IOperationAuth>(MockBehavior.Strict);
			vMockAuth.SetupGet(x => x.ActiveMemberId).Returns(CreatorId);
			OpCtx.SetMockAuth(vMockAuth);

			Build = new CreateOperationBuilder();
			Tasks = new CreateOperationTasks();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract T ExecuteOperation();

		/*--------------------------------------------------------------------------------------------*/
		protected void SetNewElementQuery(IWeaverQuery pQuery) {
			VerificationQueryFunc = () => {
				IDataResult dr = OpCtx.ExecuteForTest(pQuery, "CreateOperations-Verify");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New element not verified.");
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void CheckNewVertex(Vertex pVertex, VertexType.Id pType) {
			XCreateOperation.CheckNewVertex(pVertex, pType);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNoAuth() {
			IsReadOnlyTest = true;
			vMockAuth.SetupGet(x => x.ActiveMemberId).Returns((long?)null);

			FabPreventedFault fpf = TestUtil.Throws<FabPreventedFault>(() => ExecuteOperation());
			Assert.AreEqual(FabFault.Code.AuthorizationRequired, fpf.ErrCode, "Incorrect ErrCode.");
		}

	}

}