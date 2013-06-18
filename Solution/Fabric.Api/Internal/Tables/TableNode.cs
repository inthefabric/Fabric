using System;
using System.Collections.Generic;
using Fabric.Api.Util;
using Fabric.Infrastructure.Db;
using Weaver.Core.Elements;

namespace Fabric.Api.Internal.Tables {

	/*================================================================================================*/
	public class TableVertex {

		public IDbDto Dto { get; set; }
		public int Index { get; set; }

		public Dictionary<string, List<IDbDto>> InMap { get; private set; }
		public Dictionary<string, List<IDbDto>> OutMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TableVertex(IDbDto pDto, int pIndex) {
			Dto = pDto;
			Index = pIndex;
			InMap = new Dictionary<string, List<IDbDto>>();
			OutMap = new Dictionary<string, List<IDbDto>>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddRelIn(IDbDto pRel) {
			if ( !InMap.ContainsKey(pRel.Class) ) {
				InMap.Add(pRel.Class, new List<IDbDto>());
			}

			InMap[pRel.Class].Add(pRel);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddRelOut(IDbDto pRel) {
			if ( !OutMap.ContainsKey(pRel.Class) ) {
				OutMap.Add(pRel.Class, new List<IDbDto>());
			}

			OutMap[pRel.Class].Add(pRel);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddNewDataKeys(Dictionary<string, int> pColMap) {
			if ( Dto.Data != null ) {
				foreach ( string key in Dto.Data.Keys ) {
					if ( pColMap.ContainsKey(key) ) { continue; }
					pColMap.Add(key, pColMap.Keys.Count);
				}
			}

			foreach ( string key in OutMap.Keys ) {
				string rk = GetEdgeKey(OutMap[key][0], true);
				if ( pColMap.ContainsKey(rk) ) { continue; }
				pColMap.Add(rk, pColMap.Keys.Count);
			}

			foreach ( string key in InMap.Keys ) {
				string rk = GetEdgeKey(InMap[key][0], false);
				if ( pColMap.ContainsKey(rk) ) { continue; }
				pColMap.Add(rk, pColMap.Keys.Count);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetEdgeKey(IDbDto pRel, bool pIsOutgoing) {
			string name = pRel.Class;
			object o = Activator.CreateInstance("Fabric.Domain", "Fabric.Domain."+name).Unwrap();
			
			IWeaverEdge r = (o as IWeaverEdge);
			if ( r == null ) { return name; }

			string lbl = r.EdgeType.Label;
			int lblI = name.IndexOf(lbl);
			string vertex;

			if ( pIsOutgoing ) {
				vertex = name.Substring(lblI+lbl.Length);
				return "OUT&gt; "+lbl+" "+vertex;
			}
			
			vertex = name.Substring(0, lblI);
			return "&lt;IN "+vertex+" "+lbl;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string ToHtmlRow(Dictionary<string, int> pColMap) {
			return "<tr"+(Index%2 == 1 ? " class='odd'" : "")+">"+
				ToHtmlCells(pColMap)+"</tr>";
		}

		/*--------------------------------------------------------------------------------------------*/
		private string ToHtmlCells(Dictionary<string, int> pColMap) {
			string html =
				HtmlUtil.Wrap("td", "<a href='/tables/browse/"+Dto.Class+"'>"+Dto.Class+"</a>")+
				//HtmlUtil.Wrap("td", "<a href='/tables/browse/"+Dto.Class+"/"+Dto.Id+"'>"+Dto.Id+"</a>");
				HtmlUtil.Wrap("td", "<a href='/tables/browse/vertex/"+Dto.Id+"'>"+Dto.Id+"</a>");

			var cols = new string[pColMap.Keys.Count-2];

			FillDataCols(cols, pColMap);
			FillRelCols(cols, pColMap, true);
			FillRelCols(cols, pColMap, false);

			foreach ( string item in cols ) {
				html += HtmlUtil.Wrap("td", item);
			}

			return html;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void FillDataCols(string[] pDataCols, Dictionary<string, int> pColMap) {
			if ( Dto.Data == null ) {
				return;
			}

			foreach ( string key in Dto.Data.Keys ) {
				var data = Dto.Data[key];

				if ( !String.IsNullOrEmpty(data) ) {
					if ( key.IndexOf("Timestamp") >= 0 ) {
						long ticks = long.Parse(data);
						data = new DateTime(ticks).ToString("yyyy-MM-dd HH:mm:ss.fff");
					}
				}

				pDataCols[pColMap[key]-2] = data;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void FillRelCols(string[] pDataCols, Dictionary<string, int> pColMap, bool pIsOut) {
			Dictionary<string, List<IDbDto>> map = (pIsOut ? OutMap : InMap);

			foreach ( string key in map.Keys ) {
				List<IDbDto> dtos = map[key];
				string rk = GetEdgeKey(dtos[0], pIsOut);
				var vertexIds = new List<string>();

				foreach ( DbDto dto in dtos ) {
					string vertexId = (pIsOut ? dto.InVertexId : dto.OutVertexId)+"";
					/*string[] relNameParts = rk.Split(' ');
					int relNameI = (pIsOut ? relNameParts.Length-1 : 1);
					string vertexClass = relNameParts[relNameI];
					vertexIds.Add("<a href='/tables/browse/"+vertexClass+"/"+vertexId+"'>"+vertexId+"</a>");*/
					vertexIds.Add("<a href='/tables/browse/vertex/"+vertexId+"'>"+vertexId+"</a>");
				}

				pDataCols[pColMap[rk]-2] = string.Join(" ", vertexIds);
			}
		}

	}

}