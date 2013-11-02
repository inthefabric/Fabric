using Fabric.Domain.Meta.Vertices.Tools;

namespace Fabric.Domain.Meta.Vertices {
	
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