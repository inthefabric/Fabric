using System;
using Weaver.Schema;

namespace Fabric.Infrastructure.Domain {

	/*================================================================================================*/
	public class SchemaHelperProp {
		
		public WeaverPropSchema PropSchema { get; private set; }

		public string TypeName { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperProp(WeaverPropSchema pProp) {
			PropSchema = pProp;
			TypeName = GetTypeName(PropSchema.Type, (PropSchema.IsNullable == true));
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string GetTypeName(Type pType, bool pIsNullable=false) {
			var n = "";

			switch ( pType.Name ) {
				case "Int32": n = "int"; break;
				case "Int64": n = "long"; break;
				case "Byte": n = "byte"; break;
				case "String": n = "string"; break;
				case "String[]": n = "string[]"; break;
				case "Boolean": n = "bool"; break;
				case "Single": n = "float"; break;
				case "Double": n = "double"; break;
				case "DateTime": n = "long"; break;
				case "Object": n = "object"; break;
				default: n = pType.Name; break;
			}

			if ( pIsNullable && pType.IsValueType ) {
				n += "?";
			}

			return n;
		}

	}

}