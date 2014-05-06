namespace Fabric.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class IdentorTypeSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdentorTypeSchema() : base("IdentorType") {
			AddItem(1, "Text", "Text", "A value (a string, typically a name).");
			AddItem(2, "Key", "Key", "A value (numeric or otherwise) representing a unique key or ID.");
		}

	}

}