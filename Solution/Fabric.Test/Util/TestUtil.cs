using System;
using NUnit.Framework;

namespace Fabric.Test.Util {

	/*================================================================================================*/
	public static class TestUtil {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Exception CheckThrows<TEx>(bool pThrows, TestDelegate pFunc) where TEx :Exception{
			if ( pThrows ) {
				return Assert.Throws(typeof(TEx), pFunc);
			}

			Assert.DoesNotThrow(pFunc);
			return null;
		}

	}

}