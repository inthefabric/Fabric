﻿//#define REX_CONN_DEBUG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using ServiceStack.Text;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiDataAccess : IApiDataAccess {

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
		private TcpClientPool vTcpPool;
		private Exception vUnhandledException;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, string pScript, 
													IDictionary<string, IWeaverQueryVal> pParams=null) {
			ApiCtx = pContext;
			Script = pScript;
			Params = pParams;

			vTcpPool = TcpClientPool.GetPool(ApiCtx.RexConnUrl, ApiCtx.RexConnPort);
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

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, RexConnTcpRequest pRequest) {
			ApiCtx = pContext;
			Request = pRequest;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Execute() {
			//ApiCtx.ProfilerTrace(this, "ex.start");
			var sw = new Stopwatch();
			sw.Start();

			try {
				++TcpCount;

#if REX_CONN_DEBUG
				var debugCmd = new RexConnTcpRequestCommand();
				debugCmd.Cmd = RexConnCommand.Config;
				debugCmd.Args = new List<string>(new [] { RexConnConfigSetting.Debug, "1" });
				Request.CmdList.Insert(0, debugCmd);
#endif

				JsConfig.EmitCamelCaseNames = true;
				vReqJson = JsonSerializer.SerializeToString(Request);
				JsConfig.EmitCamelCaseNames = false;

				Log.Debug("REQUEST: "+vReqJson);
				//ApiCtx.ProfilerTrace(this, "ex.get");
				ResponseJson = GetRawResult(vReqJson);
				//ApiCtx.ProfilerTrace(this, "ex.resp");

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
				Response.CmdList = new List<RexConnTcpResponseCommand>();

				Stream s = (we.Response == null ? null : we.Response.GetResponseStream());

				if ( s != null ) {
					var sr = new StreamReader(s);
					Log.Error(ApiCtx.ContextId, "Grem", sr.ReadToEnd());
				}
			}
			catch ( Exception e ) {
				vUnhandledException = e;
				Log.Error(ApiCtx.ContextId, "Unhandled raw: ", ResponseJson);

				Response = new RexConnTcpResponse();
				Response.Err = e+"";
				Response.CmdList = new List<RexConnTcpResponseCommand>();

				Result = new DbResult(Response, ResponseJson);
				Result.Exception = Result.Exception+". Exception: "+e;
			}

			--TcpCount;
			Result.ServerTime = (int)sw.ElapsedMilliseconds;
			LogAction();

			if ( vUnhandledException != null ) {
				vUnhandledException = new Exception("ApiDataAccess exception:"+
					"\nQuery = "+JsonSerializer.SerializeToString(Request)+
					"\nResultString = "+ResponseJson+
					"\nUnhandedException = "+vUnhandledException, vUnhandledException);
				throw vUnhandledException;
			}

			if ( Result.DbDtos != null ) {
				ResultDtoList = new List<IDbDto>(Result.DbDtos);
			}


			for ( int i = 0 ; i < Response.CmdList.Count ; ++i ) {
				RexConnTcpResponseCommand rc = Response.CmdList[i];

				if ( rc.Err != null ) {
					Log.Warn(ApiCtx.ContextId, "DATA", "Response.CmdList["+i+"] error: "+rc.Err);
				}
			}

			//ApiCtx.ProfilerTrace(this, "ex.done");
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual string GetRawResult(string pReqJson) {
			//ApiCtx.ProfilerTrace(this, "grr1");
			TimedTcpClient tcp = vTcpPool.TakeClient();
			//ApiCtx.ProfilerTrace(this, "grr2");
			tcp.SendBufferSize = tcp.ReceiveBufferSize = 1<<16;

			byte[] dataLen = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(pReqJson.Length));
			byte[] data = Encoding.ASCII.GetBytes(pReqJson);
			//ApiCtx.ProfilerTrace(this, "grr3");

			NetworkStream stream = tcp.GetStream();
			//ApiCtx.ProfilerTrace(this, "grr4");
			stream.Write(dataLen, 0, dataLen.Length); //begin with the request's string length
			stream.Write(data, 0, data.Length);

			//TODO: Get string length from the first four bytes
			/*data = new byte[4];
			stream.Read(data, 0, data.Length);

			foreach ( byte b in data ) {
				Log.Debug(" - "+b);
			}*/

			//ApiCtx.ProfilerTrace(this, "grr5");
			data = new byte[tcp.ReceiveBufferSize];
			int bytes = stream.Read(data, 0, data.Length);
			string respData = Encoding.ASCII.GetString(data, 4, bytes-4);
			//ApiCtx.ProfilerTrace(this, "grr6");

			/*const int size = 1<<11;
			int offset = 4;
			var respData = new StringBuilder();
			string test = "";

			while ( true ) {
				data = new byte[size];
				int bytes = stream.Read(data, 0, data.Length);

				respData.AppendFormat("{0}", Encoding.ASCII.GetString(data, offset, bytes-offset));
				offset = 0; //only the first read needs the offset
				test += "R: "+bytes+" / "+size+" / "+stream.DataAvailable+"\n";

				if ( !stream.DataAvailable ) {
					break;
				}
			}

			Log.Debug(test);*/

			vTcpPool.ReturnClient(tcp);
			Log.Debug("RESULT: "+respData);
			//ApiCtx.ProfilerTrace(this, "grr7");
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

#if REX_CONN_DEBUG
			var debugCmd = new RexConnTcpRequestCommand();
			debugCmd.Cmd = RexConnCommand.Config;
			debugCmd.Args = new List<string>(new[] { RexConnConfigSetting.Debug, "1" });
			req.CmdList.Add(debugCmd);
#endif

			AddSessionAction(req, RexConnSessionAction.Start);

			foreach ( IWeaverScript ws in pScriptedList ) {
				req.CmdList.Add(BuildRequestCommand(ws.Script, ws.Params));
			}

			AddSessionAction(req, RexConnSessionAction.Commit);
			AddSessionAction(req, RexConnSessionAction.Close);
			return req;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static RexConnTcpRequestCommand BuildRequestCommand(string pScript,
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
					q = Regex.Replace(q, key+end, key+".byteValue()");
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
		public static void AddSessionAction(RexConnTcpRequest pReq, string pAction) {
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