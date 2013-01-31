using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetArtifact : XModifyTasks {

		private long vArtifactId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Artifact TestGo() {
			return Tasks.GetArtifact(ApiCtx, vArtifactId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupArtifacts.ArtifactId.Thi_Blue)]
		[TestCase(SetupArtifacts.ArtifactId.App_KinPhoGal)]
		public void Found(SetupArtifacts.ArtifactId pArtifactId) {
			vArtifactId = (long)pArtifactId;

			Artifact result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vArtifactId, result.ArtifactId, "Incorrect ArtifactId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(999)]
		public void NotFound(long pArtifactId) {
			vArtifactId = pArtifactId;

			Artifact result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}