using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;
using Fabric.Test.Common;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetOauthDomainByDomain : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
			".inE('"+EdgeDbName.OauthDomainUsesApp+"').outV"+
				".filter{it.getProperty('"+PropDbName.OauthDomain_Domain+"').toLowerCase()==_P1};";

		private long vAppId;
		private string vDomain;
		private OauthDomain vOauthDomainResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 462346;
			vDomain = "TestOauthDomain";
			vOauthDomainResult = new OauthDomain();

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vOauthDomainResult);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			
			Assert.AreEqual(Query, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vAppId);
			TestUtil.CheckParam(cmd.Params, "_P1", vDomain.ToLower());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			OauthDomain result = Tasks.GetOauthDomainByDomain(MockApiCtx.Object, vAppId, vDomain);

			AssertDataExecution(true);
			Assert.AreEqual(vOauthDomainResult, result, "Incorrect Result.");
		}

	}

}