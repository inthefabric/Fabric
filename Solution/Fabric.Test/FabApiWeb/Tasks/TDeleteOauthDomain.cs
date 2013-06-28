using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;
using Fabric.Test.Common;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TDeleteOauthDomain : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
			".inE('"+EdgeDbName.OauthDomainUsesApp+"').outV"+
				".has('"+PropDbName.OauthDomain_OauthDomainId+"',Tokens.T.eq,_P1)"+
				".remove();";

		private long vAppId;
		private long vOauthDomainId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 3456;
			vOauthDomainId = 842645;

			var mda = MockDataAccess.Create(OnExecute);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			Assert.AreEqual(Query, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vAppId);
			TestUtil.CheckParam(cmd.Params, "_P1", vOauthDomainId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			bool result = Tasks.DeleteOauthDomain(MockApiCtx.Object, vAppId, vOauthDomainId);

			AssertDataExecution(true);
			Assert.True(result, "Incorrect Result.");
		}

	}

}