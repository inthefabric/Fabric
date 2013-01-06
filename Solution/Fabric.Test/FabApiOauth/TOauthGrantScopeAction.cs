﻿using Fabric.Api.Oauth;
using Moq;
using Fabric.Api.Oauth.Tasks;
using NUnit.Framework;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Results;
using System;
using Fabric.Test.Util;

namespace Fabric.Test.FabApiOauth {

	/*================================================================================================*/
	[TestFixture]
	public class TOauthScopeLoginAction {
	
		private bool vAllowScope;
		
		private Mock<IApiContext> vMockCtx;
		private Mock<IOauthGrantCore> vMockCore;
		private Mock<IOauthTasks> vMockTasks;
		private LoginScopeResult vCoreScopeResult;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vAllowScope = true;
			
			vCoreScopeResult = new LoginScopeResult() { Code = "FakeCode123", Redirect = "Redir" };
			long appId = 125312;
			long userId = 6223;
			
			vMockCtx = new Mock<IApiContext>();
			
			vMockTasks = new Mock<IOauthTasks>();
			vMockTasks.Setup(x => x.AddScope(appId, userId, false, vMockCtx.Object))
				.Returns(new OauthScope());
				
			vMockCore = new Mock<IOauthGrantCore>();
			vMockCore.SetupGet(x => x.AppId).Returns(appId);
			vMockCore.SetupGet(x => x.UserId).Returns(userId);
			vMockCore.Setup(x => x.AddGrantCode(false, vMockTasks.Object, vMockCtx.Object))
				.Returns(vCoreScopeResult);
			vMockCore.Setup(x => x.GetFault(GrantErrors.access_denied, GrantErrorDescs.AccessDeny))
				.Returns(new OauthException("x", "y"));
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public LoginScopeResult TestGo() {
			var func = new OauthGrantScopeAction(vAllowScope, vMockCore.Object, vMockTasks.Object);
			return func.Go(vMockCtx.Object);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AllowScope() {
			LoginScopeResult result = TestGo();
			
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vCoreScopeResult.Redirect, result.Redirect, "Incorrect Result.Redirect.");
			Assert.AreEqual(vCoreScopeResult.Code, result.Code, "Incorrect Result.Code.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DenyScope() {
			vAllowScope = false;
			TestUtil.CheckThrows<OauthException>(true, () => TestGo());
			vMockCore.Verify(x => x.AddGrantCode(It.IsAny<bool>(), It.IsAny<IOauthTasks>(),
				It.IsAny<IApiContext>()), Times.Never());
		}
		
	}

}