using System;
using System.Collections.Generic;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using Nancy.Responses.Negotiation;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Server.Tables {

	/*================================================================================================*/
	public class TableBrowser {

		private readonly NancyModule vModule;

		private IList<IDbDto> vDtos;
		private IDictionary<long, TableNode> vNodes;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TableBrowser(NancyModule pModule) {
			vModule = pModule;
		}

		/*--------------------------------------------------------------------------------------------*/
		public Negotiator GetResponse() {
			var model = new TableModel();
			var ctx = new ApiContext("http://localhost:9001/");

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
				return pData.ResultString;
			}

			////

			vNodes = new Dictionary<long, TableNode>();

			foreach ( DbDto dto in vDtos ) {
				if ( dto.Id == null || dto.Item != DbDto.ItemType.Node ) { continue; }
				vNodes.Add((long)dto.Id, new TableNode(dto, vNodes.Count));
			}

			foreach ( DbDto dto in vDtos ) {
				if ( dto.Id == null || dto.ToNodeId == null || dto.FromNodeId == null ) { continue; }
				if ( dto.Item != DbDto.ItemType.Rel ) { continue; }

				TableNode toNode, fromNode;
				vNodes.TryGetValue((long)dto.ToNodeId, out toNode);
				vNodes.TryGetValue((long)dto.FromNodeId, out fromNode);

				if ( toNode != null ) {
					toNode.AddRelIn(dto);
				}

				if ( fromNode != null ) {
					fromNode.AddRelOut(dto);
				}
			}

			////
			
			var colMap = new Dictionary<string, int>();
			colMap.Add("Class", 0);
			colMap.Add("NodeId", 1);

			foreach ( TableNode n in vNodes.Values ) {
				n.AddNewDataKeys(colMap);
			}

			////

			string html = "<table><thead><tr>";

			foreach ( string key in colMap.Keys ) {
				html += "<th>"+key+"</th>";
			}

			html += "</tr></thead><tbody>";

			foreach ( TableNode n in vNodes.Values ) {
				html += n.ToHtmlRow(colMap);
			}

			return html+"</tbody></table>";
		}

	}

}