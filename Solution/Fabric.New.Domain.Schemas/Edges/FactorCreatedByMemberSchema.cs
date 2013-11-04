using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorCreatedByMemberSchema : EdgeSchema<FactorSchema, MemberSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorCreatedByMemberSchema() : base(EdgeQuantity.One) {
			Names = new NameProvider("CreatedByMember", "CreatedByMembers", "cbm");
			TypeName = "CreatedBy";
		}

	}

}