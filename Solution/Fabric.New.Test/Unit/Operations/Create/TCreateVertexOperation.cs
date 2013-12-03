using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Operations;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Shared;
using Moq;
using NUnit.Framework;
using ServiceStack.Text;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	public abstract class TCreateVertexOperation<TDom, TApi, TCre, TOper>
										where TDom : Vertex, new()
										where TApi : FabVertex, new()
										where TCre : CreateFabVertex, new()
										where TOper : CreateVertexOperation<TDom, TApi, TCre>, new() {

		protected long vVertId;
		protected DateTime vVertTime;
		protected Mock<IOperationAuth> vMockAuth;
		protected Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockCtx;
		protected Mock<ITxBuilder> vMockTxb;
		protected TCre vCreateObj;
		protected IWeaverVarAlias<TDom> vVertVar;
		protected string vCreateQueryName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vVertId = 9048632;
			vVertTime = new DateTime(12351246346);

			vMockAuth = new Mock<IOperationAuth>();

			vMockData = new Mock<IOperationData>();

			vMockCtx = new Mock<IOperationContext>();
			vMockCtx.Setup(x => x.GetSharpflakeId<Vertex>()).Returns(vVertId);
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vVertTime);
			vMockCtx.Setup(x => x.Auth).Returns(vMockAuth.Object);
			vMockCtx.Setup(x => x.Data).Returns(vMockData.Object);

			vVertVar = new WeaverVarAlias<TDom>("vert");

			vMockTxb = new Mock<ITxBuilder>();
			vMockTxb.Setup(x => x.AddVertex(It.IsAny<TDom>(), out vVertVar));

			vCreateObj = new TCre();
			vCreateQueryName = "Create"+typeof(TDom).Name+"Operation";
		}

		/*--------------------------------------------------------------------------------------------*/
		private string ToJson() {
			return vCreateObj.ToJson();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected TOper DoCreate(ITxBuilder pTxBuild=null) {
			var c = new TOper();
			c.Create(vMockCtx.Object, (pTxBuild ?? vMockTxb.Object), ToJson());
			return c;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static void CheckScriptAndParams(Logger pLog, IWeaverScript pWeaverScript,
										string pScript, string pParamPrefix, IList<object> pParams) {
			TestUtil.LogWeaverScript(pLog, pWeaverScript);
			pScript = TestUtil.InsertParamIndexes(pScript, pParamPrefix);
			Assert.AreEqual(pScript, pWeaverScript.Script, "Incorrect Query.Script.");
			TestUtil.CheckParams(pWeaverScript.Params, pParamPrefix, pParams);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Create() {
			DoCreate();

			IWeaverVarAlias<TDom> var;
			
			vMockTxb.Verify(
				x => x.AddVertex(It.Is<TDom>(a => a.VertexId == vVertId), out var),
				Times.Once
			);

			VerifyCreate();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void VerifyCreate();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Execute() {
			var tx = new Mock<IWeaverTransaction>();
			vMockTxb.Setup(x => x.Finish(vVertVar)).Returns(tx.Object);

			var expectResult = new TDom();
			vMockData.Setup(x => x.Get<TDom>(tx.Object, vCreateQueryName)).Returns(expectResult);

			TOper c = DoCreate();
			TDom result = c.Execute();

			Assert.AreEqual(expectResult, result, "Result should be filled.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		[Category(TestUtil.RawScriptCategory)]
		public void ExecuteScript() {
			var txb = new TxBuilder();
			var expectResult = new TDom();

			vMockData
				.Setup(x => x.Get<TDom>(It.IsAny<IWeaverTransaction>(), vCreateQueryName))
				.Callback(GetCreateScriptCallback())
				.Returns(expectResult);

			TOper c = DoCreate(txb);
			TDom result = c.Execute();

			Assert.AreEqual(expectResult, result, "Result should be filled.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetApiResult() {
			var c = new CreateUserOperation();

			if ( IsInternalGetResult() ) {
				TestUtil.Throws<NotSupportedException>(() => c.GetResult());
				return;
			}

			Assert.Fail("Non-internal GetApiResult is not tested yet.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract bool IsInternalGetResult();

		/*--------------------------------------------------------------------------------------------*/
		protected abstract Action<IWeaverScript, string> GetCreateScriptCallback();

	}

}