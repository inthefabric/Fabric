using System;
using System.Globalization;
using Fabric.Api.Dto;
using Fabric.Api.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Common {

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
			PreLogAction();
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
		protected virtual void PreLogAction() {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void LogAction() {
			ApiCtx.Analytics.TrackRequest(NancyReq.Method, NancyReq.Path);
			ApiCtx.Analytics.TrackEvent("Response", "DbMs", "", ApiCtx.DbQueryMillis);
			ApiCtx.Analytics.TrackEvent("Response", "TotalMs", "", (int)(vTicks/10000));
			ApiCtx.Analytics.TrackEvent("Response", "QueryCount", "",
				(int)ApiCtx.DbQueryExecutionCount);
			ApiCtx.Analytics.TrackEvent("Response", "HttpStatus", "", (int)vResp.StatusCode);

			//LOGv1: 
			//	Class, ip, QueryCount, DbMs, TotalMs, Timestamp, HttpStatus, Method, Path, Exception

			const string name = "LOGv1";
			const string x = " | ";

			string v1 =
				GetType().Name +x+
				NancyReq.UserHostAddress +x+
				ApiCtx.DbQueryExecutionCount +x+
				ApiCtx.DbQueryMillis +x+
				vTicks/10000 +x+
				DateTime.UtcNow.Ticks +x+
				(int)vResp.StatusCode +x+
				NancyReq.Method +x+
				NancyReq.Path;

			if ( UnhandledException == null ) {
				Log.Info(ApiCtx.ContextId, name, v1);
			}
			else {
				ApiCtx.Analytics.TrackEvent("Metrics", "Response", "UnhandledException", 1);
				Log.Error(ApiCtx.ContextId, name, v1, UnhandledException);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static TType GetValue<TType>(DynamicDictionary pDict, string pName,
									Func<DynamicDictionaryValue, TType> pConvert, bool pRequired=true) {
			DynamicDictionaryValue val = pDict[pName];

			if ( !pRequired && val == null ) {
				return default(TType);
			}

			if ( pRequired && string.IsNullOrEmpty(val) ) {
				throw new FabParamFault(FabFault.Code.IncorrectParamValue, pName, typeof(TType));
			}

			try {
				return pConvert(val);
			}
			catch ( Exception e ) {
				throw new FabParamFault(FabFault.Code.IncorrectParamType, pName, typeof(TType), e);
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
		protected long GetParamLong(string pName, bool pRequired=true) {
			return GetParam(pName, (v => v.ToInt64(EnUs)), pRequired);
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
		protected long GetPostLong(string pName, bool pRequired=true) {
			return GetPost(pName, (v => v.ToInt64(EnUs)), pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected byte GetPostByte(string pName, bool pRequired=true) {
			return GetPost(pName, (v => v.ToByte(EnUs)), pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected double GetPostDouble(string pName, bool pRequired=true) {
			return GetPost(pName, (v => v.ToDouble(EnUs)), pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected bool GetPostBool(string pName, bool pRequired=true) {
			string val = GetPost(pName, (v => v.ToString(EnUs)), pRequired);

			switch ( val.ToLower() ) {
				case "true": return true;
				case "false": return false;
			}

			throw new FabParamFault(FabFault.Code.IncorrectParamType, pName, typeof(bool));
		}

	}

}