using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public interface IVertexSchema {

		NameProvider Names { get; }
		ActionProvider Actions { get; }
		bool IsInternal { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool IsSubObjectNullable(string pName);

	}

}