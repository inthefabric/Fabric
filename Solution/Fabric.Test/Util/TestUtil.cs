using System;
using NUnit.Framework;

namespace Fabric.Test.Util {

	/*================================================================================================*/
	public static class TestUtil {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static TEx CheckThrows<TEx>(bool pThrows, TestDelegate pFunc) where TEx : Exception {
			if ( pThrows ) {
				return (TEx)Assert.Throws(typeof(TEx), pFunc);
			}

			Assert.DoesNotThrow(pFunc);
			return null;
		}

	}

}