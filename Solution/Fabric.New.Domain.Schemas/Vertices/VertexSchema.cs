using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {

	/*================================================================================================*/
	public class VertexSchema : IVertexSchema {

		public NameProvider Names { get; protected set; }
		public Access GetAccess { get; protected set; }
		public Access DeleteAccess { get; protected set; }

		public DomainProperty<long> Id { get; private set; }
		public DomainProperty<long> Timestamp { get; private set; }
		public DomainProperty<byte> DomainType { get; private set; }

		public ApiProperty<long> FabId { get; private set; }
		public ApiProperty<string> FabIdStr { get; private set; }
		public ApiProperty<float> FabTimestamp { get; private set; }

		public PropertyMapping<long, long> FabIdMap { get; private set; }
		public PropertyMapping<long, string> FabIdStrMap { get; private set; }
		public PropertyMapping<long, float> FabTimestampMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexSchema() {
			Names = new NameProvider("Vertex", "Vertices", "v");
			GetAccess = Access.None;
			DeleteAccess = Access.None;

			////

			Id = new DomainProperty<long>("Id", "v.id");
			Id.IsUnique = true;
			Id.IsIndexed = true;

			Timestamp = new DomainProperty<long>("Timestamp", "v.ti");
			Timestamp.IsElastic = true;

			DomainType = new DomainProperty<byte>("DomainType", "v.dt");

			////

			FabId = new ApiProperty<long>("Id");
			FabId.GetAccess = Access.All;
			FabId.CreateAccess = Access.None;
			FabId.ModifyAccess = Access.None;
			FabId.IsUnique = true;

			FabIdStr = new ApiProperty<string>("IdStr");
			FabIdStr.GetAccess = Access.All;
			FabIdStr.CreateAccess = Access.None;
			FabIdStr.ModifyAccess = Access.None;
			FabIdStr.IsUnique = true;

			FabTimestamp = new ApiProperty<float>("Timestamp");
			FabTimestamp.GetAccess = Access.All;
			FabTimestamp.CreateAccess = Access.None;
			FabTimestamp.ModifyAccess = Access.None;

			////

			FabIdMap = new PropertyMapping<long, long>(Id, FabId);

			FabIdStrMap = new PropertyMapping<long, string>(Id, FabIdStr, true);
			FabIdStrMap.DomainToApiNote = "Set Api.IdStr = Domain.Id.ToString().";

			FabTimestampMap = new PropertyMapping<long, float>(Timestamp, FabTimestamp, true);
			FabTimestampMap.ApiToDomainNote = "Convert Api.Timestamp from Unix-based seconds.";
			FabTimestampMap.DomainToApiNote = "Convert Domain.Timestamp to Unix-based seconds.";
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual bool IsSubObjectNullable(string pName) {
			return false;
		}

	}

}