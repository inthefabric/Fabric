using System;
using System.Collections.Generic;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure;
using Weaver.Interfaces;

namespace Fabric.Api.Server.Tables {

	/*================================================================================================*/
	public class TableNode {

		public DbDto Dto { get; set; }
		public int Index { get; set; }

		public Dictionary<string, List<DbDto>> InMap;
		public Dictionary<string, List<DbDto>> OutMap;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TableNode(DbDto pDto, int pIndex) {
			Dto = pDto;
			Index = pIndex;
			InMap = new Dictionary<string, List<DbDto>>();
			OutMap = new Dictionary<string, List<DbDto>>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddRelIn(DbDto pRel) {
			if ( !InMap.ContainsKey(pRel.Class) ) {
				InMap.Add(pRel.Class, new List<DbDto>());
			}

			InMap[pRel.Class].Add(pRel);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddRelOut(DbDto pRel) {
			if ( !OutMap.ContainsKey(pRel.Class) ) {
				OutMap.Add(pRel.Class, new List<DbDto>());
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
				string rk = GetRelKey(OutMap[key][0], true);
				if ( pColMap.ContainsKey(rk) ) { continue; }
				pColMap.Add(rk, pColMap.Keys.Count);
			}

			foreach ( string key in InMap.Keys ) {
				string rk = GetRelKey(InMap[key][0], false);
				if ( pColMap.ContainsKey(rk) ) { continue; }
				pColMap.Add(rk, pColMap.Keys.Count);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetRelKey(DbDto pRel, bool pIsOutgoing) {
			string name = pRel.Class;
			object o = Activator.CreateInstance("Fabric.Domain", "Fabric.Domain."+name).Unwrap();
			
			IWeaverRel r = (o as IWeaverRel);
			if ( r == null ) { return name; }

			string lbl = r.RelType.Label;
			int lblI = name.IndexOf(lbl);
			string node;

			if ( pIsOutgoing ) {
				node = name.Substring(lblI+lbl.Length);
				return "OUT&gt; "+lbl+" "+node;
			}
			
			node = name.Substring(0, lblI);
			return "&lt;IN "+node+" "+lbl;
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
				HtmlUtil.Wrap("td", Dto.Class)+
				HtmlUtil.Wrap("td", Dto.Id+"");

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
			Dictionary<string, List<DbDto>> map = (pIsOut ? OutMap : InMap);

			foreach ( string key in map.Keys ) {
				List<DbDto> dtos = map[key];
				string rk = GetRelKey(dtos[0], pIsOut);
				var nodeIds = new List<string>();

				foreach ( DbDto dto in dtos ) {
					nodeIds.Add((pIsOut ? dto.ToNodeId : dto.FromNodeId)+"");
				}

				pDataCols[pColMap[rk]-2] = string.Join(" ", nodeIds);
			}
		}

	}

}