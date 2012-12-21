using System;
using System.Globalization;
using System.Text;
using Fabric.Api.Oauth;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Server.Oauth {

	/*================================================================================================*/
	public abstract class OauthBase<T> {

		protected NancyContext Context { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Response Go(NancyContext pContext) {
			Context = pContext;
			return GetResponse(BuildFunc());
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract IActiveFunc<T> BuildFunc();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TType GetParam<TType>(string pName, Func<DynamicDictionaryValue,TType> pConvert, 
																				bool pRequired=true) {
			try {
				DynamicDictionaryValue val = Context.Request.Query[pName];

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
			return GetParam(pName, (v => v.ToString()), pRequired);
		}

		/*--------------------------------------------------------------------------------------------* /
		protected int GetQsInt(string pName, bool pRequired=true) {
			return GetQs(pName, (v => v.ToInt32(null)), pRequired);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected Response GetResponse(IActiveFunc<T> pFunc) {
			string json;
			HttpStatusCode statCode;

			try {
				var asc = new ApiRequestContext("http://localhost:9001/");
				T result = pFunc.Go(asc);
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