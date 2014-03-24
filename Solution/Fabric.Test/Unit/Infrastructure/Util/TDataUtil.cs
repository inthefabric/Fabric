using System.Collections.Generic;
using System.Text.RegularExpressions;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Util;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Infrastructure.Util {

	/*================================================================================================*/
	[TestFixture]
	public class TDataUtil {

		private static readonly Logger Log = Logger.Build<TDataUtil>();

		public const string AlphaNum32Pattern = @"[a-zA-Z0-9]{32}";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("nothing", "nothing")]
		[TestCase("\"quoted\"", "\\\"quoted\\\"")]
		[TestCase("mid\"dle", "mid\\\"dle")]
		public void JsonUnquote(string pText, string pResult) {
			Assert.AreEqual(pResult, DataUtil.JsonUnquote(pText), "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Code32() {
			var map = new HashSet<string>();

			for ( int i = 0 ; i < 1000 ; ++i ) {
				string code = DataUtil.Code32;

				Assert.NotNull(code, "Code should be filled.");
				Assert.AreEqual(32, code.Length, "Incorrect Code length.");
				Assert.False(map.Contains(code), "Code must be unique.");
				Assert.True(Regex.IsMatch(code, AlphaNum32Pattern), "Incorrect code format.");

				map.Add(code);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test")]
		[TestCase("password")]
		[TestCase("#abc-123.XYZ!")]
		public void HashPassword(string pPass) {
			string hash = DataUtil.HashPassword(pPass);
			string hash2 = DataUtil.HashPassword(pPass);

			Assert.NotNull(hash, "Result should be filled.");
			Assert.AreEqual(32, hash.Length, "Incorrect result length.");
			Assert.True(Regex.IsMatch(hash, AlphaNum32Pattern), "Incorrect result format.");
			Assert.AreEqual(hash, hash2, "Incorrect result mismatch.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1, null, null, null, null, null)]
		[TestCase(9999999, null, null, null, null, null)]
		[TestCase(-9999999, null, null, null, null, null)]
		[TestCase(1, (byte)1, (byte)1, (byte)0, (byte)0, (byte)0)]
		[TestCase(1, (byte)1, (byte)1, (byte)1, (byte)1, (byte)1)]
		[TestCase(2010, (byte)10, null, null, null, null)]
		[TestCase(1985, (byte)8,  (byte)27, null, null, null)]
		[TestCase(2010, (byte)10, (byte)10, (byte)10, null, null)]
		[TestCase(1234, (byte)5,  (byte)6,  (byte)7,  (byte)8, null)]
		[TestCase(2013, (byte)9, (byte)17, (byte)17, (byte)5, (byte)34)]
		[TestCase(2007, (byte)12, (byte)1, null, null, null)]
		[TestCase(9999, (byte)12, (byte)31, (byte)23, (byte)59, (byte)59)]
		public void EventorTimeConversion(long pYear, byte? pMonth, byte? pDay, byte? pHour,
																		byte? pMinute, byte? pSecond) {
			long y;
			byte? mo, d, h, mi, s;
			long dt = DataUtil.EventorTimesToLong(pYear, pMonth, pDay, pHour, pMinute, pSecond);
			DataUtil.EventorLongToTimes(dt, out y, out mo, out d, out h, out mi, out s);

			Assert.AreEqual(pYear, y, "Incorrect Year.");
			Assert.AreEqual(pMonth, mo, "Incorrect Month.");
			Assert.AreEqual(pDay, d, "Incorrect Day.");
			Assert.AreEqual(pHour, h, "Incorrect Hour.");
			Assert.AreEqual(pMinute, mi, "Incorrect Minute.");
			Assert.AreEqual(pSecond, pSecond, "Incorrect Second.");
		}

	}

}