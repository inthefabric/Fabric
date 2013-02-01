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
			"g.V('"+typeof(Artifact).Name+"Id',{{ArtifactId}}L)[0];";

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

			string expect = Query.Replace("{{ArtifactId}}", vArtifactId+"");
			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");

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