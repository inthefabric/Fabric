using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class MemberSchema : VertexSchema {

		public DomainProperty<byte> MemberType { get; private set; }

		public ApiProperty<byte> FabMemberType { get; private set; }

		public PropertyMapping<byte, byte> FabMemberTypeMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberSchema() {
			Names = new NameProvider("Member", "Members", "m");
			GetAccess = Access.All;
			DeleteAccess = Access.CreatorApp;

			////

			MemberType = new DomainProperty<byte>("MemberType", "m.at");

			////

			FabMemberType = new ApiProperty<byte>("Type");
			FabMemberType.SetOpenAccess();
			FabMemberType.FromEnum = "MemberType";

			////

			FabMemberTypeMap = new PropertyMapping<byte, byte>(MemberType, FabMemberType);
		}

	}

}