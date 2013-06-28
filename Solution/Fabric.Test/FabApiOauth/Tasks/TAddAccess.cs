using System;
using System.Collections.Generic;
using Fabric.Api.Dto.Oauth;
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
	public class TAddAccess : TTestBase {

		private const string QueryClearTokens =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P)"+
			".inE('"+EdgeDbName.OauthAccessUsesApp+"').outV"+
				".has('"+PropDbName.OauthAccess_Token+"')"+
				".has('"+PropDbName.OauthAccess_IsClientOnly+"',Tokens.T.eq,_P)"+
				".as('step7')" +
			".outE('"+EdgeDbName.OauthAccessUsesUser+"').inV" +
				".has('"+PropDbName.Artifact_ArtifactId+"',Tokens.T.eq,_P)" +
			".back('step7')" +
				".sideEffect{"+
					"it.removeProperty('"+PropDbName.OauthAccess_Token+"');"+
					"it.removeProperty('"+PropDbName.OauthAccess_Refresh+"');"+
				"};";

		private const string QueryClearTokensClientOnly =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P)"+
			".inE('"+EdgeDbName.OauthAccessUsesApp+"').outV"+
				".has('"+PropDbName.OauthAccess_Token+"')"+
				".has('"+PropDbName.OauthAccess_IsClientOnly+"',Tokens.T.eq,_P)"+
				".sideEffect{"+
					"it.removeProperty('"+PropDbName.OauthAccess_Token+"');"+
					"it.removeProperty('"+PropDbName.OauthAccess_Refresh+"');"+
				"};";

		private const string QueryAddAccessTx =
			"_V0=g.addVertex(["+
				PropDbName.OauthAccess_OauthAccessId+":_TP,"+
				PropDbName.OauthAccess_Token+":_TP,"+
				PropDbName.OauthAccess_Refresh+":_TP,"+
				PropDbName.OauthAccess_Expires+":_TP,"+
				PropDbName.OauthAccess_IsClientOnly+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_V1=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V0,_V1,_TP);"+
			"_V2=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V0,_V2,_TP);";

		private const string QueryAddAccessTxClientOnly =
			"_V0=g.addVertex(["+
				PropDbName.OauthAccess_OauthAccessId+":_TP,"+
				PropDbName.OauthAccess_Token+":_TP,"+
				PropDbName.OauthAccess_Refresh+":_TP,"+
				PropDbName.OauthAccess_Expires+":_TP,"+
				PropDbName.OauthAccess_IsClientOnly+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_V1=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V0,_V1,_TP);";

		protected long vAddOauthAccessId;
		protected DateTime vUtcNow;
		protected long vAppId;
		protected long? vUserId;
		protected int vExpireSec;
		protected bool vClientOnly;
		protected int vCode32Count;
		protected string vTokenCode;
		protected string vRefreshCode;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAddOauthAccessId = 123456789;
			vUtcNow = DateTime.UtcNow;
			vAppId = 99;
			vUserId = 1234;
			vExpireSec = 3600;
			vClientOnly = false;
			vCode32Count = 0;
			vTokenCode = "12345678901234567890123456789012";
			vRefreshCode = "abcd5678901234567890123456789012";

			MockApiCtx.Setup(x => x.GetSharpflakeId<OauthAccess>()).Returns(vAddOauthAccessId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			MockApiCtx.SetupGet(x => x.Code32).Returns(GetCode32);
			
			var mda = MockDataAccess.Create(OnExecuteClear);
			MockDataList.Add(mda);
			
			mda = MockDataAccess.Create(OnExecuteAccess);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().AddAccess(
					vAppId, vUserId, vExpireSec, vClientOnly, MockApiCtx.Object);
			}

			var task = new AddAccess(vAppId, vUserId, vExpireSec, vClientOnly);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteClear(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			string expect = (vClientOnly ? QueryClearTokensClientOnly : QueryClearTokens);
			expect = TestUtil.InsertParamIndexes(expect, "_P");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			var vals = new List<object>();
			vals.Add(vAppId);
			vals.Add(vClientOnly);

			if ( !vClientOnly ) {
				vals.Add(vUserId);
			}

			TestUtil.CheckParams(cmd.Params, "_P", vals);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteAccess(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			string expect = (vClientOnly ? QueryAddAccessTxClientOnly : QueryAddAccessTx);
			expect = TestUtil.InsertParamIndexes(expect, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			var vals = new List<object>();
			vals.Add(vAddOauthAccessId);
			vals.Add(vTokenCode);
			vals.Add(vRefreshCode);
			vals.Add(vUtcNow.AddSeconds(vExpireSec).Ticks);
			vals.Add(vClientOnly);
			vals.Add((byte)VertexFabType.OauthAccess);
			vals.Add(vAppId);
			vals.Add(EdgeDbName.OauthAccessUsesApp);

			if ( !vClientOnly ) {
				vals.Add(vUserId);
				vals.Add(EdgeDbName.OauthAccessUsesUser);
			}

			TestUtil.CheckParams(cmd.Params, "_TP", vals);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string GetCode32() {
			switch ( vCode32Count++ ) {
				case 0: return vTokenCode;
				case 1: return vRefreshCode;
			}

			return null;
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

			AssertDataExecution(true);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vTokenCode, result.AccessToken, "Incorrect Result.AccessToken.");
			Assert.AreEqual(vRefreshCode, result.RefreshToken, "Incorrect Result.RefreshToken.");
			Assert.AreEqual("bearer", result.TokenType, "Incorrect Result.TokenType.");
			Assert.AreEqual(3600, result.ExpiresIn, "Incorrect Result.ExpiresIn.");

			MockMemCache.Verify(x => x.RemoveOauthAccesses(vAppId, vUserId), Times.Once());
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
		[TestCase(false, null)]
		[TestCase(false, 0L)]
		[TestCase(true, 1L)]
		[TestCase(true, 0L)]
		[TestCase(true, -1L)]
		public virtual void ErrUserId(bool pIsClientOnly, long? pUserId) {
			vClientOnly = pIsClientOnly;
			vUserId = pUserId;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

	}

}