using System;
using System.Globalization;
using Fabric.Api.Dto;
using Fabric.Api.Oauth;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.Common {

	/*================================================================================================*/
	public abstract class Controller {

		private static readonly CultureInfo EnUs = new CultureInfo("en-US");

		protected Request NancyReq { get; private set; }
		protected IApiContext ApiCtx { get; private set; }
		protected DynamicDictionary Query { get; private set; }
		protected DynamicDictionary Form { get; private set; }
		protected Exception UnhandledException { get; private set; }

		private long vTicks;
		private Response vResp;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Controller(Request pRequest, IApiContext pApiContext) {
			NancyReq = pRequest;
			ApiCtx = pApiContext;
			Query = NancyReq.Query;
			Form = NancyReq.Form;
		}

		/*--------------------------------------------------------------------------------------------*/
		public Response Execute() {
			long t = DateTime.UtcNow.Ticks;

			try {
				vResp = BuildResponse();
			}
			catch ( Exception e ) {
				UnhandledException = e;
				vResp = BuildExceptionResponse(e);

				if ( vResp == null ) {
					var err = FabError.ForInternalServerError();
					vResp = NancyUtil.BuildJsonResponse(
						HttpStatusCode.InternalServerError, err.ToJson());
				}
			}

			vTicks = DateTime.UtcNow.Ticks-t;
			LogAction();
			return vResp;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract Response BuildResponse();

		/*--------------------------------------------------------------------------------------------*/
		protected virtual Response BuildExceptionResponse(Exception pEx) {
			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void ExceptionIsHandled() {
			UnhandledException = null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void LogAction() {
			//LOGv1: 
			//	Class, ip, QueryCount, TotalMs, Timestamp, HttpStatus, Method, Path, Exception

			const string name = "LOGv1";
			const string x = " | ";

			string v1 =
				GetType().Name +x+
				NancyReq.UserHostAddress +x+
				ApiCtx.DbQueryExecutionCount +x+
				vTicks/10000 +x+
				DateTime.UtcNow.Ticks +x+
				(int)vResp.StatusCode +x+
				NancyReq.Method +x+
				NancyReq.Path;

			if ( UnhandledException == null ) {
				Log.Info(ApiCtx.ContextId, name, v1);
			}
			else {
				Log.Error(ApiCtx.ContextId, name, v1, UnhandledException);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static TType GetValue<TType>(DynamicDictionary pDict, string pName,
									Func<DynamicDictionaryValue, TType> pConvert, bool pRequired=true) {
			try {
				DynamicDictionaryValue val = pDict[pName];

				if ( !pRequired && val == null ) {
					return default(TType);
				}

				if ( pRequired && string.IsNullOrEmpty(val) ) {
					throw new Exception("Value is null or empty.");
				}

				return pConvert(val);
			}
			catch ( Exception e ) {
				Log.Error("OAuth query string: "+pName, e);
				throw new OauthException("InvalidParameter",
					"Parameter '"+pName+"' is required, and must be of type '"+typeof(TType).Name+"'.");
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private TType GetParam<TType>(string pName, Func<DynamicDictionaryValue,TType> pConvert, 
																				bool pRequired=true) {
			return GetValue(Query, pName, pConvert, pRequired);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected string GetParamString(string pName, bool pRequired=true) {
			return GetParam(pName, (v => v.ToString(EnUs)), pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected int GetParamInt(string pName, bool pRequired=true) {
			return GetParam(pName, (v => v.ToInt32(EnUs)), pRequired);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private TType GetPost<TType>(string pName, Func<DynamicDictionaryValue, TType> pConvert,
																				bool pRequired=true) {
			return GetValue(Form, pName, pConvert, pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected string GetPostString(string pName, bool pRequired=true) {
			return GetPost(pName, (v => v.ToString(EnUs)), pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected int GetPostInt(string pName, bool pRequired=true) {
			return GetPost(pName, (v => v.ToInt32(EnUs)), pRequired);
		}

	}

}