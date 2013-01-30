using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddUrl : XModifyTasks {

		//Check for duplicate URL occurs above the 'Task' level

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("http://www.web.com", "Web Page")]
		public void Success(string pAbsoluteUrl, string pName) {
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Url> urlVar;

			TxBuild.GetRoot(out rootVar);
			Tasks.TxAddUrl(Context, TxBuild, pAbsoluteUrl, pName, rootVar, out urlVar);
			FinishTx();

			Context.DbData("TEST.TxAddUrl", TxBuild.Transaction);

			////

			Url newUrl = GetNode<Url>(Context.SharpflakeIds[0]);
			Assert.NotNull(newUrl, "New Url was not created.");

			NodeConnections conn = GetNodeConnections(newUrl);
			conn.AssertRelCount(1, 0);
			conn.AssertRel<RootContainsUrl, Root>(false, 0);

			NewNodeCount = 1;
			NewRelCount = 1;
		}

	}

}