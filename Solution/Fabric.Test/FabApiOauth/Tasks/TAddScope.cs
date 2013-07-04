using System;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;
using Fabric.Test.Common;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddScope : TTestBase {

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
			"_PROP=[:];"+
			"g.addEdge(_V0,_V1,_TP,_PROP);"+
			"_V2=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"_PROP=[:];"+
			"g.addEdge(_V0,_V2,_TP,_PROP);"+
			"_V0;";

		private long vAppId;
		private long vUserId;
		private bool vAllow;
		private DateTime vUtcNow;
		private long vAddOauthScopeId;
		private OauthScope vScopeResult;
		private OauthScope vAddScopeResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 99;
			vUserId = 1234;
			vAllow = true;
			vUtcNow = DateTime.UtcNow;
			vAddOauthScopeId = 123456789;
			
			vScopeResult = new OauthScope();
			vAddScopeResult = new OauthScope();

			MockApiCtx.Setup(x => x.GetSharpflakeId<OauthScope>()).Returns(vAddOauthScopeId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			
			var mda = MockDataAccess.Create(OnExecuteUpdate);
			mda.MockResult.SetupToElement(vScopeResult);
			MockDataList.Add(mda);
			
			mda = MockDataAccess.Create(OnExecuteAdd);
			mda.MockResult.SetupToElement(vAddScopeResult);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthScope TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().AddScope(vAppId, vUserId, vAllow, MockApiCtx.Object);
			}

			var task = new AddScope(vAppId, vUserId, vAllow);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteUpdate(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			string expect = TestUtil.InsertParamIndexes(QueryUpdateScopeTx, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_TP", new object[] {
				vUserId,
				vAppId,
				vAllow,
				vUtcNow.Ticks
			});
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteAdd(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			
			string expect = TestUtil.InsertParamIndexes(QueryAddScopeTx, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_TP", new object[] {
				vAddOauthScopeId,
				vAllow,
				vUtcNow.Ticks,
				(byte)VertexFabType.OauthScope,
				vAppId,
				EdgeDbName.OauthScopeUsesApp,
				vUserId,
				EdgeDbName.OauthScopeUsesUser
			});
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void UpdateSuccess(bool pViaTask) {
			OauthScope result = TestGo(pViaTask);

			AssertDataExecution(new [] { 1, 0 });
			Assert.AreEqual(vScopeResult, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void AddScopeSuccess(bool pViaTask) {
			MockDataList[0].MockResult.SetupToElement<OauthScope>(null);
			
			OauthScope result = TestGo(pViaTask);
			
			AssertDataExecution(true);
			Assert.AreEqual(vAddScopeResult, result, "Incorrect Result.");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public virtual void ErrAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public virtual void ErrUserId() {
			vUserId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

	}

}