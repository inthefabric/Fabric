using Fabric.Api.Modify;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TAttachEventor : TAttachFactorElement {

		private byte vEveTypeId;
		private long vYear;
		private byte? vMonth;
		private byte? vDay;
		private byte? vHour;
		private byte? vMinute;
		private byte? vSecond;

		private bool vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vEveTypeId = 9;
			vYear = 2013;
			vMonth = 9;
			vDay = 16;
			vHour = 17;
			vMinute = 10;
			vSecond = 56;

			MockTasks
				.Setup(x => x.UpdateFactorEventor(
					MockApiCtx.Object,
					ActiveFactor,
					vEveTypeId,
					vYear,
					vMonth,
					vDay,
					vHour,
					vMinute,
					vSecond
				));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new AttachEventor(MockTasks.Object, FactorId, vEveTypeId, 
				vYear, vMonth, vDay, vHour, vMinute, vSecond);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewEventor() {
			TestGo();
			Assert.True(vResult, "Incorrect Result.");
			CheckValidation();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckValidation() {
			base.CheckValidation();

			MockValidator.Verify(x => x.FactorEventor_TypeId(vEveTypeId,
				AttachEventor.EveTypeParam), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		public void YearErrInvalid(long pYear) {
			vYear = pYear;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-100000000001)]
		[TestCase( 100000000001)]
		public void YearErrRange(long pYear) {
			vYear = pYear;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(13)]
		public void MonthErrRange(byte pMonth) {
			vMonth = pMonth;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(32)]
		public void DayErrRange(byte pDay) {
			vDay = pDay;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(25)]
		public void HourErrRange(byte pHour) {
			vHour = pHour;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(60)]
		public void MinuteErrRange(byte pMinute) {
			vMinute = pMinute;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(60)]
		public void SecondErrRange(byte pSecond) {
			vSecond = pSecond;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

	}

}