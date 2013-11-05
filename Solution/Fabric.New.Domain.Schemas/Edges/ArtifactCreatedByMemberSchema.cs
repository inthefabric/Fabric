using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class ArtifactCreatedByMemberSchema : EdgeSchema<ArtifactSchema, MemberSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactCreatedByMemberSchema() : base(EdgeQuantity.One) {
			SetNames("CreatedBy", "cb");
		}

	}

}