using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberDefinedByAppSchema : EdgeSchema<MemberSchema, AppSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberDefinedByAppSchema() : base(EdgeQuantity.One) {
			SetNames("DefinedBy", "db");
		}

	}

}