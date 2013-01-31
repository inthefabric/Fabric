using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddInstance : XModifyTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("Instance Name", "Instance Disambiguation", "Instance Note")]
		public void Success(string pName, string pDisamb, string pNote) {
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Instance> urlVar;

			TxBuild.GetRoot(out rootVar);
			Tasks.TxAddInstance(ApiCtx, TxBuild, pName, pDisamb, pNote, rootVar, out urlVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddInstance", TxBuild.Transaction);

			////

			Instance newInstance = GetNode<Instance>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newInstance, "New Instance was not created.");

			NodeConnections conn = GetNodeConnections(newInstance);
			conn.AssertRelCount(1, 0);
			conn.AssertRel<RootContainsInstance, Root>(false, 0);

			NewNodeCount = 1;
			NewRelCount = 1;
		}

	}

}