using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Oauth;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Operations;
using Fabric.New.Operations.Create;
using Fabric.New.Operations.Oauth;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthAccessTasks {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;

		private OauthAccessTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockData = new Mock<IOperationData>(MockBehavior.Strict);

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vTasks = new OauthAccessTasks();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AssertFault(TestDelegate pDelegate, AccessErrors pError, AccessErrorDescs pDesc) {
			OauthException oe = TestUtil.Throws<OauthException>(pDelegate);

			Assert.NotNull(oe.OauthError, "OauthError should filled.");
			Assert.AreEqual(pError+"", oe.OauthError.Error, "Invalid OauthError.Error");
			Assert.AreEqual(OauthAccessTasks.ErrDescStrings[(int)pDesc]+"",
				oe.OauthError.ErrorDesc, "Invalid OauthError.ErrorDesc");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAppErrBadSecret() {
			const long appId = 1234512523;
			const string secret = "asdugalsdgualsdkgulsdkug";

			vMockData
				.Setup(x => x.Get<App>(It.IsAny<IWeaverQuery>(), "OauthAccess-GetApp"))
				.Returns((App)null);

			AssertFault(() => vTasks.GetApp(vMockData.Object, appId, secret),
				AccessErrors.invalid_client, AccessErrorDescs.BadClientSecret);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAppSuccess() {
			const long appId = 1234512523;
			const string secret = "asdugalsdgualsdkgulsdkug";
			var app = new App();

			const string expectScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
					".has('"+DbName.Vert.App.Secret+"',Tokens.T.eq,_P);";

			var expectParams = new List<object> {
				appId,
				secret
			};

			vMockData
				.Setup(x => x.Get<App>(It.IsAny<IWeaverQuery>(), "OauthAccess-GetApp"))
				.Callback((IWeaverScript q, string n) => 
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns(app);

			App result = vTasks.GetApp(vMockData.Object, appId, secret);

			Assert.AreEqual(app, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(1)]
		public void GetMemberByGrant(int pResultCount) {
			const long appId = 125125235;
			const string code = "asdugalsdgualsdkgulsdkug";
			var mem = new Member();

			var mockDataAcc = MockDataAccess.Create(mda => {
				Assert.AreEqual(MockDataAccess.SessionStart, mda.GetCommand(0).SessionAction,
					"Incorrect Command 0 SessionAction.");

				string expectScript = "m=g.V('"+DbName.Vert.Member.OauthGrantCode+"',_P);"+
					"(m?m=m.next():null);";
				var expectParam = new List<object> { code };
				TestUtil.CheckWeaverScript(mda.GetCommand(1), expectScript, "_P", expectParam);

				expectScript = "m.outE('"+DbName.Edge.MemberDefinedByAppName+"')"+
					".inV.property('"+DbName.Vert.Vertex.VertexId+"');";
				expectParam = new List<object>();
				TestUtil.CheckWeaverScript(mda.GetCommand(2), expectScript, "_P", expectParam);

				Assert.AreEqual(MockDataAccess.SessionClose, mda.GetCommand(3).SessionAction,
					"Incorrect Command 3 SessionAction.");

				Assert.AreEqual("OauthAccess-GetMemberByGrant", 
					mda.Object.ExecuteName, "Incorrect ExecuteName.");
			});

			mockDataAcc.MockResult
				.Setup(x => x.GetCommandResultCount(pResultCount))
				.Returns(1);

			mockDataAcc.MockResult
				.Setup(x => x.ToElementAt<Member>(1, 0))
				.Returns(mem);

			mockDataAcc.MockResult
				.Setup(x => x.ToLongAt(2, 0))
				.Returns(appId);

			vMockData
				.Setup(x => x.Build(null, true, true))
				.Returns(mockDataAcc.Object);

			OauthMember result = vTasks.GetMemberByGrant(vMockData.Object, code);

			if ( pResultCount == 0 ) {
				Assert.Null(result, "Result should be null.");
				return;
			}

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(mem, result.Member, "Incorrect Member.");
			Assert.AreEqual(appId, result.AppId, "Incorrect AppId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(1)]
		public void GetMemberByRefresh(int pResultCount) {
			const long appId = 125125235;
			const string code = "asdugalsdgualsdkgulsdkug";
			var mem = new Member();

			var mockDataAcc = MockDataAccess.Create(mda => {
				Assert.AreEqual(MockDataAccess.SessionStart, mda.GetCommand(0).SessionAction,
					"Incorrect Command 0 SessionAction.");

				string expectScript = "m=g.V('"+DbName.Vert.OauthAccess.Refresh+"',_P)"+
					".outE('"+DbName.Edge.OauthAccessAuthenticatesMemberName+"').inV;"+
					"(m?m=m.next():null);";
				var expectParam = new List<object> { code };
				TestUtil.CheckWeaverScript(mda.GetCommand(1), expectScript, "_P", expectParam);

				expectScript = "m.outE('"+DbName.Edge.MemberDefinedByAppName+"')"+
					".inV.property('"+DbName.Vert.Vertex.VertexId+"');";
				expectParam = new List<object>();
				TestUtil.CheckWeaverScript(mda.GetCommand(2), expectScript, "_P", expectParam);

				Assert.AreEqual(MockDataAccess.SessionClose, mda.GetCommand(3).SessionAction,
					"Incorrect Command 3 SessionAction.");

				Assert.AreEqual("OauthAccess-GetMemberByRefresh",
					mda.Object.ExecuteName, "Incorrect ExecuteName.");
			});

			mockDataAcc.MockResult
				.Setup(x => x.GetCommandResultCount(pResultCount))
				.Returns(1);

			mockDataAcc.MockResult
				.Setup(x => x.ToElementAt<Member>(1, 0))
				.Returns(mem);

			mockDataAcc.MockResult
				.Setup(x => x.ToLongAt(2, 0))
				.Returns(appId);

			vMockData
				.Setup(x => x.Build(null, true, true))
				.Returns(mockDataAcc.Object);

			OauthMember result = vTasks.GetMemberByRefresh(vMockData.Object, code);

			if ( pResultCount == 0 ) {
				Assert.Null(result, "Result should be null.");
				return;
			}

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(mem, result.Member, "Incorrect Member.");
			Assert.AreEqual(appId, result.AppId, "Incorrect AppId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetDataProvMemberByApp() {
			const long appId = 1234512523;
			var mem = new Member();

			const string expectScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
				".outE('"+DbName.Edge.AppDefinesMemberName+"')"+
					".has('"+DbName.Edge.AppDefinesMember.MemberType+"',Tokens.T.eq,_P)"+
					".inV;";

			var expectParams = new List<object> {
				appId,
				(byte)MemberType.Id.DataProv
			};

			vMockData
				.Setup(x => x.Get<Member>(It.IsAny<IWeaverQuery>(), "OauthAccess-GetDPMemByApp"))
				.Callback((IWeaverScript q, string n) =>
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns(mem);

			Member result = vTasks.GetDataProvMemberByApp(vMockData.Object, appId);

			Assert.AreEqual(mem, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false)]
		[TestCase(true)]
		public void AddAccess(bool pClientMode) {
			const long memId = 763462332;
			const string code0 = "12351252sadfasdf";
			const string code1 = "362343fsdfsdfasd";
			const long utcNowTicks = 6423156122345252;
			const long utcExpireTicks = utcNowTicks + 3600*TimeSpan.TicksPerSecond;

			var mockAuth = new Mock<IOperationAuth>(MockBehavior.Strict);
			mockAuth.Setup(x => x.SetFabricActiveMember());
			mockAuth.Setup(x => x.RemoveFabricActiveMember());

			vMockOpCtx.SetupGet(x => x.Auth).Returns(mockAuth.Object);

			var codeQueue = new Queue<string>();
			codeQueue.Enqueue(code0);
			codeQueue.Enqueue(code1);

			var oa = new OauthAccess();
			oa.Token = "6512361236134fvaslkdjfds";
			oa.Refresh = "94856928345ksdljlsdkfuasd";

			vMockData
				.Setup(x => x.Execute(It.IsAny<IWeaverQuery>(), "OauthAccess-ClearOldTokens"))
				.Returns((IDataResult)null);

			vMockData
				.Setup(x => x.Build(null, true, true))
				.Returns(new DataAccess());

			vMockOpCtx
				.SetupGet(x => x.Code32)
				.Returns(codeQueue.Dequeue);

			vMockOpCtx
				.SetupGet(x => x.UtcNow)
				.Returns(new DateTime(utcNowTicks));

			var mockCreOp = new Mock<CreateOauthAccessOperation>(MockBehavior.Strict);

			mockCreOp
				.Setup(x => x.Execute(vMockOpCtx.Object, It.IsAny<ICreateOperationBuilder>(),
					It.IsAny<CreateOperationTasks>(), It.IsAny<CreateFabOauthAccess>()))
				.Callback((IOperationContext opCtx, ICreateOperationBuilder build, 
						CreateOperationTasks tasks, CreateFabOauthAccess cre) => {
					Assert.NotNull(cre, "Create should be filled.");
					Assert.AreEqual(code0, cre.Token, "Incorrect Create.Token.");
					Assert.AreEqual((pClientMode ? null : code1), cre.Refresh,
						"Incorrect Create.Refresh.");
					Assert.AreEqual(utcExpireTicks, cre.Expires, "Incorrect Create.Expires.");
					Assert.AreEqual(memId, cre.AuthenticatesMemberId,
						"Incorrect Create.AuthenticatesMemberId.");
				})
				.Returns(oa);

			FabOauthAccess result = vTasks.AddAccess(
				vMockOpCtx.Object, mockCreOp.Object, memId, pClientMode);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(oa.Token, result.AccessToken, "Incorrect AccessToken.");
			Assert.AreEqual(oa.Refresh, result.RefreshToken, "Incorrect RefreshToken.");
			Assert.AreEqual(3600, result.ExpiresIn, "Incorrect ExpiresIn.");
			Assert.AreEqual("bearer", result.TokenType, "Incorrect TokenType.");

			mockAuth.Verify(x => x.SetFabricActiveMember(), Times.Once);
			mockAuth.Verify(x => x.RemoveFabricActiveMember(), Times.Once);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ClearOldTokens() {
			const long memId = 1234512523;

			const string expectScript = 
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
				".outE('"+DbName.Edge.MemberAuthenticatedByOauthAccessName+"').inV"+
					".sideEffect{"+
						"it.removeProperty('"+DbName.Vert.OauthAccess.Token+"');"+
						"it.removeProperty('"+DbName.Vert.OauthAccess.Refresh+"');"+
					"};";

			var expectParams = new List<object> { memId };

			vMockData
				.Setup(x => x.Execute(It.IsAny<IWeaverQuery>(), "OauthAccess-ClearOldTokens"))
				.Callback((IWeaverScript q, string n) =>
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns((DataResult)null);

			OauthAccessTasks.ClearOldTokens(vMockData.Object, memId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewFault() {
			OauthException oe = vTasks.NewFault(AccessErrors.invalid_request, AccessErrorDescs.NoCode);

			Assert.NotNull(oe, "Result should not be null.");
			Assert.AreEqual("invalid_request", oe.OauthError.Error, "Incorrect OauthError.Error.");
			Assert.AreEqual(OauthAccessTasks.ErrDescStrings[(int)AccessErrorDescs.NoCode],
				oe.OauthError.ErrorDesc, "Incorrect OauthError.ErrorDesc.");
		}

	}

}