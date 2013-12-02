using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
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
	[TestFixture]
	public class TCreateAppOperation {

		private static readonly Logger Log = Logger.Build<TCreateAppOperation>();

		private const string UniqueAppNameScript = "g.V('"+DbName.Vert.App.NameKey+"',_P);";

		private const string CreateAppScript = 
			"_V0=g.addVertex(["+
				DbName.Vert.App.Name+":_TP,"+
				DbName.Vert.App.NameKey+":_TP,"+
				DbName.Vert.App.Secret+":_TP,"+
				DbName.Vert.Vertex.VertexId+":_TP,"+
				DbName.Vert.Vertex.Timestamp+":_TP,"+
				DbName.Vert.Vertex.VertexType+":_TP"+
			"]);"+
			"_V1=g.V('v_id',_TP).next();"+
			"g.addEdge(_V0,_V1,_TP);"+
			"g.addEdge(_V1,_V0,_TP,["+
				DbName.Edge.MemberCreatesArtifact.Timestamp+":_TP,"+
				DbName.Edge.MemberCreatesArtifact.VertexType+":_TP"+
			"]);"+
			"_V0;";

		private long vVertId;
		private DateTime vVertTime;
		private long vMemId;
		private Mock<IOperationAuth> vMockAuth;
		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockCtx;
		private Mock<ITxBuilder> vMockTxb;
		private CreateFabApp vCreateApp;
		private IWeaverVarAlias<App> vVertVar;
		private IWeaverVarAlias<Member> vMemVar;

		private Action<IWeaverScript, string> vCheckUniqueAppName;
		private Action<IWeaverScript, string> vCheckCreateApp;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vVertId = 9048632;
			vVertTime = new DateTime(12351246346);
			vMemId = 123456;

			vMockAuth = new Mock<IOperationAuth>();
			vMockAuth.SetupGet(x => x.ActiveMemberId).Returns(vMemId);

			vMockData = new Mock<IOperationData>();
			vMockData.Setup(x => x.GetVertexById<Vertex>(vMemId)).Returns(new Member());

			vMockCtx = new Mock<IOperationContext>();
			vMockCtx.Setup(x => x.GetSharpflakeId<Vertex>()).Returns(vVertId);
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vVertTime);
			vMockCtx.Setup(x => x.Auth).Returns(vMockAuth.Object);
			vMockCtx.Setup(x => x.Data).Returns(vMockData.Object);

			vVertVar = new WeaverVarAlias<App>("vert");
			vMemVar = new WeaverVarAlias<Member>("mem");

			vMockTxb = new Mock<ITxBuilder>();
			vMockTxb.Setup(x => x.AddVertex(It.IsAny<App>(), out vVertVar));
			vMockTxb.Setup(x => x.GetVertex(vMemId, out vMemVar));

			vCreateApp = new CreateFabApp();
			vCreateApp.Name = "MyApp";
			vCreateApp.Secret = "abcdefghijklmnopQRSTUVWXYZ012345";
			vCreateApp.OauthDomains = null;

			////

			vCheckUniqueAppName = ((ws, n) => {
				var list = new List<object> {
					vCreateApp.Name.ToLower()
				};

			    CheckScriptAndParams(ws, UniqueAppNameScript, "_P", list);
			});

			vCheckCreateApp = ((ws, n) => {
				var list = new List<object> {
					vCreateApp.Name,
					vCreateApp.Name.ToLower(),
					vCreateApp.Secret,
					vVertId,
					vVertTime.Ticks,
					(byte)VertexType.Id.App,
					vMemId,
					DbName.Edge.ArtifactCreatedByMemberName,
					DbName.Edge.MemberCreatesArtifactName,
					vVertTime.Ticks,
					(byte)VertexType.Id.App,
				};

				CheckScriptAndParams(ws, CreateAppScript, "_TP", list);
			});
		}

		/*--------------------------------------------------------------------------------------------*/
		private string ToJson() {
			return vCreateApp.ToJson();
		}

		/*--------------------------------------------------------------------------------------------*/
		private CreateAppOperation DoCreate(ITxBuilder pTxBuild=null) {
			var c = new CreateAppOperation();
			c.Create(vMockCtx.Object, (pTxBuild ?? vMockTxb.Object), ToJson());
			return c;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void CheckScriptAndParams(IWeaverScript pWeaverScript, string pScript, 
														string pParamPrefix, IList<object> pParams) {
			TestUtil.LogWeaverScript(Log, pWeaverScript);
			pScript = TestUtil.InsertParamIndexes(pScript, pParamPrefix);
			Assert.AreEqual(pScript, pWeaverScript.Script, "Incorrect Query.Script.");
			TestUtil.CheckParams(pWeaverScript.Params, pParamPrefix, pParams);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Create() {
			DoCreate();

			IWeaverVarAlias<App> var;
			
			vMockTxb.Verify(
				x => x.AddVertex(It.Is<App>(a => a.VertexId == vVertId), out var),
				Times.Once
			);

			vMockTxb.Verify(
				x => x.AddEdge(
					It.IsAny<IWeaverVarAlias<Artifact>>(),
					It.IsAny<ArtifactCreatedByMember>(),
					It.IsAny<IWeaverVarAlias<Member>>()
				),
				Times.Once
			);

			vMockTxb.Verify(
				x => x.AddEdge(
					It.IsAny<IWeaverVarAlias<Member>>(),
					It.IsAny<MemberCreatesArtifact>(),
					It.IsAny<IWeaverVarAlias<Artifact>>()
				),
				Times.Once
			);

			vMockData.Verify(
				x => x.Get<App>(It.IsAny<IWeaverQuery>(), It.IsAny<string>()),
				Times.Once
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void CreateDuplicate() {
			vMockData
				.Setup(x => x.Get<App>(It.IsAny<IWeaverQuery>(), "UniqueAppName"))
				.Callback(vCheckUniqueAppName)
				.Returns(new App());

			TestUtil.Throws<FabDuplicateFault>(() => DoCreate());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetResult() {
			var c = new CreateAppOperation();
			TestUtil.Throws<NotSupportedException>(() => c.GetResult());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAppResult() {
			var tx = new Mock<IWeaverTransaction>();
			vMockTxb.Setup(x => x.Finish(vVertVar)).Returns(tx.Object);

			var expectResult = new App();
			vMockData.Setup(x => x.Get<App>(tx.Object, "CreateAppOperation")).Returns(expectResult);

			CreateAppOperation c = DoCreate();
			App result = c.GetAppResult();

			Assert.AreEqual(expectResult, result, "Result should be filled.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		[Category(TestUtil.RawScriptCategory)]
		public void GetAppResultScript() {
			var txb = new TxBuilder();
			var expectResult = new App();

			vMockData
				.Setup(x => x.Get<App>(It.IsAny<IWeaverTransaction>(), "CreateAppOperation"))
				.Callback(vCheckCreateApp)
				.Returns(expectResult);

			CreateAppOperation c = DoCreate(txb);
			App result = c.GetAppResult();

			Assert.AreEqual(expectResult, result, "Result should be filled.");
		}

	}

}