﻿using System;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddScope {

		private const string QueryUpdateScopeTx =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_TP)"+
			".inE('"+EdgeDbName.OauthScopeUsesUser+"').outV"+
				".as('step5')"+
			".outE('"+EdgeDbName.OauthScopeUsesApp+"').inV"+
				".has('"+PropDbName.Artifact_ArtifactId+"',Tokens.T.eq,_TP)"+
			".back('step5')"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.OauthScope_Allow+"',_TP);"+
					"it.setProperty('"+PropDbName.OauthScope_Created+"',_TP);"+
				"};";

		private const string QueryAddScopeTx =
			"_V0=g.addVertex(["+
				PropDbName.OauthScope_OauthScopeId+":_TP,"+
				PropDbName.OauthScope_Allow+":_TP,"+
				PropDbName.OauthScope_Created+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_V1=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V0,_V1,_TP);"+
			"_V2=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V0,_V2,_TP);"+
			"_V0;";

		private long vAppId;
		private long vUserId;
		private bool vAllow;
		private DateTime vUtcNow;
		private long vAddOauthScopeId;
		private OauthScope vScopeResult;
		private OauthScope vAddScopeResult;
		private Mock<IApiContext> vMockCtx;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vAppId = 99;
			vUserId = 1234;
			vAllow = true;
			vUtcNow = DateTime.UtcNow;
			vAddOauthScopeId = 123456789;
			vUsageMap = new UsageMap();
			
			vScopeResult = new OauthScope();
			vAddScopeResult = new OauthScope();

			vMockCtx = new Mock<IApiContext>();
			vMockCtx.Setup(x => x.GetSharpflakeId<OauthScope>()).Returns(vAddOauthScopeId);
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			
			vMockCtx
				.Setup(x => x.DbSingle<OauthScope>(
					AddScope.Query.UpdateScopeTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverScript ws) => UpdateScope(ws));
			
			vMockCtx
				.Setup(x => x.DbSingle<OauthScope>(
					AddScope.Query.AddScopeTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverScript ws) => AddScopeTx(ws));
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthScope TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().AddScope(vAppId, vUserId, vAllow, vMockCtx.Object);
			}

			var task = new AddScope(vAppId, vUserId, vAllow);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthScope UpdateScope(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddScope.Query.UpdateScopeTx+"");

			string expect = TestUtil.InsertParamIndexes(QueryUpdateScopeTx, "_TP");
			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pScripted.Params, "_TP", new object[] {
				vUserId,
				vAppId,
				vAllow,
				vUtcNow.Ticks
			});
			
			return vScopeResult;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthScope AddScopeTx(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddScope.Query.AddScopeTx+"");

			string expect = TestUtil.InsertParamIndexes(QueryAddScopeTx, "_TP");
			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pScripted.Params, "_TP", new object[] {
				vAddOauthScopeId,
				vAllow,
				vUtcNow.Ticks,
				(byte)VertexFabType.OauthScope,
				vAppId,
				EdgeDbName.OauthScopeUsesApp,
				vUserId,
				EdgeDbName.OauthScopeUsesUser
			});
			
			return vAddScopeResult;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void UpdateSuccess(bool pViaTask) {
			OauthScope result = TestGo(pViaTask);

			vUsageMap.AssertUses(AddScope.Query.UpdateScopeTx+"", 1);
			vUsageMap.AssertUses(AddScope.Query.AddScopeTx+"", 0);
			Assert.AreEqual(vScopeResult, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void AddScopeSuccess(bool pViaTask) {
			vScopeResult = null;
			
			OauthScope result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddScope.Query.UpdateScopeTx+"", 1);
			vUsageMap.AssertUses(AddScope.Query.AddScopeTx+"", 1);
			Assert.AreEqual(vAddScopeResult, result, "Incorrect Result.");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public virtual void ErrAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public virtual void ErrUserId() {
			vUserId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}