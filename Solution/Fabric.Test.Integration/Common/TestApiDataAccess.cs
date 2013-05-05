using System;
using System.Collections.Generic;
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
												base(pContext, pScript, pParams) {}

		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, IWeaverScript pScripted) :
												this(pContext, pScripted.Script, pScripted.Params) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, IList<IWeaverScript> pScriptedList) :
																		base(pContext, pScriptedList) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override string GetRawResult(string pReqJson) {
			long t = DateTime.UtcNow.Ticks;
			pReqJson = ((TestApiContext)ApiCtx).AlterRequestJson(pReqJson);
			string json = base.GetRawResult(pReqJson);
			Log.Info("Query: "+(DateTime.UtcNow.Ticks-t)/10000+"ms");
			Log.Info("");
			return json;
		}

	}

}