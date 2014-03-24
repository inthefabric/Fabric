namespace Fabric.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class FactorAssertionSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorAssertionSchema() : base("FactorAssertion") {
			AddItem(1, "Undefined", "Undefined", "The Factor's assertion type is not known or not defined.");
			AddItem(2, "Fact", "Fact", "The Factor represents a factual statement.");
			AddItem(3, "Opinion", "Opinion", "The Factor represents an opinion.");
			AddItem(4, "Guess", "Guess", "The Factor represents a guess.");
		}

	}

}