using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddUrl : XModifyTasks {

		//Check for duplicate URL occurs above the 'Task' level

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("http://www.web.com", "Web Page")]
		public void Success(string pPath, string pName) {
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Url> urlVar;
			var mem = new Member { MemberId = (long)SetupUsers.MemberId.GalZach };

			TxBuild.GetVertex(mem, out memVar);
			Tasks.TxAddUrl(ApiCtx, TxBuild, pPath, pName, memVar, out urlVar);
			FinishTx();

			ApiCtx.ExecuteForTest(TxBuild.Transaction);

			////

			Url newUrl = GetVertex<Url>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newUrl, "New Url was not created.");
			Assert.AreNotEqual(0, newUrl.ArtifactId, "Incorrect UrlId.");
			Assert.AreEqual(pPath, newUrl.FullPath, "Incorrect FullPath.");
			Assert.AreEqual(pName, newUrl.Name, "Incorrect Name.");

			VertexConnections conn = GetVertexConnections(newUrl);
			conn.AssertEdgeCount(1, 0);
			conn.AssertEdge<MemberCreatesArtifact, Member>(false, mem.MemberId);

			NewVertexCount = 1;
			NewEdgeCount = 1;
		}

	}

}