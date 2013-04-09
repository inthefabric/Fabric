using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XAttachEventor : XCreateFactorElement {

		private byte vEveTypeId;
		private byte vEvePrecId;
		private long vDateTime;
		
		private bool vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vEveTypeId = (byte)EventorTypeId.Continue;
			vEvePrecId = (byte)EventorPrecisionId.Second;
			vDateTime = 925923592753292;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected  override void TestGo() {
			var func = new AttachEventor(Tasks, FactorId, vEveTypeId, vEvePrecId, vDateTime);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewEventor() {
			IsReadOnlyTest = false;

			TestGo();

			Assert.True(vResult, "Incorrect Result.");

			Factor updatedFactor = GetNode<Factor>(FactorId);
			Assert.NotNull(updatedFactor, "Updated Factor was deleted.");
			Assert.AreEqual(vEveTypeId, updatedFactor.Eventor_TypeId, "Incorrect Eventor_TypeId.");
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(1)]
		public void ErrEventorTypeRange(byte pId) {
			vEveTypeId = pId;

			if ( pId == 1 ) {
				vEveTypeId = (byte)(StaticTypes.EventorTypes.Keys.Count+1);
			}

			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(1)]
		public void ErrEventorPrecisionRange(byte pId) {
			vEvePrecId = pId;

			if ( pId == 1 ) {
				vEvePrecId = (byte)(StaticTypes.EventorPrecisions.Keys.Count+1);
			}

			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public void ErrEventorDateTimeRange(long pDateTime) {
			vDateTime = pDateTime;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

	}

}