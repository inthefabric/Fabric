﻿using System;
using System.IO;
using System.Net;
using System.Text;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Db;
using ServiceStack.Text;

namespace Fabric.Db.Server.Query {

	/*================================================================================================*/
	public class GremlinQuery {

		public enum DbResultType {
			None = 0,
			Success,
			Error
		}

		public byte[] ResponseData { get; private set; }
		public string ResponseString { get; private set; }
		public DbResultType ResultType { get; private set; }
		public DbResult Result { get; private set; }

		private readonly string vGremlinUri;
		private readonly byte[] vQueryData;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GremlinQuery(string pGremlinUri, string pQuery) {
			vGremlinUri = pGremlinUri;
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
				ResponseData = wc.UploadData(vGremlinUri, "POST", vQueryData);
				ResponseString = Encoding.UTF8.GetString(ResponseData);
				ResultType = DbResultType.Success;
				//Log.Debug("RESPONSE: "+ResponseString);
			}
			catch ( WebException we ) {
				ResultType = DbResultType.Error;
				Stream s = (we.Response == null ? null : we.Response.GetResponseStream());

				if ( s != null ) {
					var sr = new StreamReader(s);
					ResponseString = sr.ReadToEnd();
					Log.Error(ResponseString);
				}
				else {
					Result = new DbResult();
					Result.Exception = we.GetType().Name;
					Result.Message = we.Message;
				}

				Log.Error("GremlinQuery "+Result.Exception+": "+Result.Message);
			}

			if ( Result == null ) {
				Result = JsonSerializer.DeserializeFromString<DbResult>(ResponseString);
				Result.BuildDbDtos(ResponseString);
			}

			Result.ServerTicks = (DateTime.UtcNow.Ticks-t);
		}

	}

}