﻿using System;
using System.Collections.Generic;
using Fabric.Api.Server.Util;
using Fabric.Infrastructure.Db;
using Weaver.Interfaces;

namespace Fabric.Api.Server.Tables {

	/*================================================================================================*/
	public class TableNode {

		public IDbDto Dto { get; set; }
		public int Index { get; set; }

		public Dictionary<string, List<IDbDto>> InMap { get; private set; }
		public Dictionary<string, List<IDbDto>> OutMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TableNode(IDbDto pDto, int pIndex) {
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
		private string GetRelKey(IDbDto pRel, bool pIsOutgoing) {
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
				HtmlUtil.Wrap("td", "<a href='/tables/browse/"+Dto.Class+"'>"+Dto.Class+"</a>")+
				//HtmlUtil.Wrap("td", "<a href='/tables/browse/"+Dto.Class+"/"+Dto.Id+"'>"+Dto.Id+"</a>");
				HtmlUtil.Wrap("td", "<a href='/tables/browse/node/"+Dto.NodeId+"'>"+Dto.NodeId+"</a>");

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
				string rk = GetRelKey(dtos[0], pIsOut);
				var nodeIds = new List<string>();

				foreach ( DbDto dto in dtos ) {
					string nodeId = (pIsOut ? dto.ToNodeId : dto.FromNodeId)+"";
					/*string[] relNameParts = rk.Split(' ');
					int relNameI = (pIsOut ? relNameParts.Length-1 : 1);
					string nodeClass = relNameParts[relNameI];
					nodeIds.Add("<a href='/tables/browse/"+nodeClass+"/"+nodeId+"'>"+nodeId+"</a>");*/
					nodeIds.Add("<a href='/tables/browse/node/"+nodeId+"'>"+nodeId+"</a>");
				}

				pDataCols[pColMap[rk]-2] = string.Join(" ", nodeIds);
			}
		}

	}

}