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
		[TestCase(EventorTypeId.Occur, 2013, 9, 15, 17, 10, 56)]
		[TestCase(EventorTypeId.End, 2013, 9, 15, null, null, null)]
		[TestCase(EventorTypeId.Start, -5000, null, null, null, null, null)]
		public void Success(EventorTypeId pEveTypeId, long pYear, byte? pMonth, byte? pDay,
															byte? pHour, byte? pMinute, byte? pSecond) {
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.UpdateFactorEventor(ApiCtx, f, (byte)pEveTypeId,
				pYear, pMonth, pDay, pHour, pMinute, pSecond);

			Factor fac = GetVertex<Factor>(f.FactorId);
			Assert.NotNull(fac, "Updated Factor was deleted.");
			Assert.AreEqual((byte)pEveTypeId, fac.Eventor_TypeId, "Incorrect Eventor_TypeId.");
		}

	}

}