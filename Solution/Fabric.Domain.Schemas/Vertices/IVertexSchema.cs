using Fabric.Domain.Schemas.Utils;

namespace Fabric.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public interface IVertexSchema {

		NameProvider Names { get; }
		Access GetAccess { get; }
		Access CreateAccess { get; }
		Access DeleteAccess { get; }
		bool IsAbstract { get; }
		bool CustomCreate { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool IsSubObjectNullable(string pName);

		/*--------------------------------------------------------------------------------------------*/
		bool IsSpecInternal(Access pLevel);

	}

}