using System;
using System.Collections.Generic;
using System.Dynamic;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Nancy;
using ServiceStack.Text;
using Weaver.Core.Elements;
using Weaver.Core.Query;

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

				IWeaverQuery query = new WeaverQuery();
				query.FinalizeQuery(q);
				IApiDataAccess data = ctx.DbData("getGraphData", query);

				var verts = new List<IDbDto>();
				var links = new List<IDbDto>();
				var vertexIdMap = new Dictionary<string, dynamic>();
				var linkIdMap = new Dictionary<string, dynamic>();

				foreach ( IDbDto dto in data.ResultDtoList ) {
					string id = (dto.Id ?? "");

					switch ( dto.Item ) {
						case DbDto.ItemType.Vertex:
							if ( vertexIdMap.ContainsKey(id) ) { continue; }
							vertexIdMap.Add(id, dto);
							verts.Add(dto);
							break;

						case DbDto.ItemType.Edge:
							if ( linkIdMap.ContainsKey(id) ) { continue; }
							linkIdMap.Add(id, dto);
							links.Add(dto);
							break;
					}
				}

				obj = new ExpandoObject();
				obj.verts = new List<ExpandoObject>();
				obj.links = new List<ExpandoObject>();

				vertexIdMap = new Dictionary<string, dynamic>();

				int vertexI = 1;
				var rand = new Random(999);

				dynamic vertexObj = new ExpandoObject();
				vertexObj.index = 0;
				vertexObj.x = vertexObj.y = 0.5;
				obj.verts.Add(vertexObj);

				foreach ( DbDto n in verts ) {
					vertexObj = new ExpandoObject();
					vertexObj.index = vertexI++;
					vertexObj.id = n.Id;
					vertexObj.Class = n.Class;
					vertexObj.name = n.Class;
					vertexObj.Data = "";

					vertexObj.x = rand.NextDouble()*0.5+0.25;
					vertexObj.y = rand.NextDouble()*0.5+0.25;

					if ( n.Data != null ) {
						foreach ( string key in n.Data.Keys ) {
							vertexObj.Data += "\n - "+key+": "+n.Data[key];
						}
					}

					/*if ( n.Data.ContainsKey("Name") ) {
						name += ": "+n.Data["Name"];
					}*/

					obj.verts.Add(vertexObj);
					vertexIdMap.Add(vertexObj.id, vertexObj);
				}

				foreach ( DbDto l in links ) {
					dynamic linkObj = new ExpandoObject();
					linkObj.id = l.Id;
					linkObj.type = ExtractEdgeType(l);

					if ( l.OutVertexId != null ) {
						linkObj.start = linkObj.source = vertexIdMap[l.OutVertexId].index;
					}

					if ( l.InVertexId != null ) {
						linkObj.end = linkObj.target = vertexIdMap[l.InVertexId].index;
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