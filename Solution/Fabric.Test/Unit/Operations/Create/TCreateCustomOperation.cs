using System;
using Fabric.Domain;
using Fabric.Infrastructure.Broadcast;
using Fabric.Infrastructure.Data;
using Fabric.Operations;
using Fabric.Operations.Create;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public abstract class TCreateCustomOperation {

		private static readonly Logger Log = Logger.Build<TCreateCustomOperation>();

		protected Mock<IDataAccess> MockAcc { get; private set; }
		protected Mock<IDataResult> MockRes { get; private set; }
		protected Mock<IOperationData> MockData { get; private set; }
		protected Mock<IOperationContext> MockOpCtx { get; private set; }
		protected Mock<ICreateOperationBuilder> MockBuild { get; private set; }
		protected Mock<CreateOperationTasks> MockTasks { get; private set; }

		protected int CallsAdded { get; private set; }
		protected int Calls { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			MockAcc = new Mock<IDataAccess>(MockBehavior.Strict);

			MockRes = new Mock<IDataResult>(MockBehavior.Strict);

			MockData = new Mock<IOperationData>(MockBehavior.Strict);
			MockData.Setup(x => x.Build(null, true, true)).Returns(MockAcc.Object);

			MockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			MockOpCtx.SetupGet(x => x.UtcNow).Returns(new DateTime(99999999));
			MockOpCtx.Setup(x => x.Data).Returns(MockData.Object);

			MockBuild = new Mock<ICreateOperationBuilder>(MockBehavior.Strict);
			MockBuild.Setup(x => x.SetDataAccess(MockAcc.Object));
			MockBuild.Setup(x => x.PerformChecks(MockRes.Object));

			MockTasks = new Mock<CreateOperationTasks>(MockBehavior.Strict);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected Action CheckCallIndex(string pName) {
			int index = CallsAdded++;
			Log.Debug("Add CheckCallIndex: "+pName+" @ "+index);

			return (() => {
				Log.Debug("Callback: "+pName+" @ "+Calls);
				Assert.AreEqual(index, Calls++, "Incorrect function call: "+pName+".");
			});
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static T ItIsVert<T>(long pVertexId) where T : IVertex {
			return It.Is<T>(x => x.VertexId == pVertexId);
		}

	}

}