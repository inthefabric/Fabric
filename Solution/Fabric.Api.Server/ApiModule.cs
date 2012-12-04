using System;
using System.Collections.Generic;
using System.Dynamic;
using Fabric.Api.Server.Graph;
using Fabric.Api.Server.Query;
using Fabric.Api.Server.Util;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Nancy;
using Nancy.Responses.Negotiation;
using ServiceStack.Text;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class ApiModule : NancyModule {

		private readonly Guid vRequestId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiModule() {
			Log.ConfigureOnce();

			vRequestId = Guid.NewGuid();
			Log.Info(vRequestId, "REQUEST", "ApiModule Request");

			Get["/setup"] = DoSetup;
			Get["/json"] = DoJson;
			Get["/graph"] = DoGraph;
			Get["/(.*)"] = (p => new DataQuery(Context).GetResponse());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string DoSetup(dynamic pParams) {
			try {
				if ( Context.Request.Query["pass"] != "asdfasdf" ) {
					//Context.Response.StatusCode = HttpStatusCode.Unauthorized;
					return "Password required.";
				}

				DataSet ds = Setup.SetupAll(true); //false);
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
			return "<b>"+pReq.Script+"</b><br/>"+pReq.ResponseString+"<br/><br/>";
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Negotiator DoGraph(dynamic pParams) {
			return View["graph/index.html", new GraphModel(Context.Request.Query["q"])];
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string DoJson(dynamic pParams) {
			dynamic obj = null;

			try {
				string q = Context.Request.Query["q"];

				if ( String.IsNullOrEmpty(q) ) {
					q = "x=[];g.V.aggregate(x).iterate();g.E.aggregate(x).iterate();x;";
				}
				
				var req = new GremlinRequest(q);
				var nodes = new List<DbResult>();
				var links = new List<DbResult>();
				var nodeIdMap = new Dictionary<long, dynamic>();
				var linkIdMap = new Dictionary<long, dynamic>();

				foreach ( DbResult dr in req.ResultList ) {
					long id = dr.GetNodeId();

					if ( dr.Self[0] == 'n' ) {
						if ( nodeIdMap.ContainsKey(id) ) { continue; }
						nodeIdMap.Add(id, dr);
						nodes.Add(dr);
					}
					else {
						if ( linkIdMap.ContainsKey(id) ) { continue; }
						linkIdMap.Add(id, dr);
						links.Add(dr);
					}
				}

				obj = new ExpandoObject();
				obj.nodes = new List<ExpandoObject>();
				obj.links = new List<ExpandoObject>();

				nodeIdMap = new Dictionary<long, dynamic>();
				//linkIdMap = new Dictionary<long, dynamic>();
				int nodeI = 1;
				obj.nodes.Add(new ExpandoObject());

				foreach ( DbResult n in nodes ) {
					dynamic nodeObj = new ExpandoObject();
					string name = "";
					nodeObj.index = nodeI++;
					nodeObj.id = n.GetNodeId();
					nodeObj.Data = "";
					
					foreach ( string key in n.Data.Keys ) {
						if ( key.LastIndexOf("Id") == key.Length-2 ) {
							name = key.Substring(0, key.Length-2);
							nodeObj.Class = name;
						}

						nodeObj.Data += "\n - "+key+": "+n.Data[key];
					}

					if ( n.Data.ContainsKey("Name") ) {
						name += ": "+n.Data["Name"];
					}

					nodeObj.name = name;//+" ("+nodeObj.id+")";
					obj.nodes.Add(nodeObj);
					nodeIdMap.Add(nodeObj.id, nodeObj);
				}

				foreach ( DbResult l in links ) {
					dynamic linkObj = new ExpandoObject();
					linkObj.id = l.GetNodeId();
					linkObj.type = ExtractRelType(l);
					//linkObj.start = linkObj.source = l.GetIdFromPath(l.Start);
					//linkObj.end = linkObj.target = l.GetIdFromPath(l.End);
					linkObj.start = linkObj.source = nodeIdMap[l.GetIdFromPath(l.Start)].index;
					linkObj.end = linkObj.target = nodeIdMap[l.GetIdFromPath(l.End)].index;

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

		/*--------------------------------------------------------------------------------------------*/
		private string ExtractRelType(DbResult pLink) {
			string name = pLink.Type;
			object o = Activator.CreateInstance("Fabric.Domain", "Fabric.Domain."+name).Unwrap();
			IWeaverRel r = (o as IWeaverRel);
			return (r == null ? name : r.RelType.Label);
		}

	}

}