using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XUpdateFactorEventor : XModifyTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(EventorTypeId.Start, EventorPrecisionId.Minute, 1298529385923859238)]
		[TestCase(EventorTypeId.Start, EventorPrecisionId.Minute, long.MaxValue)]
		[TestCase(EventorTypeId.Start, EventorPrecisionId.Minute, long.MinValue)]
		public void Success(EventorTypeId pEveTypeId, EventorPrecisionId pEvePrecId, long pDateTime) {
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.UpdateFactorEventor(ApiCtx, f, (byte)pEveTypeId, (byte)pEvePrecId, pDateTime);

			Factor fac = GetVertex<Factor>(f.FactorId);
			Assert.NotNull(fac, "Updated Factor was deleted.");
			Assert.AreEqual((byte)pEveTypeId, fac.Eventor_TypeId, "Incorrect Eventor_TypeId.");
		}

	}

}