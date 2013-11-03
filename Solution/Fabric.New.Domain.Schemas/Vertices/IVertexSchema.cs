using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public interface IVertexSchema {

		NameProvider Names { get; }
		Access GetAccess { get; }
		Access DeleteAccess { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool IsSubObjectNullable(string pName);

	}

}