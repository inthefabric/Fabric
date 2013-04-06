using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public class TestApiDataAccess : ApiDataAccess {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, string pScript,
													IDictionary<string, IWeaverQueryVal> pParams=null) :
													base(pContext, pScript, pParams) { }

		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, IWeaverScript pScripted) :
												this(pContext, pScripted.Script, pScripted.Params) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override string GetRawResult(string pQuery) {
			long t = DateTime.UtcNow.Ticks;
			string json = base.GetRawResult(CleanQueryIndexIds(this));
			Log.Info("Query: "+(DateTime.UtcNow.Ticks-t)/10000+"ms");
			Log.Info("");
			return json;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string CleanQueryIndexIds(IApiDataAccess pData) {
			//The loadGraphSON() Gremlin function quickly loads test database's initial state. However,
			//the actual data type of the ID values (long) is lost in this proces. For testing purposes,
			//the following will cast the parameterized values accordingly.

			//TODO: TestApiDataAccess: update the parameter casting to account for the _intended_
			//data type when creating nodes (vs. the _given_ type when reloading from GraphSON)

			string newScript = pData.Script+""; 
			string param = BuildParams(pData.Params);

			MatchCollection matches = Regex.Matches(newScript, @"_(P|TP)([0-9]+)");

			for ( int i = matches.Count-1 ; i >= 0 ; --i ) {
				Match m = matches[i];
				IWeaverQueryVal qv = pData.Params[m.Value];
				string castFunc = GetCastFunc(qv.Original);
				string val = (qv.Original == null ? "(String)"+m.Value : m.Value+castFunc);
				newScript = newScript.Remove(m.Index, m.Length).Insert(m.Index, val);
			}

			string query = newScript+(param.Length > 0 ? "#{"+param+"}" : "");
			//Log.Debug("TEST: "+query);
			return query;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetCastFunc(object pObj) {
			if ( pObj == null ) {
				return "";
			}

			switch ( pObj.GetType().Name ) {
				case "Int32":
					return ".toInteger()";

				case "Int64":
					long l = (long)pObj;
					return (l > int.MaxValue || l < int.MinValue ? ".toLong()" : ".toInteger()");

				case "Single":
					float f = (float)pObj;
					return ((f%1) == 0 ? ".toInteger()" : ".toFloat()");

				case "Double":
					double d = (double)pObj;
					return ((d%1) == 0 ? ".toInteger()" : ".toDouble()");
			}

			return "";

		}

	}

}