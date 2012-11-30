using System;
using System.Collections.Generic;
using System.Dynamic;
using Fabric.Api.Server.Util;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Nancy;
using ServiceStack.Text;
using Weaver;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class ApiModule : NancyModule {

		private readonly Guid vRequestId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiModule() {
			Log.ConfigureOnce();

			vRequestId = Guid.NewGuid();
			//Log.Info(vRequestId, "REQUEST", "ApiModule Request");

			Get["/setup"] = DoSetup;
			Get["/json"] = DoJson;
			
			
			Get["/graph"] = (p => {
				return View["graph/index.html", null];
			});

			Get["/(.*)"] = GremlinRequest;
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GremlinRequest(dynamic pParams) {
			try {
				string query = (string)pParams["1"];
				query = query.Replace('/', '.');
				var gremReq = new GremlinRequest(query);
				return gremReq.ResponseData;
			}
			catch ( Exception ex ) {
				return "error: "+ex.Message;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string DoSetup(dynamic pParams) {
			try {
				if ( Context.Request.Query["pass"] != "asdfasdf" ) {
					//Context.Response.StatusCode = HttpStatusCode.Unauthorized;
					return "Password required.";
				}

				DataSet ds = Setup.SetupAll(false);
				string result = "";
				GremlinRequest req;

				foreach ( WeaverQuery q in ds.Indexes ) {
					req = new GremlinRequest(q);
					result += GetSetupLineItem(req);
				}

				foreach ( IDataNode n in ds.Nodes ) {
					req = new GremlinRequest(n.AddQuery);
					result += GetSetupLineItem(req);
					n.Node.Id = req.Result.GetNodeId();
				}

				foreach ( IDataNodeIndex ni in ds.NodeToIndexes ) {
					req = new GremlinRequest(ni.AddToIndexQuery);
					result += GetSetupLineItem(req);
				}

				foreach ( IDataRel r in ds.Rels ) {
					req = new GremlinRequest(r.AddQuery);
					result += GetSetupLineItem(req);
				}

				return result;
			}
			catch ( Exception ex ) {
				return "error: "+ex.Message;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string GetSetupLineItem(GremlinRequest pReq) {
			return "<b>"+pReq.Script+"</b><br/>"+pReq.ResponseData+"<br/><br/>";
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string DoJson(dynamic pParams) {
			dynamic obj = null;

			try {
				var req = new GremlinRequest("g.V;");
				List<DbResult> nodes = req.ResultList;

				req = new GremlinRequest("g.E;");
				List<DbResult> links = req.ResultList;

				obj = new ExpandoObject();
				obj.nodes = new List<ExpandoObject>();
				obj.links = new List<ExpandoObject>();

				foreach ( DbResult n in nodes ) {
					dynamic nodeObj = new ExpandoObject();
					string name = "";
					nodeObj.id = n.GetNodeId();
					
					foreach ( string key in n.Data.Keys ) {
						if ( key.LastIndexOf("Id") == key.Length-2 ) {
							name = key.Substring(0, key.Length-2);
							break;
						}
					}

					if ( n.Data.ContainsKey("Name") ) {
						name += ":"+n.Data["Name"];
					}

					nodeObj.name = name+" ("+nodeObj.id+")";
					nodeObj.selected = "n";

					obj.nodes.Add(nodeObj);
				}

				foreach ( DbResult l in links ) {
					dynamic linkObj = new ExpandoObject();
					linkObj.id = l.GetNodeId();
					linkObj.type = "x"; //l.Type;
					linkObj.start = linkObj.source = l.GetIdFromPath(l.Start);
					linkObj.end = linkObj.target = l.GetIdFromPath(l.End);

					if ( linkObj.start == 0 || linkObj.end == 0 ) { continue; }
					obj.links.Add(linkObj);
				}
			}
			catch ( Exception e ) {
				Log.Debug(vRequestId, "JSON", "Fail", e);
				return "Error: "+e.Message;
			}

			return JsonSerializer.SerializeToString(obj);
		}

	}

}