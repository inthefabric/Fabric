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
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Class> urlVar;

			TxBuild.GetRoot(out rootVar);
			Tasks.TxAddClass(ApiCtx, TxBuild, pName, pDisamb, pNote, rootVar, out urlVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddClass", TxBuild.Transaction);

			////

			Class newClass = GetNode<Class>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newClass, "New Class was not created.");

			NodeConnections conn = GetNodeConnections(newClass);
			conn.AssertRelCount(1, 0);
			conn.AssertRel<RootContainsClass, Root>(false, 0);

			NewNodeCount = 1;
			NewRelCount = 1;
		}

	}

}