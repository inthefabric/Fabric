using Weaver.Schema;

namespace Fabric.Domain {

	/*================================================================================================*/
	public class SchemaHelperProp {
		
		public WeaverPropSchema PropSchema { get; private set; }

		public string TypeName { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperProp(WeaverPropSchema pProp) {
			PropSchema = pProp;

			switch ( PropSchema.Type.Name ) {
				case "Int32": TypeName = "int"; break;
				case "Int64": TypeName = "long"; break;
				case "Byte": TypeName = "byte"; break;
				case "String": TypeName = "string"; break;
				case "String[]": TypeName = "string[]"; break;
				case "Boolean": TypeName = "bool"; break;
				case "Single": TypeName = "float"; break;
				case "Double": TypeName = "double"; break;
				case "DateTime": TypeName = "long"; break;
				case "Object": TypeName = "object"; break;
				default: TypeName = PropSchema.Type.Name; break;
			}

			if ( PropSchema.IsNullable == true && PropSchema.Type.IsValueType ) {
				TypeName += "?";
			}
		}

	}

}