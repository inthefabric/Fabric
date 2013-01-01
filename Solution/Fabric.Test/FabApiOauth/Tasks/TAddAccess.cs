using Moq;
using Fabric.Infrastructure.Api;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using NUnit.Framework;
using Weaver.Interfaces;
using Fabric.Domain;
using Fabric.Infrastructure;
using System.Linq.Expressions;
using System;
using Fabric.Test.Util;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddAccess {

		protected static string[] vQueries = new [] {
			//ClearTokens
			"g.v(0)"+
				".outE('RootContainsOauthAccess').inV"+
					".has('Token',Tokens.T.neq,null)"+
					".as('step4')" +
				".outE('OauthAccessUsesApp')[0].inV(0)" +
					".has('AppId',Tokens.T.eq,{{AppId}}L)" +
				".back('step4')" +
				".outE('OauthAccessUsesUser')[0].inV(0)" +
					".has('UserId',Tokens.T.eq,{{UserId}})" +
				".back('step4')" +
					".each{it.Token=null};",

			//AddNode
			null,

			//GetApp
			"g.idx(_P0).get('AppId',{{AppId}}L);",

			//AddAppRel
			"f=g.v({{OauthAccessId}}L);"+
			"t=g.v({{AppId}}L);"+
			"g.addEdge(f,t,_P0);",

			//GetUser
			"g.idx(_P0).get('UserId',{{UserId}}L);",

			//AddUserRel
			"f=g.v({{OauthAccessId}}L);"+
			"t=g.v({{UserId}}L);"+
			"g.addEdge(f,t,_P0);"
		};
		
		protected long vAppId;
		protected long? vUserId;
		protected int vExpireSec;
		protected bool vClientOnly;

		protected Mock<IApiContext> vMockCtx;

		protected OauthAccess vAddAccessResult;
		protected App vGetAppResult;
		protected User vGetUserResult;
		protected UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vAppId = 99;
			vUserId = 1234;
			vExpireSec = 3600;
			vClientOnly = false;

			vAddAccessResult = new OauthAccess();
			vAddAccessResult.Id = 8585;
			vAddAccessResult.Token = "12345678901234567890123456789012";
			vAddAccessResult.Refresh = "abcd5678901234567890123456789012";

			vGetAppResult = new App { Id = 5678 };
			vGetUserResult = new User { Id = 9876 };
			vUsageMap = new UsageMap();

			vMockCtx = new Mock<IApiContext>();
			
			vMockCtx
				.Setup(x => x.DbData(
					AddAccess.Query.ClearTokens+"", It.IsAny<IWeaverQuery>()))
					.Returns((string s, IWeaverQuery q) => ClearTokens(q));
			
			vMockCtx
				.Setup(x => 
					x.DbAddNode<OauthAccess, RootContainsOauthAccess>(
						AddAccess.Query.AddAccess+"", 
						It.IsAny<OauthAccess>(),
						It.IsAny<Expression<Func<OauthAccess,object>>>()
					)
				)
				.Returns(vAddAccessResult);

			vMockCtx
				.Setup(x => x.DbSingle<App>(
					AddAccess.Query.GetApp+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetApp(q));
			
			vMockCtx
				.Setup(x => x.DbData(
					AddAccess.Query.AddAppRel+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => AddAppRel(q));

			vMockCtx
				.Setup(x => x.DbSingle<User>(
					AddAccess.Query.GetUser+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetUser(q));

			vMockCtx
				.Setup(x => x.DbData(
					AddAccess.Query.AddUserRel+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => AddUserRel(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().AddAccess(
					vAppId, vUserId, vExpireSec, vClientOnly, vMockCtx.Object);
			}

			var task = new AddAccess(vAppId, vUserId, vExpireSec, vClientOnly);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess ClearTokens(IWeaverQuery pQuery) {
			TestUtil.LogQuery(pQuery);
			vUsageMap.Increment(AddAccess.Query.ClearTokens+"");
			
			string expect = vQueries[(int)AddAccess.Query.ClearTokens]
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", (vUserId == null ? "null" : vUserId+"L"));
			
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			return new ApiDataAccess(null, null, null);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private App GetApp(IWeaverQuery pQuery) {
			TestUtil.LogQuery(pQuery);
			vUsageMap.Increment(AddAccess.Query.GetApp+"");

			string expect = vQueries[(int)AddAccess.Query.GetApp]
				.Replace("{{AppId}}", vAppId+"");

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", typeof(App).Name);
			return vGetAppResult;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess AddAppRel(IWeaverQuery pQuery) {
			TestUtil.LogQuery(pQuery);
			vUsageMap.Increment(AddAccess.Query.AddAppRel+"");
			
			string expect = vQueries[(int)AddAccess.Query.AddAppRel]
				.Replace("{{OauthAccessId}}", vAddAccessResult.Id+"")
				.Replace("{{AppId}}", vGetAppResult.Id+"");
			
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			return new ApiDataAccess(null, null, null);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private User GetUser(IWeaverQuery pQuery) {
			TestUtil.LogQuery(pQuery);
			vUsageMap.Increment(AddAccess.Query.GetUser+"");

			string expect = vQueries[(int)AddAccess.Query.GetUser]
				.Replace("{{UserId}}", vUserId+"");
			
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", typeof(User).Name);
			return vGetUserResult;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess AddUserRel(IWeaverQuery pQuery) {
			TestUtil.LogQuery(pQuery);
			vUsageMap.Increment(AddAccess.Query.AddUserRel+"");
			
			string expect = vQueries[(int)AddAccess.Query.AddUserRel]
			.Replace("{{OauthAccessId}}", vAddAccessResult.Id+"")
				.Replace("{{UserId}}", vGetUserResult.Id+"");
			
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			return new ApiDataAccess(null, null, null);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, true)]
		[TestCase(true, false)]
		[TestCase(false, true)]
		[TestCase(false, false)]
		public virtual void Success(bool pClientOnly, bool pViaTask) {
			vClientOnly = pClientOnly;
			
			if ( vClientOnly ) {
				vUserId = null;
			}
									
			FabOauthAccess result = TestGo(pViaTask);

			vUsageMap.AssertUses(AddAccess.Query.ClearTokens+"", 1);
			vUsageMap.AssertUses(AddAccess.Query.GetApp+"", 1);
			vUsageMap.AssertUses(AddAccess.Query.AddAppRel+"", 1);
			vUsageMap.AssertUses(AddAccess.Query.GetUser+"", (vClientOnly ? 0 : 1));
			vUsageMap.AssertUses(AddAccess.Query.AddUserRel+"", (vClientOnly ? 0 : 1));

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vAddAccessResult.Token, result.AccessToken,
				"Incorrect Result.AccessToken.");
			Assert.AreEqual(vAddAccessResult.Refresh, result.RefreshToken,
				"Incorrect Result.RefreshToken.");
			Assert.AreEqual("bearer", result.TokenType, "Incorrect Result.TokenType.");
			Assert.AreEqual(3600, result.ExpiresIn, "Incorrect Result.ExpiresIn.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public virtual void ErrAppId(long pAppId) {
			vAppId = pAppId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false, null)]
		[TestCase(false, 0L)]
		[TestCase(false, -1L)]
		[TestCase(true, 1L)]
		[TestCase(true, 0L)]
		[TestCase(true, -1L)]
		public virtual void ErrUserId(bool pIsClientOnly, long? pUserId) {
			vClientOnly = pIsClientOnly;
			vUserId = pUserId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}