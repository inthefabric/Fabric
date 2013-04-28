using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using ServiceStack.Text;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiDataAccess : IApiDataAccess {

		private static readonly Semaphore Sema = new Semaphore(20, 20, "ApiDataAccess");
		private static int TcpCount;

		public IApiContext ApiCtx { get; private set; }

		public string Script { get; private set; }
		public IDictionary<string, IWeaverQueryVal> Params { get; private set; }
		public RexConnTcpRequest Request { get; private set; }

		public string ResponseJson { get; private set; }
		public RexConnTcpResponse Response { get; private set; }
		public IDbResult Result { get; private set; }
		public IList<IDbDto> ResultDtoList { get; private set; }

		private string vReqJson;
		private Exception vUnhandledException;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, string pScript, 
													IDictionary<string, IWeaverQueryVal> pParams=null) {
			ApiCtx = pContext;
			Script = pScript;
			Params = pParams;

			Request = BuildRequest(Script, Params);
		}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, IWeaverScript pScripted) :
												this(pContext, pScripted.Script, pScripted.Params) {}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, IList<IWeaverScript> pScriptedList) {
			ApiCtx = pContext;
			Request = BuildRequest(pScriptedList);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Execute() {
			DateTime t = DateTime.UtcNow;

			try {
				Sema.WaitOne();
				++TcpCount;

				JsConfig.EmitCamelCaseNames = true;
				vReqJson = JsonSerializer.SerializeToString(Request);
				JsConfig.EmitCamelCaseNames = false;

				//Log.Debug("REQUEST: "+vReqJson);
				ResponseJson = GetRawResult(vReqJson);
				Sema.Release();

				Response = JsonSerializer.DeserializeFromString<RexConnTcpResponse>(ResponseJson);

				if ( Response == null ) {
					throw new Exception("Response is null.");
				}

				if ( Response.Err != null ) {
					throw new Exception("Response has an error.");
				}

				Result = new DbResult(Response, ResponseJson);
			}
			catch ( WebException we ) {
				vUnhandledException = we;

				Response = new RexConnTcpResponse();
				Response.Err = we+"";

				Stream s = (we.Response == null ? null : we.Response.GetResponseStream());

				if ( s != null ) {
					var sr = new StreamReader(s);
					Log.Error(ApiCtx.ContextId, "Grem", sr.ReadToEnd());
				}
			}
			catch ( Exception e ) {
				vUnhandledException = e;
				Log.Error(ApiCtx.ContextId, "Unhandled raw: ", ResponseJson);

				Result = new DbResult(Response, "");
				Result.Exception = Result.Exception+". Exception: "+e;
			}

			--TcpCount;
			Result.ServerTime = (DateTime.UtcNow-t).TotalMilliseconds;
			LogAction();

			if ( vUnhandledException != null ) {
				vUnhandledException = new Exception("ApiDataAccess exception:"+
					"\nQuery = "+Request+
					"\nResultString = "+ResponseJson+
					"\nUnhandedException = "+vUnhandledException, vUnhandledException);
				throw vUnhandledException;
			}

			if ( Result.DbDtos != null ) {
				ResultDtoList = new List<IDbDto>(Result.DbDtos);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual string GetRawResult(string pReqJson) {
			TcpClient tcp = new TcpClient(ApiCtx.RexConnUrl, ApiCtx.RexConnPort);
			tcp.ReceiveBufferSize = 1048576;
			tcp.SendBufferSize = 1048576;

			byte[] data = Encoding.ASCII.GetBytes(pReqJson+"\n");
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
		private RexConnTcpRequest BuildRequest(string pScript,
														IDictionary<string, IWeaverQueryVal> pParams) {
			var req = new RexConnTcpRequest();
			req.ReqId = ApiCtx.ContextId.ToString();
			req.CmdList = new List<RexConnTcpRequestCommand>();
			req.CmdList.Add(BuildRequestCommand(pScript, pParams));
			return req;
		}

		/*--------------------------------------------------------------------------------------------*/
		private RexConnTcpRequest BuildRequest(IList<IWeaverScript> pScriptedList) {
			var req = new RexConnTcpRequest();
			req.ReqId = ApiCtx.ContextId.ToString();
			req.CmdList = new List<RexConnTcpRequestCommand>();

			/*RexConnTcpRequestCommand cmd = new RexConnTcpRequestCommand();
			cmd.Cmd = RexConnCommand.Config;
			cmd.Args = new List<string>();
			cmd.Args.Add(RexConnConfigSetting.Debug);
			cmd.Args.Add("1");
			req.CmdList.Add(cmd);*/

			//MatchCollection mc = Regex.Matches(s, @"_(\w+?)(\d+)");

			AddSessionAction(req, RexConnSessionAction.Start);

			foreach ( IWeaverScript ws in pScriptedList ) {
				req.CmdList.Add(BuildRequestCommand(ws.Script, ws.Params));
			}

			AddSessionAction(req, RexConnSessionAction.Commit);
			AddSessionAction(req, RexConnSessionAction.Close);
			return req;
		}

		/*--------------------------------------------------------------------------------------------*/
		private RexConnTcpRequestCommand BuildRequestCommand(string pScript,
														IDictionary<string, IWeaverQueryVal> pParams) {
			var cmd = new RexConnTcpRequestCommand();
			cmd.Cmd = RexConnCommand.Query;
			cmd.Args = new List<string>();

			string q = FabricUtil.JsonUnquote(pScript);

			if ( pParams == null ) {
				cmd.Args.Add(q);
				return cmd;
			}

			string p = "";

			foreach ( string key in pParams.Keys ) {
				p += (p.Length > 0 ? "," : "")+"\""+FabricUtil.JsonUnquote(key)+"\":";

				IWeaverQueryVal qv = pParams[key];

				if ( qv.IsString ) {
					p += "\""+FabricUtil.JsonUnquote(qv.FixedText)+"\"";
					continue;
				}

				p += qv.FixedText;

				//Explicitly cast certain parameter types
				//See: https://github.com/tinkerpop/rexster/issues/295

				const string end = @"(?=$|[^\d])";

				if ( qv.Original is int ) {
					q = Regex.Replace(q, key+end, key+".toInteger()");
				}
				else if ( qv.Original is byte ) {
					q = Regex.Replace(q, key+end, key+".toInteger()"); //".byteValue()");
				}
				else if ( qv.Original is float ) {
					q = Regex.Replace(q, key+end, key+".toFloat()");
				}
			}

			cmd.Args.Add(q);
			cmd.Args.Add("{"+p+"}");
			return cmd;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddSessionAction(RexConnTcpRequest pReq, string pAction) {
			var cmd = new RexConnTcpRequestCommand();
			cmd.Cmd = RexConnCommand.Session;
			cmd.Args = new List<string>(new[] { pAction });
			pReq.CmdList.Add(cmd);
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
			//	TotalMs, QueryMs, Timestamp, TcpCount, QueryChars

			const string name = "DBv1";
			const string x = " | ";

			string v1 =
				Result.ServerTime +x+
				Result.QueryTime +x+
				DateTime.UtcNow.Ticks +x+
				TcpCount +x+
				vReqJson.Length;

			if ( vUnhandledException == null ) {
				Log.Info(ApiCtx.ContextId, name, v1);
			}
			else {
				Log.Error(ApiCtx.ContextId, name, v1, vUnhandledException);
			}
		}

	}

}