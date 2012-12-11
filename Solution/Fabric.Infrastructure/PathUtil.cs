﻿using Weaver.Items;
using Weaver.Schema;

namespace Fabric.Infrastructure {

	/*================================================================================================*/
	public static class PathUtil {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string GetRelInterface(WeaverRelSchema pRel, bool pIsOut) {
			bool isMany = IsRelMany(pRel, pIsOut);
			string manyStr = (isMany ? "List" : "");

			if ( pIsOut ) {
				return "I"+pRel.Name+pRel.ToNode.Name+manyStr;
			}

			return "IIn"+pRel.FromNode.Name+pRel.Name+manyStr;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetRelPropType(WeaverRelSchema pRel, bool pIsOut) {
			return (pIsOut ? pRel.ToNode.Name : pRel.FromNode.Name);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetRelProp(WeaverRelSchema pRel, bool pIsOut, bool pShort=false) {
			bool isMany = IsRelMany(pRel, pIsOut);
			string manyStr = (isMany ? "List" : "");
			string fromNode, toNode;

			if ( pShort ) {
				fromNode = (pIsOut ? "" : pRel.FromNode.Short+manyStr);
				toNode = (!pIsOut ? "" : pRel.ToNode.Short+manyStr);
			}
			else {
				fromNode = (pIsOut ? "" : pRel.FromNode.Name+manyStr);
				toNode = (!pIsOut ? "" : pRel.ToNode.Name+manyStr);
			}

			return (pIsOut ? "" : "In") + fromNode + pRel.Name + toNode;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static bool IsRelMany(WeaverRelSchema pRel, bool pIsOut) {
			if ( pIsOut ) {
				return (pRel.FromNodeConn == WeaverRelConn.OutToOneOrMore ||
					pRel.FromNodeConn == WeaverRelConn.OutToZeroOrMore);
			}

			return (pRel.ToNodeConn == WeaverRelConn.InFromOneOrMore ||
				pRel.ToNodeConn == WeaverRelConn.InFromZeroOrMore);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetRelLabel(WeaverRelSchema pRel) {
			return pRel.FromNode.Name + pRel.Name + pRel.ToNode.Name;
		}

	}

}