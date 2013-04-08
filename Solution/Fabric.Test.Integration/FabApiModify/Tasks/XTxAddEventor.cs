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
	public class XTxAddEventor : XModifyTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(EventorTypeId.Start, EventorPrecisionId.Minute, 1298529385923859238)]
		public void Success(EventorTypeId pEveTypeId, EventorPrecisionId pEvePrecId, long pDateTime) {
			IWeaverVarAlias<Eventor> elemVar;
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.TxAddEventor(ApiCtx, TxBuild, 
				(long)pEveTypeId, (long)pEvePrecId, pDateTime, f, out elemVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddEventor", TxBuild.Transaction);

			Eventor newEventor = GetNode<Eventor>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newEventor, "New Eventor was not created.");
			Assert.AreNotEqual(0, newEventor.EventorId, "Incorrect EventorId.");
			Assert.AreEqual(pDateTime, newEventor.DateTime, "Incorrect DateTime.");

			NodeConnections conn = GetNodeConnections(newEventor);
			conn.AssertRelCount(1, 2);
			conn.AssertRel<FactorUsesEventor, Factor>(false, f.FactorId);
			conn.AssertRel<EventorUsesEventorType, EventorType>(true, (long)pEveTypeId);
			conn.AssertRel<EventorUsesEventorPrecision, EventorPrecision>(true, (long)pEvePrecId);

			NewNodeCount = 1;
			NewRelCount = 3;
		}

	}

}