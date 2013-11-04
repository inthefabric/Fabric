using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberDefinedByAppSchema : EdgeSchema<MemberSchema, AppSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberDefinedByAppSchema() : base(EdgeQuantity.One) {
			Names = new NameProvider("DefinedByApp", "DefinedByApps", "dba");
			TypeName = "DefinedBy";
		}

	}

}