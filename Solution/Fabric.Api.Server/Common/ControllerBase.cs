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
	public abstract class ControllerBase {

		private static readonly CultureInfo EnUs = new CultureInfo("en-US");

		protected IApiContext ApiCtx { get; private set; }
		protected DynamicDictionary Query { get; private set; }
		protected DynamicDictionary Form { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ControllerBase(IApiContext pApiContext, DynamicDictionary pQuery,
																			DynamicDictionary pForm) {
			ApiCtx = pApiContext;
			Query = pQuery;
			Form = pForm;
		}

		/*--------------------------------------------------------------------------------------------*/
		public Response Execute() {
			try {
				return BuildResponse();
			}
			catch ( Exception e ) {
				Log.Error(GetType().Name+" Unhandled Exception", e);
				var err = FabError.ForInternalServerError();
				return NancyUtil.BuildJsonResponse(HttpStatusCode.InternalServerError, err.ToJson());
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract Response BuildResponse();


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