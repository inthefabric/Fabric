using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class ArtifactCreatedByMemberSchema : EdgeSchema<ArtifactSchema, MemberSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactCreatedByMemberSchema() : base(EdgeQuantity.One) {
			SetNames("CreatedBy", "cb");
			CreateInternal = true;
		}

	}

}