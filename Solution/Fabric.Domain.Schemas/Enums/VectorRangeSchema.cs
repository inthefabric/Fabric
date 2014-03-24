using System.Collections.Generic;

namespace Fabric.New.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class VectorRangeSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeSchema() : base("VectorRange") {
			VectorRangeItemSchema i;
			
			i = AddItem(1, "FullNum", "Full Numeric", "");
			i.Levels.Add("Min0");
			i.Levels.Add("Zero05");
			i.Levels.Add("Max1");

			i = AddItem(2, "PosNum", "Positive Numeric", "");
			i.Levels.Add("Zero0");
			i.Levels.Add("Max1");

			i = AddItem(3, "NegNum", "Negative Numeric", "");
			i.Levels.Add("Min0");
			i.Levels.Add("Zero1");

			i = AddItem(4, "FullAgree", "Full Agreement", "");
			i.Levels.Add("CompDisagree");
			i.Levels.Add("MostDisagree");
			i.Levels.Add("SomeDisagree");
			i.Levels.Add("NoOpinion05");
			i.Levels.Add("SomeAgree");
			i.Levels.Add("MostAgree");
			i.Levels.Add("CompAgree");

			i = AddItem(5, "PosAgree", "Positive Agreement", "");
			i.Levels.Add("NoOpinion0");
			i.Levels.Add("SomeAgreePos");
			i.Levels.Add("MostAgreePos");
			i.Levels.Add("CompAgreePos");

			i = AddItem(6, "FullFavor", "Full Favorability", "");
			i.Levels.Add("CompUnfavor");
			i.Levels.Add("MostUnfavor");
			i.Levels.Add("SomeUnfavor");
			i.Levels.Add("NoOpinion05");
			i.Levels.Add("SomeFavor");
			i.Levels.Add("MostFavor");
			i.Levels.Add("CompFavor");

			i = AddItem(7, "PosFavor", "Positive Favorability", "");
			i.Levels.Add("NoOpinion0");
			i.Levels.Add("SomeFavorPos");
			i.Levels.Add("MostFavorPos");
			i.Levels.Add("CompFavorPos");
		}

		/*--------------------------------------------------------------------------------------------*/
		private new VectorRangeItemSchema AddItem(byte pId, string pEnumId, string pName, string pDesc){
			var i = new VectorRangeItemSchema(pId, pEnumId, pName, pDesc);
			Items.Add(i);
			return i;
		}

	}


	/*================================================================================================*/
	public class VectorRangeItemSchema : EnumItemSchema {

		[EnumRef("VectorRangeLevel[]")]
		public IList<string> Levels { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VectorRangeItemSchema(byte pId, string pEnumId, string pName, string pDesc) : 
																	base(pId, pEnumId, pName, pDesc) {
			Levels = new List<string>();
		}

	}

}