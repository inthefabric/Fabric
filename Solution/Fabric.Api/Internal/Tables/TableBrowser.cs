using System;
using System.Collections.Generic;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Nancy;
using Nancy.Responses.Negotiation;
using Weaver.Core.Query;

namespace Fabric.Api.Internal.Tables {

	/*================================================================================================*/
	public class TableBrowser {

		private readonly NancyModule vModule;

		private IList<DbDto> vDtos;
		private IDictionary<string, TableVertex> vVertices;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TableBrowser(NancyModule pModule) {
			vModule = pModule;
		}

		/*--------------------------------------------------------------------------------------------*/
		public Negotiator GetResponse() {
			var model = new TableModel();
			var ctx = new ApiContext("localhost", 8185, null);

			try {
				string table = vModule.Context.Request.Path.Substring("/tables/browse/".Length);
				string[] parts = table.Split('/');
				table = parts[0];

				string query = "x=[];";

				if ( parts.Length == 2 ) {
					//query += "g.idx('"+table+"').get('"+table+"Id', "+parts[1]+
					//	").aggregate(x).iterate();";
					query += "g.v("+parts[1]+").aggregate(x).iterate();";
				}
				else {
					query += "g.V.filter{it.getProperty('"+
						table+"Id') != null}.aggregate(x).iterate();";
				}

				query += "g.V.retain(x).bothE.aggregate(x).iterate();";
				query += "x";

				IWeaverQuery q = new WeaverQuery();
				q.FinalizeQuery(query);
				IApiDataAccess data = ctx.DbData("getTable", q);
				model.TableHtml = BuildHtml(data);
			}
			catch ( Exception ex ) {
				Log.Error("TableBrowser error", ex);
				model.TableHtml = "Error: "+ex.Message;
			}

			return vModule.View["tables/index.html", model];
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string BuildHtml(IApiDataAccess pData) {
			vDtos = pData.Result.DbDtos;

			if ( vDtos == null ) {
				return pData.ResponseJson;
			}

			////

			vVertices = new Dictionary<string, TableVertex>();

			foreach ( IDbDto dto in vDtos ) {
				if ( dto.Id == null || dto.Item != DbDto.ItemType.Vertex ) { continue; }
				vVertices.Add(dto.Id, new TableVertex(dto, vVertices.Count));
			}

			foreach ( IDbDto dto in vDtos ) {
				if ( dto.Id == null || dto.InVertexId == null || dto.OutVertexId == null ) { continue; }
				if ( dto.Item != DbDto.ItemType.Rel ) { continue; }

				TableVertex toVertex, fromVertex;
				vVertices.TryGetValue(dto.InVertexId, out toVertex);
				vVertices.TryGetValue(dto.OutVertexId, out fromVertex);

				if ( toVertex != null ) {
					toVertex.AddRelIn(dto);
				}

				if ( fromVertex != null ) {
					fromVertex.AddRelOut(dto);
				}
			}

			////
			
			var colMap = new Dictionary<string, int>();
			colMap.Add("Class", 0);
			colMap.Add("VertexId", 1);

			foreach ( TableVertex n in vVertices.Values ) {
				n.AddNewDataKeys(colMap);
			}

			////

			string html = "<table><thead><tr>";

			foreach ( string key in colMap.Keys ) {
				html += "<th>"+key+"</th>";
			}

			html += "</tr></thead><tbody>";

			foreach ( TableVertex n in vVertices.Values ) {
				html += n.ToHtmlRow(colMap);
			}

			return html+"</tbody></table>";
		}

	}

}