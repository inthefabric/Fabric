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
						IDictionary<string, string> pParams=null) : base(pContext, pScript, pParams) {}

		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, IWeaverScript pScripted) :
												this(pContext, pScripted.Script, pScripted.Params) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override string GetRawResult(string pQuery) {
			long t = DateTime.UtcNow.Ticks;
			string json = base.GetRawResult(CleanQueryIndexIds(pQuery));
			Log.Info("Query: "+(DateTime.UtcNow.Ticks-t)/10000+"ms");
			Log.Info("");
			return json;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string CleanQueryIndexIds(string pQuery) {
			//The loadGraphSON() Gremlin function quickly loads test database's initial state. However,
			//the actual data type of the ID values (long) is lost in this proces. For testing purposes,
			//the following will trim the "L" from all indexes.

			string q = Regex.Replace(pQuery, @",([0-9]+)L\)", ",$1)");
			//Log.Debug("TEST: "+q);
			return q;
		}

	}

}