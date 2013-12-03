using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateAppOperation : TCreateArtifactOperation<App, FabApp, CreateFabApp, CreateAppOperation> {

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
			"_V1=g.V('"+DbName.Vert.Vertex.VertexId+"',_TP).next();"+
			"g.addEdge(_V0,_V1,_TP);"+
			"g.addEdge(_V1,_V0,_TP,["+
				DbName.Edge.MemberCreatesArtifact.Timestamp+":_TP,"+
				DbName.Edge.MemberCreatesArtifact.VertexType+":_TP"+
			"]);"+
			"_V0;";

		private Action<IWeaverScript, string> vCheckUniqueAppName;
		private Action<IWeaverScript, string> vCheckCreateApp;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			base.SetUp();

			vCreateObj.Name = "MyApp";
			vCreateObj.Secret = "abcdefghijklmnopQRSTUVWXYZ012345";
			vCreateObj.OauthDomains = null;

			vMockDataAcc.MockResult.Setup(x => x.GetCommandIndexByCmdId("1")).Returns(1);
			vMockDataAcc.MockResult.Setup(x => x.ToElementAt<App>(1, 0)).Returns(vExpectDomResult);

			////

			vCheckUniqueAppName = ((ws, n) => {
				var list = new List<object> {
					vCreateObj.Name.ToLower()
				};

			    CheckScriptAndParams(Log, ws, UniqueAppNameScript, "_P", list);
			});

			vCheckCreateApp = ((ws, n) => {
				var list = new List<object> {
					vCreateObj.Name,
					vCreateObj.Name.ToLower(),
					vCreateObj.Secret,
					vVertId,
					vVertTime.Ticks,
					(byte)VertexType.Id.App,
					vMemId,
					DbName.Edge.ArtifactCreatedByMemberName,
					DbName.Edge.MemberCreatesArtifactName,
					vVertTime.Ticks,
					(byte)VertexType.Id.App,
				};

				CheckScriptAndParams(Log, ws, CreateAppScript, "_TP", list);
			});
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void VerifyCreate() {
			base.VerifyCreate();

			vMockData.Verify(
				x => x.Get<App>(It.IsAny<IWeaverQuery>(), "UniqueAppName"),
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
		protected override Logger GetLogger() {
			return Log;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool IsInternalGetResult() {
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void OnDataExecuteInner(MockDataAccess pDataAccess) {
			//vCheckCreateApp
		}

	}

}