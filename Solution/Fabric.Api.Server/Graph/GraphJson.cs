using System;
using System.Collections.Generic;
using System.Dynamic;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Server.Graph {

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

				var ctx = new ApiContext("http://localhost:9001/");

				IWeaverQuery query = new WeaverQuery();
				query.FinalizeQuery(q);
				IApiDataAccess data = ctx.DbData("getGraphData", query);

				var nodes = new List<IDbDto>();
				var links = new List<IDbDto>();
				var nodeIdMap = new Dictionary<long, dynamic>();
				var linkIdMap = new Dictionary<long, dynamic>();

				foreach ( IDbDto dto in data.ResultDtoList ) {
					long id = (dto.NodeId ?? -1);

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

				nodeIdMap = new Dictionary<long, dynamic>();

				int nodeI = 1;
				var rand = new Random(999);

				dynamic nodeObj = new ExpandoObject();
				nodeObj.index = 0;
				nodeObj.x = nodeObj.y = 0.5;
				obj.nodes.Add(nodeObj);

				foreach ( DbDto n in nodes ) {
					nodeObj = new ExpandoObject();
					nodeObj.index = nodeI++;
					nodeObj.id = n.NodeId;
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
					linkObj.id = l.NodeId;
					linkObj.type = ExtractRelType(l);

					if ( l.FromNodeId != null ) {
						linkObj.start = linkObj.source = nodeIdMap[(long)l.FromNodeId].index;
					}

					if ( l.ToNodeId != null ) {
						linkObj.end = linkObj.target = nodeIdMap[(long)l.ToNodeId].index;
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
		private string ExtractRelType(DbDto pLink) {
			string name = pLink.Class;
			object o = Activator.CreateInstance("Fabric.Domain", "Fabric.Domain."+name).Unwrap();
			IWeaverRel r = (o as IWeaverRel);
			return (r == null ? name : r.RelType.Label);
		}

	}

}