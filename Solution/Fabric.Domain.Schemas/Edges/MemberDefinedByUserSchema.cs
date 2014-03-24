using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberDefinedByUserSchema : EdgeSchema<MemberSchema, UserSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberDefinedByUserSchema() : base(EdgeQuantity.One) {
			SetNames("DefinedBy", "db");
		}

	}

}