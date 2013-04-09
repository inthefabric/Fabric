using System;
using Weaver.Schema;

namespace Fabric.Domain.Meta {

	/*================================================================================================*/
	public class SchemaHelperProp {
		
		public FabricPropSchema PropSchema { get; private set; }

		public string TypeName { get; private set; }
		public string SubPropName { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperProp(FabricPropSchema pProp) {
			PropSchema = pProp;
			TypeName = GetTypeName(PropSchema.Type, (PropSchema.IsNullable == true));

			if ( IsSubProp() ) {
				SubPropName = PropSchema.Name.Split('_')[1];
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool IsSubProp() {
			return (PropSchema.Name.IndexOf('_') != -1);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string GetTypeName(Type pType, bool pIsNullable=false) {
			var n = "";

			switch ( pType.Name ) {
				case "Int32":
					n = "int";
					break;

				case "Int64":
					n = "long";
					break;

				case "Byte":
					n = "byte";
					break;

				case "String":
					n = "string";
					break;

				case "String[]":
					n = "string[]";
					break;

				case "Boolean":
					n = "bool";
					break;

				case "Single":
					n = "float";
					break;

				case "Double":
					n = "double";
					break;

				case "DateTime":
					n = "long";
					break;

				case "Object":
					n = "object";
					break;

				case "IList`1":
				case "List`1":
					n = GetTypeName(pType.GetGenericArguments()[0])+"[]";
					break;

				case "Nullable`1":
					n = GetTypeName(pType.GetGenericArguments()[0])+"?";
					break;

				default:
					n = pType.Name;
					break;
			}

			if ( pIsNullable && pType.IsValueType ) {
				n += "?";
			}

			return n;
		}

	}

}