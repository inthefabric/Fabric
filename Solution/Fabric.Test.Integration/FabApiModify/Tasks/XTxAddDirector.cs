using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddDirector : XModifyTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(DirectorTypeId.DefinedPath, DirectorActionId.Read, DirectorActionId.Listen)]
		public void Success(DirectorTypeId pDirTypeId, DirectorActionId pPrimActId,
																		DirectorActionId pRelActId) {
			IWeaverVarAlias<Director> elemVar;
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.TxAddDirector(ApiCtx, TxBuild, 
				(long)pDirTypeId, (long)pPrimActId, (long)pRelActId, f, out elemVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddDirector", TxBuild.Transaction);

			Director newDirector = GetNode<Director>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newDirector, "New Director was not created.");
			Assert.AreNotEqual(0, newDirector.DirectorId, "Incorrect DirectorId.");

			NodeConnections conn = GetNodeConnections(newDirector);
			conn.AssertRelCount(2, 3);
			conn.AssertRel<RootContainsDirector, Root>(false, 0);
			conn.AssertRel<FactorUsesDirector, Factor>(false, f.FactorId);
			conn.AssertRel<DirectorUsesDirectorType, DirectorType>(true, (long)pDirTypeId);
			conn.AssertRel<DirectorUsesPrimaryDirectorAction, DirectorAction>(true, (long)pPrimActId);
			conn.AssertRel<DirectorUsesRelatedDirectorAction, DirectorAction>(true, (long)pRelActId);

			NewNodeCount = 1;
			NewRelCount = 5;
		}

	}

}