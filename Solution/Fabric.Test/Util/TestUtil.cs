using System;
using NUnit.Framework;
using Weaver.Interfaces;
using Fabric.Infrastructure;
using System.Collections.Generic;

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

		/*--------------------------------------------------------------------------------------------*/
		public static void CheckParam(IDictionary<string,string> pParams, string pKey, string pValue) {
			Assert.NotNull(pParams, "Query.Params should not be null.");
			Assert.True(pParams.ContainsKey(pKey), "Query.Params['"+pKey+"'] should be filled.");
			Assert.AreEqual(pValue, pParams[pKey], "Incorrect Query.Params['"+pKey+"'].");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static void LogWeaverScript(IWeaverScript pScripted) {
			string p = "";

			foreach ( string key in pScripted.Params.Keys ) {
				p += (p == "" ? " [ " : ", ")+key+"="+pScripted.Params[key];
			}

			if ( p != "" ) { p += " ]"; }
			Log.Debug("Query: "+pScripted.Script.Replace(";", ";\n")+p);
		}

	}

}