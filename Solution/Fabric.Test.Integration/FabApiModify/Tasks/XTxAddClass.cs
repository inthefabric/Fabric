using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddClass : XModifyTasks {

		//Check for duplicate Name+Disamb occurs above the 'Task' level

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("Class Name", "Class Disambiguation", "Class Note")]
		public void Success(string pName, string pDisamb, string pNote) {
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Class> urlVar;
			var mem = new Member { MemberId = (long)SetupUsers.MemberId.GalZach };

			TxBuild.GetNode(mem, out memVar);
			Tasks.TxAddClass(ApiCtx, TxBuild, pName, pDisamb, pNote, memVar, out urlVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddClass", TxBuild.Transaction);

			////

			Class newClass = GetNode<Class>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newClass, "New Class was not created.");
			Assert.AreNotEqual(0, newClass.ClassId, "Incorrect ClassId.");
			Assert.AreEqual(pName, newClass.Name, "Incorrect Name.");
			Assert.AreEqual(pDisamb, newClass.Disamb, "Incorrect Disamb.");
			Assert.AreEqual(pNote, newClass.Note, "Incorrect Note.");

			NodeConnections conn = GetNodeConnections(newClass);
			conn.AssertRelCount(1, 0);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, mem.MemberId);

			NewNodeCount = 1;
			NewRelCount = 1;
		}

	}

}