namespace Fabric.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class VectorRangeLevelSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelSchema() : base("VectorRangeLevel") {
			AddItem(1, "Zero0", "Zero", "", 0);
			AddItem(2, "Zero05", "Zero", "", 1/2f);
			AddItem(3, "Zero1", "Zero", "", 1);

			AddItem(4, "Min0", "Minimum", "", 0);
			AddItem(5, "Max1", "Maximum", "", 1);

			AddItem(6, "CompDisagree", "Completely Disagree", "", 0);
			AddItem(7, "MostDisagree", "Mostly Disagree", "", 1/6f);
			AddItem(8, "SomeDisagree", "Somewhat Disagree", "", 2/6f);
			AddItem(9, "NoOpinion05", "No Opinion", "", 3/6f);
			AddItem(10, "SomeAgree", "Somewhat Agree", "", 4/6f);
			AddItem(11, "MostAgree", "Mostly Agree", "", 5/6f);
			AddItem(12, "CompAgree", "Completely Agree", "", 1);

			AddItem(13, "NoOpinion0", "No Opinion", "", 0);
			AddItem(14, "SomeAgreePos", "Somewhat Agree", "", 1/3f);
			AddItem(15, "MostAgreePos", "Mostly Agree", "", 2/3f);
			AddItem(16, "CompAgreePos", "Completely Agree", "", 1);

			AddItem(17, "CompUnfavor", "Completely Unfavorable", "", 0);
			AddItem(18, "MostUnfavor", "Mostly Unfavorable", "", 1/6f);
			AddItem(19, "SomeUnfavor", "Somewhat Unfavorable", "", 2/6f);
			AddItem(20, "SomeFavor", "Somewhat Favorable", "", 4/6f);
			AddItem(21, "MostFavor", "Mostly Favorable", "", 5/6f);
			AddItem(22, "CompFavor", "Completely Favorable", "", 1);

			AddItem(23, "SomeFavorPos", "Somewhat Favorable", "", 1/3f);
			AddItem(24, "MostFavorPos", "Mostly Favorable", "", 2/3f);
			AddItem(25, "CompFavorPos", "Completely Favorable", "", 1);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void AddItem(byte pId, string pEnumId, string pName, string pDesc, float pPosition) {
			Items.Add(new VectorRangeLevelItemSchema(pId, pEnumId, pName, pDesc, pPosition));
		}

	}


	/*================================================================================================*/
	public class VectorRangeLevelItemSchema : EnumItemSchema {

		public float Position { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeLevelItemSchema(byte pId, string pEnumId, string pName, string pDesc,
												float pPosition) : base(pId, pEnumId, pName, pDesc) {
			Position = pPosition;
		}

	}

}