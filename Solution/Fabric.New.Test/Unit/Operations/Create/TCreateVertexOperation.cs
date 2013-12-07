using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Meta;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Operations;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using ServiceStack.Text;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public abstract class TCreateVertexOperation<TDom, TApi, TCre, TOper>
										where TDom : Vertex, new()
										where TApi : FabVertex, new()
										where TCre : CreateFabVertex, new()
										where TOper : CreateVertexOperation<TDom, TApi, TCre>, new() {

		protected Mock<IOperationAuth> vMockAuth;
		protected MockDataAccess vMockDataAcc;
		protected Mock<IOperationData> vMockData;
		protected Mock<IOperationContext> vMockCtx;
		protected TCre vCreateObj;
		private IList<MockDataAccessCmd> vExpectCommands;
		protected TDom vExpectDomResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vCreateObj = new TCre();

			vExpectDomResult = new TDom();
			vExpectDomResult.VertexId = 984654;
			vExpectDomResult.Timestamp = DateTime.UtcNow.Ticks;
			vExpectDomResult.VertexType = (byte)GetVertexTypeId();

			vMockAuth = new Mock<IOperationAuth>();

			vMockDataAcc = MockDataAccess.Create(OnDataExecute, true);

			vMockData = new Mock<IOperationData>();
			vMockData.Setup(x => x.Build(null, true, It.IsAny<bool>())).Returns(vMockDataAcc.Object);

			vMockCtx = new Mock<IOperationContext>();
			vMockCtx.Setup(x => x.GetSharpflakeId<Vertex>()).Returns(vExpectDomResult.VertexId);
			vMockCtx.SetupGet(x => x.UtcNow).Returns(new DateTime(vExpectDomResult.Timestamp));
			vMockCtx.Setup(x => x.Auth).Returns(vMockAuth.Object);
			vMockCtx.Setup(x => x.Data).Returns(vMockData.Object);

			SetUpInner();

			////

			vExpectCommands = new List<MockDataAccessCmd>();

			AddCommand("sessionStart", new MockDataAccessCmd {
				SessionAction = MockDataAccess.SessionStart
			});

			string commitCondCmdId = SetupCommands(null);

			AddCommand("sessionCommit", new MockDataAccessCmd {
				ConditionCmdId = commitCondCmdId,
				SessionAction = MockDataAccess.SessionCommit
			});

			AddCommand("sessionClose", new MockDataAccessCmd {
				SessionAction = MockDataAccess.SessionClose
			});

			for ( int i = 0 ; i < vExpectCommands.Count ; i++ ) {
				string cmdId = i+"";
				vMockDataAcc.MockResult.Setup(x => x.GetCommandIndexByCmdId(cmdId)).Returns(i);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void SetUpInner() {}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract string SetupCommands(string pCondCmdId);

		/*--------------------------------------------------------------------------------------------*/
		protected string SetupEdgeSingle(string pName, string pCondCmdId, int pIndex, 
				long pToVertexId, string pEdgeName0) {
			var v = "v"+pIndex;

			var getVert = AddCommand(pName+"Vert", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = v+"=g.V('"+DbName.Vert.Vertex.VertexId+"',_P);"+
					"("+v+"?{"+v+"="+v+".next();1;}:0);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> { pToVertexId }),
				Cache = true
			});

			pCondCmdId = getVert.CommandId;

			AddCommand(pName+"Edge0", new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = "g.addEdge(a,"+v+",_P);",
				Params = MockDataAccessCmd.BuildParamMap(new List<object> { pEdgeName0 }),
				Cache = true,
				OmitResults = true
			});

			return pCondCmdId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected string SetupEdgePair(string pName, string pCondCmdId, int pIndex, long pToVertexId,
				string pEdgeName0, string pEdgeName1, string[] pParamNames, object[] pParamVals) {
			var v = "v"+pIndex;

			pCondCmdId = SetupEdgeSingle(pName, pCondCmdId, pIndex, pToVertexId, pEdgeName0);

			var cmd = new MockDataAccessCmd {
				ConditionCmdId = pCondCmdId,
				Script = "g.addEdge("+v+",a,_P",
				Cache = true,
				OmitResults = true
			};

			var pars = new List<object> { pEdgeName1 };

			if ( pParamNames.Length > 0 ) {
				cmd.Script += ",[";

				for ( int i = 0 ; i < pParamNames.Length ; ++i ) {
					cmd.Script += (i == 0 ? "" : ",")+pParamNames[i]+":_P";
					pars.Add(pParamVals[i]);
				}

				cmd.Script += "]";
			}

			cmd.Script += ");";
			cmd.Params = MockDataAccessCmd.BuildParamMap(pars);
			AddCommand(pName+"Edge1", cmd);

			return pCondCmdId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void SetupAddVertexResultAt(int pIndex) {
			vMockDataAcc.MockResult.Setup(x => x.ToElementAt<TDom>(pIndex,0)).Returns(vExpectDomResult);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected MockDataAccessCmd AddCommand(string pName, MockDataAccessCmd pCmd) {
			pCmd.TestCommandName = pName;
			pCmd.CommandId = vExpectCommands.Count+"";

			if ( pCmd.Script != null ) {
				pCmd.Script = TestUtil.InsertParamIndexes(pCmd.Script, "_P");
			}

			vExpectCommands.Add(pCmd);
			return pCmd;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected int GetExpectedCommandCount() {
			return vExpectCommands.Count;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract Logger GetLogger();

		/*--------------------------------------------------------------------------------------------*/
		protected abstract VertexType.Id GetVertexTypeId();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TOper BuildCreateVerify() {
			var c = new TOper();
			c.Create(vMockCtx.Object, vCreateObj.ToJson());
			vMockDataAcc.PrintCommands();
			vMockDataAcc.AssertCommandList(vExpectCommands);
			return c;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnDataExecute(MockDataAccess pDataAccess) {
			string exName = "Create"+typeof(TDom).Name+"Operation";
			pDataAccess.Verify(x => x.Execute(exName), Times.Once);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Create() {
			BuildCreateVerify();
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Execute() {
			TOper c = BuildCreateVerify();
			TDom result = c.Execute();

			Assert.AreEqual(vExpectDomResult, result, "Result should be filled.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetApiResult() {
			var c = BuildCreateVerify();
			TDom dom = c.Execute();

			if ( IsInternalGetResult() ) {
				TestUtil.Throws<NotSupportedException>(() => c.GetResult());
				return;
			}

			TApi result = c.GetResult();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(result.Id, dom.VertexId, "Incorrect Id.");
			Assert.AreEqual(result.Timestamp, FabMetaTime.GetTimestamp(dom.Timestamp),
				"Incorrect Timestamp.");
			Assert.AreEqual(result.VertexType, dom.VertexType, "Incorrect VertexType.");
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract bool IsInternalGetResult();

	}

}