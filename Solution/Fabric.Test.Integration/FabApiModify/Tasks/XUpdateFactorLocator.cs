using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XUpdateFactorLocator : XModifyTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(LocatorTypeId.EarthCoord, 12.34567, 98.765432, 0.0)]
		public void Success(LocatorTypeId pLocTypeId, double pValueX, double pValueY, double pValueZ) {
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.UpdateFactorLocator(ApiCtx, f, (byte)pLocTypeId, pValueX, pValueY, pValueZ);

			Factor fac = GetNode<Factor>(f.FactorId);
			Assert.NotNull(fac, "Updated Factor was deleted.");
			Assert.AreEqual((byte)pLocTypeId, fac.Locator_TypeId, "Incorrect Locator_TypeId.");
		}

	}

}