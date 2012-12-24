using System.Collections.Generic;
using System.Net;
using System.Text;
using ServiceStack.Text;
using Weaver;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiDataAccess {

		public ApiContext Context { get; private set; }

		public string Script { get; private set; }
		public IDictionary<string, string> Params { get; private set; }
		public string Query { get; private set; }

		public byte[] ResultBytes { get; private set; }
		public string ResultString { get; private set; }
		public DbDto ResultDto { get; private set; }
		public List<DbDto> ResultDtoList { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(ApiContext pContext, string pScript, 
														IDictionary<string, string> pParams=null) {
			Context = pContext;
			Script = pScript;
			Params = pParams;
		}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess(ApiContext pContext, WeaverQuery pQuery) :
														this(pContext, pQuery.Script, pQuery.Params) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Execute() {
			string param = BuildParams();

			Query = "{\"script\":\""+FabricUtil.JsonUnquote(Script)+"\""+
				(param.Length > 0 ? ",\"params\":{"+param+"}" : "")+"}";

			byte[] queryData = Encoding.UTF8.GetBytes(Query);

			using ( var wc = new WebClient() ) {
				ResultBytes = wc.UploadData(Context.DbServerUrl, "POST", queryData);
			}

			ResultString = Encoding.UTF8.GetString(ResultBytes);

			////

			if ( ResultString == "[]" ) {
				ResultDtoList = new List<DbDto>();
			}
			else if ( ResultString[0] == '[' && ResultString[1] == '{' ) {
				ResultDtoList = JsonSerializer.DeserializeFromString<List<DbDto>>(ResultString);
			}
			else if ( ResultString[0] == '{' ) {
				ResultDto = JsonSerializer.DeserializeFromString<DbDto>(ResultString);
			}
		}

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

	}

}