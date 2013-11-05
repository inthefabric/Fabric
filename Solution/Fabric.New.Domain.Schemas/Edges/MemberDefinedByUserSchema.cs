using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberDefinedByUserSchema : EdgeSchema<MemberSchema, UserSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberDefinedByUserSchema() : base(EdgeQuantity.One) {
			SetNames("DefinedBy", "db");
		}

	}

}