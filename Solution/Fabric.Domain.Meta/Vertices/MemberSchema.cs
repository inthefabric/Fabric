using Fabric.Domain.Meta.Vertices.Tools;

namespace Fabric.Domain.Meta.Vertices {
	
	/*================================================================================================*/
	public enum MemberAccessType : byte {
		None = 1,
		Request,
		Invite,
		Member,
		Staff,
		Admin,
		Owner,
		DataProvider
	}
	
	/*================================================================================================*/
	public class MemberSchema : VertexSchema {

		public DomainProperty<byte> AccessType { get; private set; }

		public ApiProperty<byte> FabAccessType { get; private set; }

		public PropertyMapping<byte, byte> FabAccessTypeMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberSchema() {
			Names = new NameProvider("Member", "Members", "m");

			Actions.Add = new ActionAccess { AppDataProvider = true };
			Actions.Modify = new ActionAccess { AppDataProvider = true };

			////

			AccessType = new DomainProperty<byte>("AccessType", "m.at");

			////

			FabAccessType = new ApiProperty<byte>("AccessType", true, true);
			FabAccessType.FromEnum = typeof(MemberAccessType);

			////

			FabAccessTypeMap = new PropertyMapping<byte, byte>(AccessType, FabAccessType);
		}

	}

}