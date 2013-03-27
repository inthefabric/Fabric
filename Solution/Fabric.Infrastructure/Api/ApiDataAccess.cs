using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using ServiceStack.Text;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiDataAccess : IApiDataAccess {

		public IApiContext ApiCtx { get; private set; }

		public string Script { get; private set; }
		public IDictionary<string, IWeaverQueryVal> Params { get; private set; }
		public string Query { get; private set; }

		public string RawResult { get; private set; }
		public IDbResult Result { get; private set; }
		public IList<IDbDto> ResultDtoList { get; private set; }

		private Exception vUnhandledException;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, string pScript, 
													IDictionary<string, IWeaverQueryVal> pParams=null) {
			ApiCtx = pContext;
			Script = pScript;
			Params = pParams;

			string script = FabricUtil.JsonUnquote(Script);
			string param = BuildParams();
			
			Query = script+(param.Length > 0 ? "#{"+param+"}" : "");
		}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, IWeaverScript pScripted) :
												this(pContext, pScripted.Script, pScripted.Params) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Execute() {
			long t = DateTime.UtcNow.Ticks;

			try {
				RawResult = GetRawResult(Query);
				Result = JsonSerializer.DeserializeFromString<DbResult>(RawResult);
				Result.BuildDbDtos(RawResult);
			}
			catch ( WebException we ) {
				vUnhandledException = we;

				Result = new DbResult();
				Result.Exception = we+"";

				Stream s = (we.Response == null ? null : we.Response.GetResponseStream());

				if ( s != null ) {
					var sr = new StreamReader(s);
					Result.Message = sr.ReadToEnd();
					Log.Error(ApiCtx.ContextId, "Grem", Result.Message);
				}
			}
			catch ( Exception e ) {
				vUnhandledException = e;
				Log.Error(ApiCtx.ContextId, "Unhandled raw: ", RawResult);

				Result = new DbResult();
				Result.Exception = e+"";
				Result.Message = "Unhandled exception.";
			}

			Result.ServerTime = (DateTime.UtcNow.Ticks-t)/10000.0; //to milliseconds
			LogAction();

			if ( vUnhandledException != null ) {
				vUnhandledException = new Exception("ApiDataAccess exception:\nResultString = "+
					RawResult+"\nUnhandedException = "+vUnhandledException, vUnhandledException);
				throw vUnhandledException;
			}

			if ( Result.DbDtos != null ) {
				ResultDtoList = new List<IDbDto>(Result.DbDtos);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual string GetRawResult(string pQuery) {
			TcpClient tcp = new TcpClient(ApiCtx.RexConnUrl, ApiCtx.RexConnPort);
			tcp.ReceiveBufferSize = 1048576;
			tcp.SendBufferSize = 1048576;

			byte[] data = Encoding.ASCII.GetBytes(ApiCtx.ContextId+"#"+pQuery+"\n");
			NetworkStream stream = tcp.GetStream();
			stream.Write(data, 0, data.Length);

			int size = tcp.ReceiveBufferSize;
			int bytes = size;
			string respData = "";

			while ( bytes == size ) {
				data = new byte[size];
				bytes = stream.Read(data, 0, data.Length);
				respData += Encoding.ASCII.GetString(data, 0, bytes);
			}

			tcp.Close();
			//Log.Debug("RESULT: "+respData);
			return respData;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string BuildParams() {
			if ( Params == null ) { return ""; }
			string p = "";

			foreach ( string key in Params.Keys ) {
				p += (p.Length > 0 ? "," : "")+"\""+FabricUtil.JsonUnquote(key)+"\":";

				IWeaverQueryVal qv = Params[key];

				if ( qv.IsString ) {
					p += "\""+FabricUtil.JsonUnquote(qv.GetQuoted())+"\"";
				}
				else {
					p += qv.FixedText;
				}
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
		public int GetTextListCount() {
			return (Result == null || Result.TextList == null ? -1 : Result.TextList.Count);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetStringResultAt(int pIndex) {
			return Result.TextList[pIndex];
		}

		/*--------------------------------------------------------------------------------------------*/
		public int GetIntResultAt(int pIndex) {
			return int.Parse(GetStringResultAt(pIndex));
		}

		/*--------------------------------------------------------------------------------------------*/
		public long GetLongResultAt(int pIndex) {
			return long.Parse(GetStringResultAt(pIndex));
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