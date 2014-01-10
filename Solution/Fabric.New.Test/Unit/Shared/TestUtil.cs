using System;
using System.Collections.Generic;
using Fabric.New.Infrastructure.Broadcast;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Shared {

	/*================================================================================================*/
	public static class TestUtil {

		private static readonly Logger Log = Logger.Build(typeof(TestUtil));


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static T Throws<T>(TestDelegate pFunc) where T : Exception {
			return CheckThrows<T>(true, pFunc);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static T CheckThrows<T>(bool pThrows, TestDelegate pFunc) where T : Exception {
			if ( pThrows ) {
				T ex = (T)Assert.Throws(typeof(T), pFunc);
				Log.Debug("CheckThrows Exception: "+ex.Message);
				return ex;
			}

			Assert.DoesNotThrow(pFunc);
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void CheckWeaverScript(IWeaverScript pWeaverScript, string pExpectScript,
														string pParamPrefix, IList<object> pValues) {
			LogWeaverScript(Log, pWeaverScript);
			pExpectScript = InsertParamIndexes(pExpectScript, pParamPrefix);
			Assert.AreEqual(pExpectScript, pWeaverScript.Script, "Incorrect Query.Script.");
			CheckParams(pWeaverScript.Params, pParamPrefix, pValues);
		}

		/*--------------------------------------------------------------------------------------------* /
		public static void CheckParam(IDictionary<string, IWeaverQueryVal> pParams,
																	string pKey, object pOrigValue) {
			Assert.NotNull(pParams, "Query.Params should not be null.");
			Assert.True(pParams.ContainsKey(pKey), "Query.Params['"+pKey+"'] should be filled.");
			Assert.AreEqual(pOrigValue, pParams[pKey].Original,
				"Incorrect Query.Params['"+pKey+"'].Original.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void CheckParams(IDictionary<string, IWeaverQueryVal> pParams,
														string pParamPrefix, IList<object> pValues) {
			Assert.NotNull(pParams, "Query.Params should not be null.");
			Assert.AreEqual(pValues.Count, pParams.Keys.Count, "Incorrect Query.Params.Keys.Count.");

			for ( int i = 0 ; i < pValues.Count ; ++i ) {
				Assert.AreEqual(pValues[i], pParams[pParamPrefix+i].Original,
					"Incorrect value for Query.Params['"+pParamPrefix+i+"'].");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void AssertContains(string pName, string pString, string pContains) {
			if ( string.IsNullOrWhiteSpace(pString) || pString.IndexOf(pContains) == -1 ) {
				Assert.Fail(pName+" does not contain '"+pContains+"'. Full string:\n"+pString);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public static IWeaverVarAlias<T> GetTxVar<T>(string pName) where T : IVertex {
			var tv = new Mock<IWeaverVarAlias<T>>();
			tv.SetupGet(x => x.Name).Returns(pName);
			tv.SetupGet(x => x.VarType).Returns(typeof(T));
			return tv.Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void LogWeaverScript(Logger pLog, IWeaverScript pScripted) {
			string p = "";

			foreach ( string key in pScripted.Params.Keys ) {
				p += "\n\t"+key+" = "+pScripted.Params[key].FixedText;
			}

			LogWeaverScript(pLog, pScripted.Script, p);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void LogWeaverScript(Logger pLog, string pScript, string pParamOutput) {
			string script = pScript
				.Replace(".outE", "\n\t\t.outE")
				.Replace(".inE", "\n\t\t.inE")
				.Replace(".back", "\n\t\t.back")
				.Replace(";", ";\n\t");

			pLog.Debug("Query:\n\n\t"+script+pParamOutput);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public static NameValueCollection BuildQuery(string pQuery) {
			var q = new NameValueCollection();
			if ( String.IsNullOrEmpty(pQuery) ) { return q; }

			string[] pairs = pQuery.Split('&');

			foreach ( string pair in pairs ) {
				string[] nameVal = pair.Split('=');
				q.Add(nameVal[0], nameVal[1]);
			}

			return q;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string InsertParamIndexes(string pScript, string pParamPrefix) {
			string[] parts = pScript.Split(new[] { pParamPrefix }, 9999, StringSplitOptions.None);
			string q = "";

			for ( int i = 0 ; i < parts.Length ; ++i ) {
				q += (i == 0 ? "" : pParamPrefix+(i-1))+parts[i];
			}

			return q;
		}

	}

}