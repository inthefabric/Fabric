using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetEventorMatch : XModifyTasks {

		private long vEveTypeId;
		private long vEvePrecId;
		private long vDateTime;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Eventor TestGo() {
			return Tasks.GetEventorMatch(ApiCtx, vEveTypeId, vEvePrecId, vDateTime);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(EventorTypeId.Occur, EventorPrecisionId.Year, 631769760000000000, 
			SetupFactors.EventorId.Occur_Year_2003)]
		[TestCase(EventorTypeId.Start, EventorPrecisionId.Month, 630690624000000000, 
			SetupFactors.EventorId.Start_Month_1999_08)]
		public void Found(EventorTypeId pEveTypeId, EventorPrecisionId pEvePrecId, long pDateTime,
																SetupFactors.EventorId pExpectEveId) {	
			vEveTypeId = (long)pEveTypeId;
			vEvePrecId = (long)pEvePrecId;
			vDateTime = (long)pDateTime;

			Eventor result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((long)pExpectEveId, result.EventorId, "Incorrect EventorId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(EventorTypeId.Occur, EventorPrecisionId.Year, 631769760000000001)]
		[TestCase(EventorTypeId.Occur, EventorPrecisionId.Month, 631769760000000000)]
		[TestCase(EventorTypeId.Start, EventorPrecisionId.Year, 631769760000000000)]
		public void NotFound(EventorTypeId pEveTypeId, EventorPrecisionId pEvePrecId, long pDateTime) {	
			vEveTypeId = (long)pEveTypeId;
			vEvePrecId = (long)pEvePrecId;
			vDateTime = (long)pDateTime;

			Eventor result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}