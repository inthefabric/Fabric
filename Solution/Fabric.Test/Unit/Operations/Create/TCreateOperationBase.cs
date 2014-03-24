using System;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using ServiceStack.Text;

namespace Fabric.New.Test.Unit.Operations.Create {
	
	/*================================================================================================*/
	public abstract class TCreateOperationBase<TDom, TApi, TCre, TOper>
										where TDom : Vertex, new()
										where TApi : FabVertex, new()
										where TCre : CreateFabVertex, new()
										where TOper : CreateVertexOperation<TDom, TApi, TCre>, new() {

		private static Logger Log = Logger.Build<Object>();

		protected Mock<IOperationAuth> MockAuth { get; private set; }
		protected Mock<IOperationContext> MockOpCtx { get; private set; }
		protected Mock<ICreateOperationBuilder> MockBuild { get; private set; }
		protected Mock<CreateOperationTasks> MockTasks { get; private set; }
		protected long VertId { get; private set; }
		protected long MemId { get; private set; }

		private Mock<IDataAccess> vMockAcc;
		private Mock<IDataResult> vMockRes;
		private int vCallsAdded;
		private int vCalls;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			VertId = 94693942;
			MemId = 143621346;
			vCallsAdded = 0;
			vCalls = 0;

			MockAuth = new Mock<IOperationAuth>(MockBehavior.Strict);
			MockAuth.Setup(x => x.ActiveMemberId).Returns(MemId);
			MockAuth.Setup(x => x.SetNewUserMember(VertId));

			vMockAcc = new Mock<IDataAccess>(MockBehavior.Strict);

			vMockRes = new Mock<IDataResult>(MockBehavior.Strict);

			var mockData = new Mock<IOperationData>(MockBehavior.Strict);
			mockData.Setup(x => x.Build(null, true, true)).Returns(vMockAcc.Object);

			MockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			MockOpCtx.Setup(x => x.GetSharpflakeId<Vertex>()).Returns(VertId);
			MockOpCtx.SetupGet(x => x.UtcNow).Returns(new DateTime(99999999));
			MockOpCtx.Setup(x => x.Auth).Returns(MockAuth.Object);
			MockOpCtx.Setup(x => x.Data).Returns(mockData.Object);

			MockBuild = new Mock<ICreateOperationBuilder>(MockBehavior.Strict);
			MockBuild.Setup(x => x.SetDataAccess(vMockAcc.Object));
			MockBuild.Setup(x => x.PerformChecks(vMockRes.Object));

			MockTasks = new Mock<CreateOperationTasks>(MockBehavior.Strict);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected Action CheckCallIndex(string pName) {
			int index = vCallsAdded++;
			Log.Debug("Add CheckCallIndex: "+pName+" @ "+index);

			return (() => {
				Log.Debug("Callback: "+pName+" @ "+vCalls);
				Assert.AreEqual(index, vCalls++, "Incorrect function call: "+pName+".");
			});
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static T ItIsVert<T>(long pVertexId) where T : IVertex {
			return It.Is<T>(x => x.VertexId == pVertexId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public virtual void Execute() {
			var cre = new TCre();
			var expectResult = new TDom();
			const string addVertCmd = "addVertCmdId";
			const int addVertIndex = 99;

			MockBuild
				.Setup(x => x.StartSession())
				.Callback(CheckCallIndex("StartSession"));

			ExecuteSetup(cre);

			MockBuild
				.Setup(x => x.CommitAndCloseSession())
				.Callback(CheckCallIndex("CommitAndCloseSession"));

			vMockAcc.Setup(x => x.GetLatestCommandId()).Returns(addVertCmd);
			vMockAcc.Setup(x => x.Execute(typeof(TOper).Name)).Returns(vMockRes.Object);

			vMockRes.Setup(x => x.GetCommandIndexByCmdId(addVertCmd)).Returns(addVertIndex);
			vMockRes.Setup(x => x.ToElementAt<TDom>(addVertIndex, 0)).Returns(expectResult);

			var co = new TOper();
			TDom res = co.Execute(MockOpCtx.Object, MockBuild.Object, MockTasks.Object, cre.ToJson());

			Assert.AreEqual(expectResult, res, "Incorrect result.");

			MockBuild.Verify(x => x.CommitAndCloseSession(), Times.Once);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void ExecuteSetup(TCre pCre);
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public virtual void ValidationError() {
			var cre = new TCre();
			var co = new TOper();

			if ( ValidationErrorIsOutOfRange() ) {
				TestUtil.Throws<FabPropertyOutOfRangeFault>(() =>
					co.Execute(MockOpCtx.Object, null, null, cre.ToJson())
				);
			}
			else {
				TestUtil.Throws<FabPropertyNullFault>(() =>
					co.Execute(MockOpCtx.Object, null, null, cre.ToJson())
				);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual bool ValidationErrorIsOutOfRange() {
			return false;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ConvertResult() {
			var dom = new TDom();
			var co = new TOper();

			if ( HasInternalResult() ) {
				TestUtil.Throws<NotSupportedException>(() => co.ConvertResult(dom));
			}
			else {
				TApi result = co.ConvertResult(dom);
				Assert.NotNull(result, "Result should be filled.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract bool HasInternalResult();

	}

}