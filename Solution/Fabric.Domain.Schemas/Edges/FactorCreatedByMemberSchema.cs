using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
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