using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using ServiceStack.Text;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiDataAccess : IApiDataAccess {

		public IApiContext ApiCtx { get; private set; }

		public string Script { get; private set; }
		public IDictionary<string, string> Params { get; private set; }
		public string Query { get; private set; }

		public string ResultString { get; private set; }
		public IDbResult Result { get; private set; }
		public IList<IDbDto> ResultDtoList { get; private set; }

		private Exception vUnhandledException;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, string pScript, 
															IDictionary<string, string> pParams=null) {
			ApiCtx = pContext;
			Script = pScript;
			Params = pParams;

			string script = FabricUtil.JsonUnquote(Script);
			string param = BuildParams();
			
			Query = "{\"script\":\""+script+"\""+
				(param.Length > 0 ? ",\"params\":{"+param+"}" : "")+"}";
		}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, IWeaverScript pScripted) :
												this(pContext, pScripted.Script, pScripted.Params) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Execute() {
			long t = DateTime.UtcNow.Ticks;

			try {
				ResultString = GetResultString(Query);
				Result = JsonSerializer.DeserializeFromString<DbResult>(ResultString);
				Result.BuildDbDtos(ResultString);
			}
			catch ( WebException we ) {
				vUnhandledException = we;
				Stream s = (we.Response == null ? null : we.Response.GetResponseStream());

				if ( s == null ) {
					throw;
				}

				var sr = new StreamReader(s);
				
				Result = new DbResult();
				Result.Exception = we+"";
				Result.Message = sr.ReadToEnd();
				Log.Error(ApiCtx.ContextId, "Grem", Result.Message);
			}
			catch ( Exception e ) {
				vUnhandledException = e;

				Result = new DbResult();
				Result.Exception = e+"";
				Result.Message = "Unhandled exception.";
			}

			if ( Result.Exception != null ) {
				vUnhandledException = new Exception(ResultString);
			}

			Result.ServerTime = DateTime.UtcNow.Ticks-t;
			//Log.Debug("RESULT: "+ResultString);
			LogAction();

			if ( vUnhandledException != null ) {
				throw vUnhandledException;
			}

			if ( Result.DbDtos != null ) {
				ResultDtoList = new List<IDbDto>(Result.DbDtos);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual string GetResultString(string pQuery) {
			using ( var wc = new WebClient() ) {
				wc.Headers.Add("Content-Type", "application/json");
				return wc.UploadString(ApiCtx.GremlinUrl, pQuery);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string BuildParams() {
			if ( Params == null ) { return ""; }
			string p = "";

			foreach ( string key in Params.Keys ) {
				p += (p.Length > 0 ? "," : "")+
					"\""+FabricUtil.JsonUnquote(key)+"\":"+
					"\""+FabricUtil.JsonUnquote(Params[key])+"\"";
			}

			return p;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public int GetResultCount() {
			return (ResultDtoList == null ? -1 : ResultDtoList.Count);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T GetResultAt<T>(int pIndex) where T : IItemWithId, new() {
			return ResultDtoList[pIndex].ToItem<T>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void LogAction() {
			//DBv1: 
			//	TotalMs, QueryMs, Timestamp, Query

			const string name = "DBv1";
			const string x = " | ";
			
			string v1 =
				Result.ServerTime +x+
				Result.QueryTime +x+
				DateTime.UtcNow.Ticks +x+
				Query;

			if ( vUnhandledException == null ) {
				Log.Info(ApiCtx.ContextId, name, v1);
			}
			else {
				Log.Error(ApiCtx.ContextId, name, v1, vUnhandledException);
			}
		}

	}

}