using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetArtifact : TModifyTasks {

		private static readonly string Query = 
			"g.V('"+typeof(Artifact).Name+"Id',_P0);";

		private long vArtifactId;
		private Artifact vArtifactResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vArtifactId = 3456;
			vArtifactResult = new Artifact();

			MockApiCtx
				.Setup(x => x.DbSingle<Artifact>("GetArtifact", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetArtifact(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Artifact GetArtifact(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetArtifact");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vArtifactId);

			return vArtifactResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Artifact result = Tasks.GetArtifact(MockApiCtx.Object, vArtifactId);

			UsageMap.AssertUses("GetArtifact", 1);
			Assert.AreEqual(vArtifactResult, result, "Incorrect Result.");
		}

	}

}