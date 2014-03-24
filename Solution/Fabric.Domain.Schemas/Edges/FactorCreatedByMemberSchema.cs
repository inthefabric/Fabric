using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorCreatedByMemberSchema : EdgeSchema<FactorSchema, MemberSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorCreatedByMemberSchema() : base(EdgeQuantity.One) {
			SetNames("CreatedBy", "cb");
			CreateInternal = true;
		}

	}

}