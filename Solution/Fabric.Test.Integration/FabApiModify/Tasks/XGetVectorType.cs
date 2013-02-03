using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;
using Fabric.Db.Data;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetVectorType : XModifyTasks {

		private long vVectorTypeId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private VectorType TestGo() {
			return Tasks.GetVectorType(ApiCtx, vVectorTypeId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(VectorTypeId.FullLong)]
		[TestCase(VectorTypeId.StdFavor)]
		public void Found(VectorTypeId pVectorTypeId) {
			vVectorTypeId = (long)pVectorTypeId;

			VectorType result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vVectorTypeId, result.VectorTypeId, "Incorrect VectorTypeId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(999)]
		public void NotFound(long pVectorTypeId) {
			vVectorTypeId = pVectorTypeId;

			VectorType result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}