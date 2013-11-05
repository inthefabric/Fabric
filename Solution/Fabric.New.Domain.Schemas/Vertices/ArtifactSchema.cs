using Fabric.New.Domain.Schemas.Edges;
using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class ArtifactSchema : VertexSchema {

		public ArtifactCreatedByMemberSchema CreatedByMember { get; private set; }
		public ArtifactUsedAsPrimaryByFactor UsedAsPrimaryByFactor { get; private set; }
		public ArtifactUsedAsRelatedByFactor UsedAsRelatedByFactor { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactSchema() {
			Names = new NameProvider("Artifact", "Artifacts", "a");

			////

			//CreatedByMember = new ArtifactCreatedByMemberSchema();
			//UsedAsPrimaryByFactor = new ArtifactUsedAsPrimaryByFactor();
			//UsedAsRelatedByFactor = new ArtifactUsedAsRelatedByFactor();
		}

	}

}