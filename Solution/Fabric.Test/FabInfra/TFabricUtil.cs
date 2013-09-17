using Fabric.Infrastructure;
using NUnit.Framework;

namespace Fabric.Test.FabInfra {

	/*================================================================================================*/
	[TestFixture]
	public class TFabricUtil {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1, null, null, null, null, null)]
		[TestCase(9999999, null, null, null, null, null)]
		[TestCase(-9999999, null, null, null, null, null)]
		[TestCase(1, (byte)0, (byte)0, (byte)0, (byte)0, (byte)0)]
		[TestCase(1, (byte)1, (byte)1, (byte)1, (byte)1, (byte)1)]
		[TestCase(2010, (byte)10, null, null, null, null)]
		[TestCase(1985, (byte)8,  (byte)27, null, null, null)]
		[TestCase(2010, (byte)10, (byte)10, (byte)10, null, null)]
		[TestCase(1234, (byte)5,  (byte)6,  (byte)7,  (byte)8, null)]
		[TestCase(2013, (byte)9,  (byte)17, (byte)17, (byte)5, (byte)34)]
		public void EventorTimeConversion(long pYear, byte? pMonth, byte? pDay, byte? pHour,
																		byte? pMinute, byte? pSecond) {
			long y;
			byte? mo, d, h, mi, s;
			long dt = FabricUtil.EventorTimesToLong(pYear, pMonth, pDay, pHour, pMinute, pSecond);
			FabricUtil.EventorLongToTimes(dt, out y, out mo, out d, out h, out mi, out s);

			Assert.AreEqual(pYear, y, "Incorrect Year.");
			Assert.AreEqual(pMonth, mo, "Incorrect Month.");
			Assert.AreEqual(pDay, d, "Incorrect Day.");
			Assert.AreEqual(pHour, h, "Incorrect Hour.");
			Assert.AreEqual(pMinute, mi, "Incorrect Minute.");
			Assert.AreEqual(pSecond, pSecond, "Incorrect Second.");
		}

	}

}