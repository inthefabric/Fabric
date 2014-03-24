namespace Fabric.New.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class VertexTypeSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexTypeSchema() : base("VertexType") {
			AddItem(1, "Vertex", "Vertex", "");
			AddItem(2, "App", "App", "");
			AddItem(3, "Class", "Class", "");
			AddItem(4, "Instance", "Instance", "");
			AddItem(5, "Url", "Url", "");
			AddItem(6, "User", "User", "");
			AddItem(7, "Member", "Member", "");
			AddItem(8, "Artifact", "Artifact", "");
			AddItem(9, "Factor", "Factor", "");
			AddItem(10, "Email", "Email", "");
			AddItem(11, "OauthAccess", "OauthAccess", "");
		}

	}

}