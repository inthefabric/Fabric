using Fabric.Domain.Schemas.Utils;

namespace Fabric.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class ArtifactSchema : VertexSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactSchema() {
			Names = new NameProvider("Artifact", "Artifacts", "a");
			GetAccess = Access.All;
			CreateAccess = Access.Custom;
			DeleteAccess = Access.Custom;
			IsAbstract = true;
		}

	}

}