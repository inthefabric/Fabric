using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddIdentor : XModifyTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(IdentorTypeId.Key, "this is my value")]
		public void Success(IdentorTypeId pEveTypeId, string pValue) {
			IWeaverVarAlias<Identor> elemVar;
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.TxAddIdentor(ApiCtx, TxBuild, (long)pEveTypeId, pValue, f, out elemVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddIdentor", TxBuild.Transaction);

			Identor newIdentor = GetNode<Identor>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newIdentor, "New Identor was not created.");

			NodeConnections conn = GetNodeConnections(newIdentor);
			conn.AssertRelCount(2, 1);
			conn.AssertRel<RootContainsIdentor, Root>(false, 0);
			conn.AssertRel<FactorUsesIdentor, Factor>(false, f.FactorId);
			conn.AssertRel<IdentorUsesIdentorType, IdentorType>(true, (long)pEveTypeId);

			NewNodeCount = 1;
			NewRelCount = 3;
		}

	}

}