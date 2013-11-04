using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class ArtifactCreatedByMemberSchema : EdgeSchema<ArtifactSchema, MemberSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactCreatedByMemberSchema() : base(EdgeQuantity.One) {
			Names = new NameProvider("CreatedByMember", "CreatedByMembers", "cbm");
		}

	}

}