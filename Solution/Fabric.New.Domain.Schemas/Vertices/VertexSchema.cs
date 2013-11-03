using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {

	/*================================================================================================*/
	public class VertexSchema : IVertexSchema {

		public NameProvider Names { get; protected set; }
		public ActionProvider Actions { get; protected set; }
		public bool IsInternal { get; protected set; }

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
			Actions = new ActionProvider();

			////

			Id = new DomainProperty<long>("Id", "v.id");
			Id.IsUnique = true;
			Id.IsIndexed = true;

			Timestamp = new DomainProperty<long>("Timestamp", "v.ti");
			Timestamp.IsElastic = true;

			DomainType = new DomainProperty<byte>("DomainType", "v.dt");

			////

			FabId = new ApiProperty<long>("Id", false, false);
			FabId.IsUnique = true;

			FabIdStr = new ApiProperty<string>("IdStr", false, false);
			FabIdStr.IsUnique = true;

			FabTimestamp = new ApiProperty<float>("Timestamp", false, false);

			////

			FabIdMap = new PropertyMapping<long, long>(Id, FabId);
			FabIdStrMap = new PropertyMapping<long, string>(Id, FabIdStr, true);
			FabTimestampMap = new PropertyMapping<long, float>(Timestamp, FabTimestamp, true);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual bool IsSubObjectNullable(string pName) {
			return false;
		}

	}

}