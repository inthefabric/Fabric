using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {

	/*================================================================================================*/
	public class VertexSchema : IVertexSchema {

		public NameProvider Names { get; protected set; }
		public Access GetAccess { get; protected set; }
		public Access CreateAccess { get; protected set; }
		public Access DeleteAccess { get; protected set; }
		public bool IsAbstract { get; protected set; }
		public bool CustomCreate { get; protected set; }

		public DomainProperty<long> VertexId { get; private set; }
		public DomainProperty<long> Timestamp { get; private set; }
		public DomainProperty<byte> VertexType { get; private set; }

		public ApiProperty<long> FabId { get; private set; }
		public ApiProperty<long> FabTimestamp { get; private set; }
		public ApiProperty<byte> FabVertexType { get; private set; }

		public PropertyMapping<long, long> FabIdMap { get; private set; }
		public PropertyMapping<long, long> FabTimestampMap { get; private set; }
		public PropertyMapping<byte, byte> FabVertexTypeMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexSchema() {
			Names = new NameProvider("Vertex", "Vertices", "v");
			GetAccess = Access.All;
			CreateAccess = Access.None;
			DeleteAccess = Access.None;
			IsAbstract = true;

			////

			VertexId = new DomainProperty<long>("VertexId", "v.id");
			VertexId.IsUnique = true;
			VertexId.IsIndexed = true;

			Timestamp = new DomainProperty<long>("Timestamp", "v.ts");
			Timestamp.IsElastic = true;

			VertexType = new DomainProperty<byte>("VertexType", "v.t");

			////

			FabId = new ApiProperty<long>("Id");
			FabId.GetAccess = Access.All;
			FabId.CreateAccess = Access.None;
			FabId.ModifyAccess = Access.None;
			FabId.IsUnique = true;
			FabId.TraversalHas = Matching.Exact;

			FabTimestamp = new ApiProperty<long>("Timestamp");
			FabTimestamp.GetAccess = Access.All;
			FabTimestamp.CreateAccess = Access.None;
			FabTimestamp.ModifyAccess = Access.None;
			FabTimestamp.TraversalHas = Matching.Custom;

			FabVertexType = new ApiProperty<byte>("VertexType");
			FabVertexType.GetAccess = Access.All;
			FabVertexType.CreateAccess = Access.None;
			FabVertexType.ModifyAccess = Access.None;
			FabVertexType.TraversalHas = Matching.Exact;
			FabVertexType.FromEnum = "VertexType";

			////

			FabIdMap = new PropertyMapping<long, long>(VertexId, FabId);

			FabTimestampMap = new PropertyMapping<long, long>(Timestamp, FabTimestamp, true);
			FabTimestampMap.ApiToDomainNote = "Convert Api.Timestamp from Unix-based seconds.";
			FabTimestampMap.DomainToApiNote = "Convert Domain.Timestamp to Unix-based seconds.";

			FabVertexTypeMap = new PropertyMapping<byte, byte>(VertexType, FabVertexType);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual bool IsSubObjectNullable(string pName) {
			return false;
		}

	}

}