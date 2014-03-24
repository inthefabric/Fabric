using System.Collections.Generic;

namespace Fabric.New.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class EnumSchema : IEnumSchema {

		public string Name { get; private set; }
		public IList<IEnumItemSchema> Items { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EnumSchema(string pName) {
			Name = pName;
			Items = new List<IEnumItemSchema>();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void AddItem(byte pId, string pEnumId, string pName, string pDesc) {
			Items.Add(new EnumItemSchema(pId, pEnumId, pName, pDesc));
		}

	}

}