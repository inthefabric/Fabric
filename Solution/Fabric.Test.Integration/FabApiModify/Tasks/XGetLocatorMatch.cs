using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetLocatorMatch : XModifyTasks {

		private long vLocTypeId;
		private double vValueX;
		private double vValueY;
		private double vValueZ;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Locator TestGo() {
			return Tasks.GetLocatorMatch(ApiCtx, vLocTypeId, vValueX, vValueY, vValueZ);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(LocatorTypeId.EarthCoord, -85.621265, 42.830739, 0, SetupFactors.LocatorId.Silverbow)]
		[TestCase(LocatorTypeId.RelPos2D, 0.5, 0.333, 0, SetupFactors.LocatorId.ElliePos2D)]
		public void Found(LocatorTypeId pLocTypeId, double pValueX, double pValueY, double pValueZ,
																SetupFactors.LocatorId pExpectLocId) {	
			vLocTypeId = (long)pLocTypeId;
			vValueX = pValueX;
			vValueY = pValueY;
			vValueZ = pValueZ;

			Locator result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((long)pExpectLocId, result.LocatorId, "Incorrect LocatorId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(LocatorTypeId.EarthCoord, -85.621264, 42.830739, 0)]
		[TestCase(LocatorTypeId.EarthCoord, -85.621265, 42.830738, 0)]
		[TestCase(LocatorTypeId.EarthCoord, -85.621265, 42.830739, 0.000001)]
		public void NotFound(LocatorTypeId pEveTypeId, double pValueX, double pValueY, double pValueZ){	
			vLocTypeId = (long)pEveTypeId;
			vValueX = pValueX;
			vValueY = pValueY;
			vValueZ = pValueZ;

			Locator result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}