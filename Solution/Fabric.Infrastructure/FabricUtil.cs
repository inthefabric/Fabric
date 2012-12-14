﻿using System;
using Weaver;

namespace Fabric.Infrastructure {

	/*================================================================================================*/
	public static class FabricUtil {

		//Reduced bounds stop the Gremlin/Neo4j Java complaints
		public const double DoubleMin = double.MinValue+1E+294;
		public const double DoubleMax = double.MaxValue-1E+294;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string WeaverQueryToJson(WeaverQuery pQuery) {
			string json = "{\"script\":\""+JsonUnquote(pQuery.Script)+"\",\"params\":{";
			bool first = true;

			foreach ( string key in pQuery.Params.Keys ) {
				json += (first ? "" : ",")+"\""+JsonUnquote(key)+"\":\""+
					JsonUnquote(pQuery.Params[key])+"\"";
				first = false;
			}

			return json+"}}";
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string JsonUnquote(string pText) {
			return pText.Replace("\"", "\\\"");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string Code32 { get { return Guid.NewGuid().ToString("N"); } }

		/*--------------------------------------------------------------------------------------------*/
		public static string GetTypeDisplayName(Type pType) {
			switch ( pType.Name ) {
				case "Int32": return "int";
				case "Int64": return "long";
				case "Byte": return "byte";
				case "String": return "string";
				case "String[]": return "string[]";
				case "Boolean": return "bool";
				case "Single": return "float";
				case "Double": return "double";
				case "DateTime": return "long";
				case "Object": return "object";
			}

			throw new Exception("Unknown type: "+pType.Name);
		}

	}

}