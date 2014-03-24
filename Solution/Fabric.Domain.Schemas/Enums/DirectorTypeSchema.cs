namespace Fabric.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class DirectorTypeSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorTypeSchema() : base("DirectorType") {
			AddItem(1, "Hyperlink", "Hyperlink", "There is a hyperlink from the primary Artifact to the related Artifact.");
			AddItem(2, "DefinedPath", "Defined Path", "There is an expected, pre-defined path from the primary Artifact to the related Artifact.");
			AddItem(3, "SuggestedPath", "Suggested Path", "There is a suggested, recommented path from the primary Artifact to the related Artifact.");
			AddItem(4, "AvoidPath", "Avoid Path", "There is an unsuitable, non-recommented path from the primary Artifact to the related Artifact.");
			AddItem(5, "Causality", "Causality", "The primary Artifact causes an effect/action to occur upon the related Artifact.");
		}

	}

}