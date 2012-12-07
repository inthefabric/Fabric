using System;
using System.Collections.Generic;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Nancy;
using Nancy.Responses.Negotiation;

namespace Fabric.Api.Server.Tables {

	/*================================================================================================*/
	public class TableBrowser {

		private readonly NancyModule vModule;

		private List<DbDto> vDtos;
		private Dictionary<long, TableNode> vNodes;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TableBrowser(NancyModule pModule) {
			vModule = pModule;
		}

		/*--------------------------------------------------------------------------------------------*/
		public Negotiator GetResponse() {
			var model = new TableModel();

			try {
				string table = vModule.Context.Request.Path;
				table = table.Substring(table.LastIndexOf('/')+1);

				string query = "x=[];";
				query += "g.V.filter{it.getProperty('"+table+"Id') != null}.aggregate(x).iterate();";
				query += "g.V.retain(x).bothE.aggregate(x).iterate();";
				query += "x;";

				var req = new GremlinRequest(query);
				model.TableHtml = BuildHtml(req);
			}
			catch ( Exception ex ) {
				Log.Error("TableBrowser error", ex);
				model.TableHtml = "Error: "+ex.Message;
			}

			return vModule.View["tables/index.html", model];
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string BuildHtml(GremlinRequest pReq) {
			vDtos = pReq.DtoList;
			
			if ( pReq.Dto != null ) {
				vDtos = new List<DbDto>();
				vDtos.Add(pReq.Dto);
			}

			if ( vDtos == null ) {
				return pReq.ResponseString;
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