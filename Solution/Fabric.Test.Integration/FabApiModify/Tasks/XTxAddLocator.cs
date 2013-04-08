using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddLocator : XModifyTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(LocatorTypeId.EarthCoord, 12.34567, 98.765432, 0.0)]
		public void Success(LocatorTypeId pEveTypeId, double pValueX, double pValueY, double pValueZ) {
			IWeaverVarAlias<Locator> elemVar;
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.TxAddLocator(ApiCtx, TxBuild,
				(long)pEveTypeId, pValueX, pValueY, pValueZ, f, out elemVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddLocator", TxBuild.Transaction);

			Locator newLocator = GetNode<Locator>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newLocator, "New Locator was not created.");
			Assert.AreNotEqual(0, newLocator.LocatorId, "Incorrect LocatorId.");
			Assert.AreEqual(pValueX, newLocator.ValueX, "Incorrect ValueX.");
			Assert.AreEqual(pValueY, newLocator.ValueY, "Incorrect ValueY.");
			Assert.AreEqual(pValueZ, newLocator.ValueZ, "Incorrect ValueZ.");

			NodeConnections conn = GetNodeConnections(newLocator);
			conn.AssertRelCount(1, 1);
			conn.AssertRel<FactorUsesLocator, Factor>(false, f.FactorId);
			conn.AssertRel<LocatorUsesLocatorType, LocatorType>(true, (long)pEveTypeId);

			NewNodeCount = 1;
			NewRelCount = 2;
		}

	}

}