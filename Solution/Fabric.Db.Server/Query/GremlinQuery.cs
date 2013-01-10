using System;
using System.Collections.Generic;
using System.IO;
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
			"http://localhost:8182/graphs/FabricTest/tp/gremlin";

		private readonly byte[] vQueryData;

		private DbResult vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GremlinQuery(string pQuery) {
			vQueryData = Encoding.UTF8.GetBytes(pQuery);
			ResultType = DbResultType.None;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Execute() {
			ResponseString = "";
			long t = DateTime.UtcNow.Ticks;

			try {
				var wc = new WebClient();
				wc.Headers.Add("Content-Type", "application/json");
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
				}
				else {
					ResponseString = "{\"Exception\":\""+we.ToString().Replace("\"", "'")+"\"}";
				}
			}

			vResult = JsonSerializer.DeserializeFromString<DbResult>(ResponseString);
			vResult.BuildDbDtos(ResponseString);
			vResult.ServerTicks = (DateTime.UtcNow.Ticks-t);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public byte[] ResponseData { get; private set; }
		public string ResponseString { get; private set; }
		public DbResultType ResultType { get; private set; }

		/*--------------------------------------------------------------------------------------------*/
		public DbResult Result {
			get {
				/*if ( vResultSet ) {
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
				return vResult;*/
				return vResult;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public List<DbResult> ResultList {
			get {
				/*if ( vResultListSet ) {
					return vResultList;
				}

				if ( ResultType != DbResultType.List ) {
					return null;
				}

				vResultList = JsonSerializer.DeserializeFromString<List<DbResult>>(ResponseString);
				vResultListSet = true;
				return vResultList;*/
				return null;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDbDto ResultDto {
			get {
				return null; //(Result != null ? new DbDto(ResultList[0].Results) : null);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public List<IDbDto> ResultDtoList {
			get {
				return null; //(ResultList != null ?
					//ResultList.Select(r => new DbDto(r)).ToList<IDbDto>() : null);
			}
		}

	}

}