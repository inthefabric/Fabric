using System;
using System.Collections.Generic;
using System.Net;
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
		public IDictionary<string, string> Params { get; private set; }
		public string Query { get; private set; }

		public byte[] ResultBytes { get; private set; }
		public string ResultString { get; private set; }
		public IDbResult Result { get; private set; }
		public IList<IDbDto> ResultDtoList { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(IApiContext pContext, string pScript, 
															IDictionary<string, string> pParams=null) {
			ApiCtx = pContext;
			Script = pScript;
			Params = pParams;
			
			string script =
				"try{"+
					FabricUtil.JsonUnquote(Script)+
				"}"+
				"catch(e){"+
					"g.stopTransaction(TransactionalGraph.Conclusion.FAILURE);"+
					"e;"+
				"}";

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
			ResultString = GetResultString();
			Result = JsonSerializer.DeserializeFromString<DbResult>(ResultString);
			Result.BuildDbDtos(ResultString);
			Log.Debug("RESULT: "+ResultString);

			if ( Result.Exception != null ) {
				throw new Exception(ResultString);
			}

			if ( Result.DbDtos != null ) {
				ResultDtoList = new List<IDbDto>(Result.DbDtos);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual string GetResultString() {
			byte[] queryData = Encoding.UTF8.GetBytes(ApiCtx.ContextId+Query);

			using ( var wc = new WebClient() ) {
				ResultBytes = wc.UploadData(ApiCtx.DbServerUrl, "POST", queryData);
			}

			return Encoding.UTF8.GetString(ResultBytes);
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
		public T GetResultAt<T>(int pIndex) where T : INodeWithId, new() {
			return ResultDtoList[pIndex].ToNode<T>();
		}

	}

}