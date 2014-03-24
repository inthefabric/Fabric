using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberDefinedByAppSchema : EdgeSchema<MemberSchema, AppSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberDefinedByAppSchema() : base(EdgeQuantity.One) {
			SetNames("DefinedBy", "db");
		}

	}

}