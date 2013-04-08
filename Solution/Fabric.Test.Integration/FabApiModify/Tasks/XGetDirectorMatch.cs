using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetDirectorMatch : XModifyTasks {

		private long vDirTypeId;
		private long vPrimActId;
		private long vRelActId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Director TestGo() {
			return Tasks.GetDirectorMatch(ApiCtx, vDirTypeId, vPrimActId, vRelActId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(DirectorTypeId.SuggestPath, DirectorActionId.View, DirectorActionId.View, 
			SetupFactors.DirectorId.View_Sugg_View)]
		[TestCase(DirectorTypeId.SuggestPath, DirectorActionId.View, DirectorActionId.Learn, 
			SetupFactors.DirectorId.View_Sugg_Learn)]
		public void Found(DirectorTypeId pDescTypeId, DirectorActionId pPrimActId,
									DirectorActionId pRelActId, SetupFactors.DirectorId pExpectDirId) {	
			vDirTypeId = (long)pDescTypeId;
			vPrimActId = (long)pPrimActId;
			vRelActId = (long)pRelActId;

			Director result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((long)pExpectDirId, result.DirectorId, "Incorrect DirectorId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(DirectorTypeId.SuggestPath, DirectorActionId.View, DirectorActionId.Explain)]
		[TestCase(DirectorTypeId.SuggestPath, DirectorActionId.Consume, DirectorActionId.Learn)]
		[TestCase(DirectorTypeId.DefinedPath, DirectorActionId.View, DirectorActionId.Learn)]
		public void NotFound(DirectorTypeId pDescTypeId, DirectorActionId pPrimActId,
																		DirectorActionId pRelActId) {
			vDirTypeId = (long)pDescTypeId;
			vPrimActId = (long)pPrimActId;
			vRelActId = (long)pRelActId;

			Director result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}