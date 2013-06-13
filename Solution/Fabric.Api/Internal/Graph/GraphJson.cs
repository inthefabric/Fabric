using System;
using System.Collections.Generic;
using System.Dynamic;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using Nancy;
using ServiceStack.Text;
using Weaver.Interfaces;

namespace Fabric.Api.Internal.Graph {

	/*================================================================================================*/
	public class GraphJson {

		private readonly NancyContext vContext;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GraphJson(NancyContext pContext) {
			vContext = pContext;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetResponse() {
			dynamic obj;

			try {
				string q = vContext.Request.Query["q"];

				if ( String.IsNullOrEmpty(q) ) {
					q = "x=[];root=g.v(4);g.V.aggregate(x).iterate();"+
						"g.V.inE.outV.except([root]).back(2).aggregate(x).iterate();x";
				}

				var ctx = new ApiContext("localhost", 8185, null);

				IWeaverQuery query = Weave.Inst.NewQuery();
				query.FinalizeQuery(q);
				IApiDataAccess data = ctx.DbData("getGraphData", query);

				var nodes = new List<IDbDto>();
				var links = new List<IDbDto>();
				var nodeIdMap = new Dictionary<string, dynamic>();
				var linkIdMap = new Dictionary<string, dynamic>();

				foreach ( IDbDto dto in data.ResultDtoList ) {
					string id = (dto.Id ?? "");

					switch ( dto.Item ) {
						case DbDto.ItemType.Node:
							if ( nodeIdMap.ContainsKey(id) ) { continue; }
							nodeIdMap.Add(id, dto);
							nodes.Add(dto);
							break;

						case DbDto.ItemType.Rel:
							if ( linkIdMap.ContainsKey(id) ) { continue; }
							linkIdMap.Add(id, dto);
							links.Add(dto);
							break;
					}
				}

				obj = new ExpandoObject();
				obj.nodes = new List<ExpandoObject>();
				obj.links = new List<ExpandoObject>();

				nodeIdMap = new Dictionary<string, dynamic>();

				int nodeI = 1;
				var rand = new Random(999);

				dynamic nodeObj = new ExpandoObject();
				nodeObj.index = 0;
				nodeObj.x = nodeObj.y = 0.5;
				obj.nodes.Add(nodeObj);

				foreach ( DbDto n in nodes ) {
					nodeObj = new ExpandoObject();
					nodeObj.index = nodeI++;
					nodeObj.id = n.Id;
					nodeObj.Class = n.Class;
					nodeObj.name = n.Class;
					nodeObj.Data = "";

					nodeObj.x = rand.NextDouble()*0.5+0.25;
					nodeObj.y = rand.NextDouble()*0.5+0.25;

					if ( n.Data != null ) {
						foreach ( string key in n.Data.Keys ) {
							nodeObj.Data += "\n - "+key+": "+n.Data[key];
						}
					}

					/*if ( n.Data.ContainsKey("Name") ) {
						name += ": "+n.Data["Name"];
					}*/

					obj.nodes.Add(nodeObj);
					nodeIdMap.Add(nodeObj.id, nodeObj);
				}

				foreach ( DbDto l in links ) {
					dynamic linkObj = new ExpandoObject();
					linkObj.id = l.Id;
					linkObj.type = ExtractEdgeType(l);

					if ( l.OutVertexId != null ) {
						linkObj.start = linkObj.source = nodeIdMap[l.OutVertexId].index;
					}

					if ( l.InVertexId != null ) {
						linkObj.end = linkObj.target = nodeIdMap[l.InVertexId].index;
					}

					if ( linkObj.start == 1 || linkObj.end == 1 ) { continue; }
					obj.links.Add(linkObj);
				}
			}
			catch ( Exception e ) {
				Log.Debug("Fail", e);
				return "Error: "+e.Message;
			}

			return JsonSerializer.SerializeToString(obj);
		}

		/*--------------------------------------------------------------------------------------------*/
		private string ExtractEdgeType(DbDto pLink) {
			string name = pLink.Class;
			object o = Activator.CreateInstance("Fabric.Domain", "Fabric.Domain."+name).Unwrap();
			IWeaverEdge r = (o as IWeaverEdge);
			return (r == null ? name : r.EdgeType.Label);
		}

	}

}