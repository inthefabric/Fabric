﻿using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
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

			NodeConnections conn = GetNodeConnections(newEventor);
			conn.AssertRelCount(2, 2);
			conn.AssertRel<RootContainsEventor, Root>(false, 0);
			conn.AssertRel<FactorUsesEventor, Factor>(false, f.FactorId);
			conn.AssertRel<EventorUsesEventorType, EventorType>(true, (long)pEveTypeId);
			conn.AssertRel<EventorUsesEventorPrecision, EventorPrecision>(true, (long)pEvePrecId);

			NewNodeCount = 1;
			NewRelCount = 4;
		}

	}

}