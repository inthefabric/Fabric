using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddEmail : XModifyTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test@test.com")]
		public void Success(string pAddress) {
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Email> emailVar;

			TxBuild.GetRoot(out rootVar);
			Tasks.TxAddEmail(Context, TxBuild, pAddress, rootVar, out emailVar);
			FinishTx();

			Context.DbData("TEST.TxAddEmail", TxBuild.Transaction);

			////

			Email newEmail = GetNode<Email>(Context.SharpflakeIds[0]);
			Assert.NotNull(newEmail, "New Email was not created.");

			NodeConnections conn = GetNodeConnections(newEmail);
			conn.AssertRelCount(1, 0);
			conn.AssertRel<RootContainsEmail, Root>(false, 0);

			NewNodeCount = 1;
			NewRelCount = 1;
		}

	}

}