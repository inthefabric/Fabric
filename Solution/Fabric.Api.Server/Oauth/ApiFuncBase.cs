using System;
using System.Text;
using Fabric.Api.Oauth;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;
using System.Globalization;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public abstract class ApiFuncBase {

		private static CultureInfo EnUs = new CultureInfo("en-US");

		protected DynamicDictionary Query { get; private set; }
		protected IApiContext ApiCtx { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiFuncBase(DynamicDictionary pQuery, IApiContext pApiContext) {
			Query = pQuery;
			ApiCtx = pApiContext;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private TType GetParam<TType>(string pName, Func<DynamicDictionaryValue,TType> pConvert, 
																				bool pRequired=true) {
			try {
				DynamicDictionaryValue val = Query[pName];

				if ( !pRequired && val == null ) {
					return default(TType);
				}

				return pConvert(val);
			}
			catch ( Exception e ) {
				Log.Error("OAuth query string: "+pName, e);
				throw new OauthException("InvalidParameter",
					"Parameter '"+pName+"' is required, and must be of type '"+typeof(TType).Name+"'.");
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected string GetParamString(string pName, bool pRequired=true) {
			return GetParam(pName, (v => v.ToString(EnUs)), pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected int GetParamInt(string pName, bool pRequired=true) {
			return GetParam(pName, (v => v.ToInt32(EnUs)), pRequired);
		}

	}

	
	/*================================================================================================*/
	public static class ApiFuncBaseExt {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Response ToResponse<T>(this IApiFunc<T> pFunc) {
			string json;
			HttpStatusCode statCode;

			try {
				T result = pFunc.Go(pFunc.Context);
				json = result.ToJson();
				statCode = HttpStatusCode.OK;
			}
			catch ( OauthException oe ) {
				json = oe.OauthError.ToJson();
				statCode = HttpStatusCode.Forbidden;
			}

			byte[] bytes = Encoding.UTF8.GetBytes(json);

			return new Response {
				ContentType = "application/json",
				StatusCode = statCode,
				Contents = (s => s.Write(bytes, 0, bytes.Length))
			};
		}

	}

}