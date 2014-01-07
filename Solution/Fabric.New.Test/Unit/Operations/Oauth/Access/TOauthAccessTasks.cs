using System.Collections.Generic;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;
using Fabric.New.Operations;
using Fabric.New.Operations.Oauth;
using Fabric.New.Operations.Oauth.Access;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Operations.Oauth.Access {

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
		[Test]
		public void GetMemberByGrant() {
			const long appId = 125125235;
			const string code = "asdugalsdgualsdkgulsdkug";
			var mem = new Member();

			var mockDataAcc = MockDataAccess.Create(mda => {
				string expectScript = "m=g.V('"+DbName.Vert.Member.OauthGrantCode+"',_P);";
				var expectParam = new List<object> { code };
				TestUtil.CheckWeaverScript(mda.GetCommand(0), expectScript, "_P", expectParam);

				expectScript = "m.outE('"+DbName.Edge.MemberDefinedByAppName+"')"+
					".inV.property('"+DbName.Vert.Vertex.VertexId+"');";
				expectParam = new List<object>();
				TestUtil.CheckWeaverScript(mda.GetCommand(1), expectScript, "_P", expectParam);

				Assert.AreEqual("OauthAccess-GetMemberByGrant", 
					mda.Object.ExecuteName, "Incorrect ExecuteName.");
			});

			mockDataAcc.MockResult
				.Setup(x => x.ToElementAt<Member>(0, 0))
				.Returns(mem);

			mockDataAcc.MockResult
				.Setup(x => x.ToLongAt(1, 0))
				.Returns(appId);

			vMockData
				.Setup(x => x.Build(null, false, true))
				.Returns(mockDataAcc.Object);

			OauthMember result = vTasks.GetMemberByGrant(vMockData.Object, code);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(mem, result.Member, "Incorrect Member.");
			Assert.AreEqual(appId, result.AppId, "Incorrect AppId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetMemberByRefresh() {
			const long appId = 125125235;
			const string code = "asdugalsdgualsdkgulsdkug";
			var mem = new Member();

			var mockDataAcc = MockDataAccess.Create(mda => {
				string expectScript = "m=g.V('"+DbName.Vert.OauthAccess.Refresh+"',_P)"+
					".outE('"+DbName.Edge.OauthAccessAuthenticatesMemberName+"').inV;";
				var expectParam = new List<object> { code };
				TestUtil.CheckWeaverScript(mda.GetCommand(0), expectScript, "_P", expectParam);

				expectScript = "m.outE('"+DbName.Edge.MemberDefinedByAppName+"')"+
					".inV.property('"+DbName.Vert.Vertex.VertexId+"');";
				expectParam = new List<object>();
				TestUtil.CheckWeaverScript(mda.GetCommand(1), expectScript, "_P", expectParam);

				Assert.AreEqual("OauthAccess-GetMemberByRefresh",
					mda.Object.ExecuteName, "Incorrect ExecuteName.");
			});

			mockDataAcc.MockResult
				.Setup(x => x.ToElementAt<Member>(0, 0))
				.Returns(mem);

			mockDataAcc.MockResult
				.Setup(x => x.ToLongAt(1, 0))
				.Returns(appId);

			vMockData
				.Setup(x => x.Build(null, false, true))
				.Returns(mockDataAcc.Object);

			OauthMember result = vTasks.GetMemberByRefresh(vMockData.Object, code);

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

	}

}