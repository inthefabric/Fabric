﻿using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Cache;
using Fabric.Infrastructure.Data;
using Fabric.Operations;
using Fabric.Operations.Oauth;
using Fabric.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Oauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthLogoutTasks {

		private Mock<IOperationData> vMockData;
		private Mock<IOperationContext> vMockOpCtx;

		private OauthLogoutTasks vTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vMockData = new Mock<IOperationData>(MockBehavior.Strict);

			vMockOpCtx = new Mock<IOperationContext>(MockBehavior.Strict);
			vMockOpCtx.SetupGet(x => x.Data).Returns(vMockData.Object);

			vTasks = new OauthLogoutTasks();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AssertFault(TestDelegate pDelegate, LogoutErrors pError, LogoutErrorDescs pDesc) {
			OauthException oe = TestUtil.Throws<OauthException>(pDelegate);

			Assert.NotNull(oe.OauthError, "OauthError should filled.");
			Assert.AreEqual(pError+"", oe.OauthError.Error, "Invalid OauthError.Error");
			Assert.AreEqual(OauthLogoutTasks.ErrDescStrings[(int)pDesc]+"",
				oe.OauthError.ErrorDesc, "Invalid OauthError.ErrorDesc");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase("")]
		[TestCase("x")]
		[TestCase("1234567890123456789012345678901")]
		[TestCase("123456789012345678901234567890123")]
		public void GetAccessTokenBadToken(string pToken) {
			AssertFault(() => vTasks.GetAccessToken(vMockData.Object, pToken),
				LogoutErrors.invalid_request, LogoutErrorDescs.BadToken);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAccessTokenNoTokenMatch() {
			const string token = "12345678901234567890123456789012";

			vMockData
				.Setup(x => x.Get<OauthAccess>(It.IsAny<IWeaverQuery>(), "OauthLogout-GetAccessToken"))
				.Returns((OauthAccess)null);

			AssertFault(() => vTasks.GetAccessToken(vMockData.Object, token),
				LogoutErrors.invalid_request, LogoutErrorDescs.NoTokenMatch);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetAccessTokenSuccess() {
			const string token = "12345678901234567890123456789012";
			var oa = new OauthAccess();

			const string expectScript = "g.V('"+DbName.Vert.OauthAccess.Token+"',_P);";
			var expectParams = new List<object> { token };

			vMockData
				.Setup(x => x.Get<OauthAccess>(It.IsAny<IWeaverQuery>(), "OauthLogout-GetAccessToken"))
				.Callback((IWeaverScript q, string n) => 
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns(oa);

			OauthAccess result = vTasks.GetAccessToken(vMockData.Object, token);

			Assert.AreEqual(oa, result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DoLogoutFailed() {
			vMockData
				.Setup(x => x.Get<Member>(It.IsAny<IWeaverQuery>(), "OauthLogout-GetMember"))
				.Throws(new Exception("test"));

			AssertFault(() => vTasks.DoLogout(vMockOpCtx.Object, new OauthAccess()),
				LogoutErrors.logout_failure, LogoutErrorDescs.LogoutFailed);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DoLogoutSuccess() {
			var oa = new OauthAccess { VertexId = 12352532 };
			var mem = new Member { VertexId = 98736455 };

			const string expectScript =
				"g.V('"+DbName.Vert.Vertex.VertexId+"',_P)"+
				".outE('"+DbName.Edge.OauthAccessAuthenticatesMemberName+"').inV;";

			var expectParams = new List<object> { oa.VertexId };

			vMockData
				.Setup(x => x.Get<Member>(It.IsAny<IWeaverQuery>(), "OauthLogout-GetMember"))
				.Callback((IWeaverScript q, string n) =>
					TestUtil.CheckWeaverScript(q, expectScript, "_P", expectParams))
				.Returns(mem);
			
			vMockData
				.Setup(x => x.Execute(It.IsAny<IWeaverQuery>(), "OauthAccess-ClearOldTokens"))
				.Returns((IDataResult)null);

			var mockMemCache = new Mock<IMemCache>(MockBehavior.Strict);
			mockMemCache.Setup(x => x.RemoveOauthMembers(mem.VertexId));

			var mockCacheMan = new Mock<ICacheManager>(MockBehavior.Strict);
			mockCacheMan.SetupGet(x => x.Memory).Returns(mockMemCache.Object);

			vMockOpCtx.SetupGet(x => x.Cache).Returns(mockCacheMan.Object);

			vTasks.DoLogout(vMockOpCtx.Object, oa);

			mockMemCache.Verify(x => x.RemoveOauthMembers(mem.VertexId), Times.Once);
		}

	}

}