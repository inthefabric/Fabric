namespace Fabric.New.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class EnumItemSchema : IEnumItemSchema {

		public byte Id { get; private set; }
		public string EnumId { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EnumItemSchema(byte pId, string pEnumId, string pName, string pDesc) {
			Id = pId;
			EnumId = pEnumId;
			Name = pName;
			Description = pDesc;
		}

	}

}