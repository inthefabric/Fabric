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
	public class TAddGrant : TTestBase {

		private const string QueryUpdateGrantTx =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_TP)"+
			".inE('"+EdgeDbName.OauthGrantUsesUser+"').outV"+
				".as('step5')"+
			".outE('"+EdgeDbName.OauthGrantUsesApp+"').inV"+
				".has('"+PropDbName.Artifact_ArtifactId+"',Tokens.T.eq,_TP)"+
			".back('step5')"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.OauthGrant_RedirectUri+"',_TP);"+
					"it.setProperty('"+PropDbName.OauthGrant_Expires+"',_TP);"+
					"it.setProperty('"+PropDbName.OauthGrant_Code+"',_TP);"+
				"};";

		private const string QueryAddGrantTx =
			"_V0=g.addVertex(["+
				PropDbName.OauthGrant_OauthGrantId+":_TP,"+
				PropDbName.OauthGrant_RedirectUri+":_TP,"+
				PropDbName.OauthGrant_Code+":_TP,"+
				PropDbName.OauthGrant_Expires+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_V1=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V0,_V1,_TP);"+
			"_V2=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V0,_V2,_TP);";

		protected long vAppId;
		protected long vUserId;
		protected string vRedirUri;
		protected string vGrantCode;
		protected DateTime vUtcNow;
		protected long vAddOauthGrantId;
		private OauthGrant vGrantResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 99;
			vUserId = 1234;
			vRedirUri = "http://www.TEST.com/oauth";
			vGrantCode = "12345678901234567890123456789012";
			vUtcNow = DateTime.UtcNow;
			vAddOauthGrantId = 123456789;
			
			vGrantResult = new OauthGrant();
			vGrantResult.Code = vGrantCode;

			MockApiCtx.Setup(x => x.GetSharpflakeId<OauthGrant>()).Returns(vAddOauthGrantId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			MockApiCtx.SetupGet(x => x.Code32).Returns(vGrantCode);
			
			var mda = MockDataAccess.Create(OnExecuteUpdate);
			mda.MockResult.SetupToElement(vGrantResult);
			MockDataList.Add(mda);
			
			mda = MockDataAccess.Create(OnExecuteAdd);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private string TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().AddGrant(vAppId, vUserId, vRedirUri, MockApiCtx.Object);
			}

			var task = new AddGrant(vAppId, vUserId, vRedirUri);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteUpdate(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			string expect = TestUtil.InsertParamIndexes(QueryUpdateGrantTx, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_TP", new object[] {
				vUserId,
				vAppId,
				vRedirUri.ToLower(),
				vUtcNow.AddMinutes(2).Ticks,
				vGrantCode
			});
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteAdd(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			
			string expect = TestUtil.InsertParamIndexes(QueryAddGrantTx, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_TP", new object[] {
				vAddOauthGrantId,
				vRedirUri.ToLower(),
				vGrantCode,
				vUtcNow.AddMinutes(2).Ticks,
				(byte)VertexFabType.OauthGrant,
				vAppId,
				EdgeDbName.OauthGrantUsesApp,
				vUserId,
				EdgeDbName.OauthGrantUsesUser
			});
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void UpdateSuccess(bool pViaTask) {
			string result = TestGo(pViaTask);
			
			AssertDataExecution(new [] { 1, 0 });
			Assert.AreEqual(vGrantCode, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void AddGrantSuccess(bool pViaTask) {
			MockDataList[0].MockResult.SetupToElement<OauthGrant>(null);
			
			string result = TestGo(pViaTask);
			
			AssertDataExecution(true);
			Assert.AreEqual(vGrantCode, result, "Incorrect Result.");
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