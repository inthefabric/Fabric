namespace Fabric.New.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class DescriptorTypeSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DescriptorTypeSchema() : base("DescriptorType") {
			AddItem(1, "IsRelatedTo", "Is Related To", "The primary Artifact is related to the related Artifact in some way. This is the default (and least meaningful) DescriptorType.");
			AddItem(2, "IsA", "Is (A/An)", "The primary Artifact is a type of, a subclass of, a subset of, a subordinate of, or in the category defined by the related Artifact.");
			AddItem(3, "IsAnInstanceOf", "Is An Instance Of", "The primary Artifact is an instance, case, example, or representation of the related Artifact.");
			AddItem(4, "HasA", "Has (A/An)", "The primary Artifact has, as a part, piece, feature, attribute, or component, the related Artifact.");
			AddItem(5, "IsLike", "Is Like", "The primary Artifact is like or similar to the related Artifact.");
			AddItem(6, "IsNotLike", "Is Not Like", "The primary Artifact is not like or not similar to the related Artifact");
			AddItem(7, "RefersTo", "Refers To", "The primary Artifact refers to, mentions, discusses, links to, or references the related Artifact.");
			AddItem(8, "IsCreatedBy", "Is Created By", "The primary Artifact is created, built, designed, invented, formed, or performed by the related Artifact.");
			AddItem(9, "IsInterestedIn", "Is Interested In", "The primary Artifact is interested in, fond of, attracted to, enjoys, prefers, or desires the related Artifact.");
			AddItem(10, "Receives", "Receives", "The primary Artifact receives, gets, obtains, or is awarded the related Artifact.");
			AddItem(11, "Consumes", "Consumes", "The primary Artifact consumes, eats, is powered by, uses up, depletes, or destroys the related Artifact.");
			AddItem(12, "Produces", "Produces", "The primary Artifact produces, has a byproduct of, creates, or generates the related Artifact. This is similar to 'Is Created By', but in the opposite direction and meant to be less specific.");
			AddItem(13, "ParticipatesIn", "Participates In", "The primary Artifact participates in, competes in, attends, is a member of, or is involved in the related Artifact.");
			AddItem(14, "IsFoundIn", "Is Found In", "The primary Artifact is found in, located at, lives in, or is contained by the related Artifact.");
			AddItem(15, "BelongsTo", "Belongs To", "The primary Artifact belongs to, is controlled by, or is owned by the related Artifact.");
			AddItem(16, "Requires", "Requires", "The primary Artifact requires, implies, needs, or demands the related Artifact.");
			AddItem(17, "InteractsWith", "Interacts With", "The primary Artifact interacts, associates, combines, meets, or communicates with the related Artifact.");
			AddItem(18, "LooksLike", "Looks Like", "The primary Artifact looks like (has the appearance of) the related Artifact.");
			AddItem(19, "SmellsLike", "Smells Like", "The primary Artifact smells like (has the odor, aroma, or fragrance of) the related Artifact.");
			AddItem(20, "TastesLike", "Tastes Like", "The primary Artifact tastes like (has the flavor of) the related Artifact.");
			AddItem(21, "SoundsLike", "Sounds Like", "The primary Artifact sounds like (has the aural characteristics of) the related Artifact.");
			AddItem(22, "FeelsLike", "Feels Like", "The primary Artifact feels like (has the tactile characteristics of) the related Artifact.");
			AddItem(23, "EmotesLike", "Emotes Like", "The primary Artifact emotes like (causes the emotion of) the related Artifact.");
			AddItem(24, "Uses", "Uses", "The primary Artifact uses, utilizes, controls, employs, or manipulates the related Artifact.");
		}

	}

}