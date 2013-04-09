namespace Fabric.Infrastructure.Domain.Types {

	/*================================================================================================*/
	public interface IBaseType {

		byte Id { get; }
		string EnumId { get; }
		string Name { get; }
		string Description { get; }

	}

}