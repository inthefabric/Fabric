﻿using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public class TestApiDataAccess<T> : ApiDataAccess<T> where T : IItemWithId, new() {
		

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
			string json = base.GetRawResult(TestApiDataAccess.CleanQueryIndexIds(pQuery));
			Log.Info("Query<"+typeof(T).Name+">: "+(DateTime.UtcNow.Ticks-t)/10000+"ms");
			Log.Info("");
			return json;
		}

	}

}