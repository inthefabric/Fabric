namespace Fabric.Domain.Schemas.Enums {

	/*================================================================================================*/
	public interface IEnumItemSchema {

		byte Id { get; }
		string EnumId { get; }
		string Name { get; }
		string Description { get; }

	}

}