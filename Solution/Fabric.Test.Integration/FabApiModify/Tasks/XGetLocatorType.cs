using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using NUnit.Framework;
using Fabric.Db.Data;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetLocatorType : XModifyTasks {

		private long vLocatorTypeId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private LocatorType TestGo() {
			return Tasks.GetLocatorType(ApiCtx, vLocatorTypeId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(LocatorTypeId.EarthCoord)]
		[TestCase(LocatorTypeId.RelPos2D)]
		public void Found(LocatorTypeId pLocatorTypeId) {
			vLocatorTypeId = (long)pLocatorTypeId;

			LocatorType result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vLocatorTypeId, result.LocatorTypeId, "Incorrect LocatorTypeId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(999)]
		public void NotFound(long pLocatorTypeId) {
			vLocatorTypeId = pLocatorTypeId;

			LocatorType result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}