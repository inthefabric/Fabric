using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Fabric.Infrastructure;
using ServiceStack.Text;

namespace Fabric.Db.Server.Query {

	/*================================================================================================*/
	public class GremlinQuery {

		public enum DbResultType {
			None = 0,
			Single,
			List,
			Text,
			Error
		}

		public const string GremlinPath = 
			"http://localhost:7474/db/data/ext/GremlinPlugin/graphdb/execute_script";

		private readonly byte[] vQueryData;

		private bool vResultSet;
		private DbResult vResult;

		private bool vResultListSet;
		private List<DbResult> vResultList;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GremlinQuery(string pQuery) {
			vQueryData = Encoding.UTF8.GetBytes(pQuery);
			ResultType = DbResultType.None;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Execute() {
			ResponseString = "";

			try {
				var wc = new WebClient();
				ResponseData = wc.UploadData(GremlinPath, "POST", vQueryData);
				ResponseString = Encoding.UTF8.GetString(ResponseData);
			}
			catch ( WebException we ) {
				//Log.Error(we+"");
				ResultType = DbResultType.Error;
				Stream s = we.Response.GetResponseStream();

				if ( s != null ) {
					var sr = new StreamReader(s);
					ResponseString = sr.ReadToEnd();
					Log.Error(ResponseString);
					return;
				}

				ResponseString = "{\"Exception\":\""+we.ToString().Replace("\"", "'")+"\"}";
				return;
			}

			////
			
			if ( ResponseString.Length < 3 ) {
				ResultType = DbResultType.Text;
				return;
			}

			char first = ResponseString[0];

			if ( first == '[' && (ResponseString[2] == '{' || ResponseString == "[ ]") ) {
				ResultType = DbResultType.List;
			}
			else if ( first == '{' ) {
				ResultType = DbResultType.Single;
			}
			else {
				ResultType = DbResultType.Text;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public byte[] ResponseData { get; private set; }
		public string ResponseString { get; private set; }
		public DbResultType ResultType { get; private set; }

		/*--------------------------------------------------------------------------------------------*/
		public DbResult Result {
			get {
				if ( vResultSet ) {
					return vResult;
				}

				if ( ResultType == DbResultType.Text ) {
					return new DbResult { Message = ResponseString };
				}

				if ( ResultType != DbResultType.Single && ResultType != DbResultType.Error ) {
					return null;
				}

				vResult = JsonSerializer.DeserializeFromString<DbResult>(ResponseString);
				vResultSet = true;
				return vResult;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public List<DbResult> ResultList {
			get {
				if ( vResultListSet ) {
					return vResultList;
				}

				if ( ResultType != DbResultType.List ) {
					return null;
				}

				vResultList = JsonSerializer.DeserializeFromString<List<DbResult>>(ResponseString);
				vResultListSet = true;
				return vResultList;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDbDto ResultDto {
			get {
				return (Result != null ? new DbDto(Result) : null);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public List<IDbDto> ResultDtoList {
			get {
				return (ResultList != null ?
					ResultList.Select(r => new DbDto(r)).ToList<IDbDto>() : null);
			}
		}

	}

}