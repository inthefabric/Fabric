using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Data;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;
using Weaver.Core.Query;
using Weaver.Exec.RexConnect;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiDataAccess : IApiDataAccess {

		public IApiContext ApiCtx { get; private set; }
		public WeaverRequest Request { get; private set; }
		public IResponseResult Result { get; private set; }
		//public IList<IDbDto> ResultDtoList { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, string pScript, 
													IDictionary<string, IWeaverQueryVal> pParams=null) {
			ApiCtx = pContext;
			
			Request = new WeaverRequest(pContext.ContextId.ToString());
			Request.AddQuery(pScript, pParams);
		}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, IWeaverScript pScripted) :
												this(pContext, pScripted.Script, pScripted.Params) {}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, IEnumerable<IWeaverScript> pScriptedList) {
			ApiCtx = pContext;

			Request = new WeaverRequest(pContext.ContextId.ToString());
			Request.AddQueries(pScriptedList, true);
		}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, WeaverRequest pRequest) {
			ApiCtx = pContext;
			Request = pRequest;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Execute() {
			var ctx = new RexConnContext(Request, ApiCtx.RexConnUrl, ApiCtx.RexConnPort);
			var data = new RexConnDataAccess(ctx);
			Result = data.Execute();
			LogAction();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public int GetResultCount() {
			return Result.Response.CmdList[0].Results.Count;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T GetResultAt<T>(int pIndex) where T : IElementWithId, new() {
			return DataDto.ToElement<T>(Result.GetGraphElementsAt(0)[pIndex]);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public int GetTextListCount() {
			return Result.GetTextResultsAt(0).Values.Count;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetStringResultAt(int pIndex) {
			return Result.GetTextResultsAt(0).ToString(pIndex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public int GetIntResultAt(int pIndex) {
			return Result.GetTextResultsAt(0).ToInt(pIndex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public long GetLongResultAt(int pIndex) {
			return Result.GetTextResultsAt(0).ToLong(pIndex);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void LogAction() {
			//DBv1: 
			//	TotalMs, QueryMs, Timestamp, QueryChars

			const string name = "DBv1";
			const string x = " | ";

			string v1 =
				Result.ExecutionMilliseconds +x+
				Result.Response.Timer +x+
				DateTime.UtcNow.Ticks +x+
				Result.RequestJson.Length;

			Log.Info(ApiCtx.ContextId, name, v1);
		}

	}

}