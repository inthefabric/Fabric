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
		public static void LogQuery(IWeaverQuery pQuery) {
			string p = "";

			foreach ( string key in pQuery.Params.Keys ) {
				p += (p == "" ? " [ " : ", ")+key+"="+pQuery.Params[key];
			}

			if ( p != "" ) { p += " ]"; }
			Log.Debug("Query: "+pQuery.Script+p);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static void LogTransaction(IWeaverTransaction pTx) {
			string p = "";
			
			foreach ( string key in pTx.Params.Keys ) {
				p += (p == "" ? " [ " : ", ")+key+"="+pTx.Params[key];
			}
			
			if ( p != "" ) { p += " ]"; }
			Log.Debug("Query: "+pTx.Script.Replace(";", ";\n")+p);
		}

	}

}