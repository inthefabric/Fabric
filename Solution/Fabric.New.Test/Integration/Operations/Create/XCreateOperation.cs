using System;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Integration.Shared;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Integration.Operations.Create {

	/*================================================================================================*/
	public abstract class XCreateOperation<T> : IntegrationTest where T : Vertex {

		protected CreateOperationBuilder Build;
		protected CreateOperationTasks Tasks;

		protected long CreatorId;
		private Mock<IOperationAuth> vMockAuth;


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
				IDataResult dr = OpCtx.Data.Execute(pQuery, "Test-CreateOperations");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New element not verified.");
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void CheckNewVertex(Vertex pVertex, VertexType.Id pType) {
			Assert.NotNull(pVertex.Id, "Incorrect Id.");
			Assert.Less(1L, pVertex.VertexId, "Incorrect VertexId.");
			Assert.AreEqual((byte)pType, pVertex.VertexType, "Incorrect VertexType.");
			Assert.Less(DateTime.UtcNow.AddMinutes(-1).Ticks, pVertex.Timestamp,"Incorrect Timestamp.");
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