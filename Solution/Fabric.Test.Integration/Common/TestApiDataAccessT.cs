using System.Collections.Generic;
using System.Diagnostics;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public class TestApiDataAccess<T> : ApiDataAccess<T> where T : IElementWithId, new() {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, string pScript, 
												IDictionary<string, IWeaverQueryVal> pParams=null) : 
												base(pContext, pScript, pParams) {}

		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, IWeaverScript pScripted) :
												this(pContext, pScripted.Script, pScripted.Params) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Execute() {
			var sw = new Stopwatch();
			sw.Start();

			base.Execute();
			//pReqJson = ((TestApiContext)ApiCtx).AlterRequestJson(pReqJson);
			//string json = base.GetRawResult(pReqJson);

			Log.Info("Query<"+typeof(T).Name+">: "+sw.ElapsedMilliseconds+"ms");
			Log.Info("");
		}

	}

}