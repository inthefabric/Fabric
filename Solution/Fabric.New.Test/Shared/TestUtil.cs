using System;
using System.Collections.Generic;
using Fabric.New.Infrastructure.Broadcast;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Shared {

	/*================================================================================================*/
	public static class TestUtil {

		//public const string TryPropScript =
		//	"_TRY.each{k,v->if((z=v.getProperty(k))){_PROP.put(k,z)}};";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static T Throws<T>(TestDelegate pFunc) where T : Exception {
			return CheckThrows<T>(true, pFunc);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static T CheckThrows<T>(bool pThrows, TestDelegate pFunc) where T : Exception {
			if ( pThrows ) {
				return (T)Assert.Throws(typeof(T), pFunc);
			}

			Assert.DoesNotThrow(pFunc);
			return null;
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
															string pParamBase, IList<object> pValues) {
			Assert.NotNull(pParams, "Query.Params should not be null.");
			Assert.AreEqual(pValues.Count, pParams.Keys.Count, "Incorrect Query.Params.Keys.Count.");

			for ( int i = 0 ; i < pValues.Count ; ++i ) {
				Assert.AreEqual(pValues[i], pParams[pParamBase+i].Original,
					"Incorrect value for Query.Params['"+pParamBase+i+"'].");
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
		public static string InsertParamIndexes(string pQuery, string pParamBase) {
			string[] parts = pQuery.Split(new[] { pParamBase }, 9999, StringSplitOptions.None);
			string q = "";

			for ( int i = 0 ; i < parts.Length ; ++i ) {
				q += (i == 0 ? "" : pParamBase+(i-1))+parts[i];
			}

			return q;
		}

	}

}