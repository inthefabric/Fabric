using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddClass : XModifyTasks {

		//Check for duplicate Name+Disamb occurs above the 'Task' level

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("Class Name", null, "Class Note")]
		[TestCase("Class Name", "Class Disambiguation", "Class Note")]
		public void Success(string pName, string pDisamb, string pNote) {
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Class> urlVar;
			var mem = new Member { MemberId = (long)SetupUsers.MemberId.GalZach };

			TxBuild.GetVertex(mem, out memVar);
			Tasks.TxAddClass(ApiCtx, TxBuild, pName, pDisamb, pNote, memVar, out urlVar);
			FinishTx();

			ApiCtx.ExecuteForTest(TxBuild.Transaction);

			////

			Class newClass = GetVertex<Class>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newClass, "New Class was not created.");
			Assert.AreNotEqual(0, newClass.ArtifactId, "Incorrect ClassId.");
			Assert.AreEqual(pName, newClass.Name, "Incorrect Name.");
			Assert.AreEqual(pDisamb, newClass.Disamb, "Incorrect Disamb.");
			Assert.AreEqual(pNote, newClass.Note, "Incorrect Note.");

			VertexConnections conn = GetVertexConnections(newClass);
			conn.AssertEdgeCount(1, 0);
			conn.AssertEdge<MemberCreatesArtifact, Member>(false, mem.MemberId);

			NewVertexCount = 1;
			NewEdgeCount = 1;
		}

	}

}