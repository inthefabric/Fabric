using System;
using Fabric.Domain.Meta.Vertices.Tools;

namespace Fabric.Domain.Meta.Vertices {

	/*================================================================================================*/
	public class VertexSchema : IVertexSchema {

		public static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public NameProvider Names { get; protected set; }
		public ActionProvider Actions { get; protected set; }
		public bool IsInternal { get; protected set; }

		public DomainProperty<long> Id { get; private set; }
		public DomainProperty<long> Ticks { get; private set; }
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

			Ticks = new DomainProperty<long>("Ticks", "v.ti");
			Ticks.IsElastic = true;

			DomainType = new DomainProperty<byte>("DomainType", "v.dt");

			////

			FabId = new ApiProperty<long>("Id", false, false);
			FabId.IsUnique = true;

			FabIdStr = new ApiProperty<string>("IdStr", false, false);
			FabIdStr.IsUnique = true;

			FabTimestamp = new ApiProperty<float>("Timestamp", false, false);

			////

			FabIdMap = new PropertyMapping<long, long>(Id, FabId);
			FabIdMap.DomainToApi = (x => x);

			FabIdStrMap = new PropertyMapping<long, string>(Id, FabIdStr);
			FabIdStrMap.DomainToApi = (x => x+"");

			FabTimestampMap = new PropertyMapping<long, float>(Ticks, FabTimestamp);
			FabTimestampMap.DomainToApi = (x => (float)(new DateTime(x)-UnixEpoch).TotalSeconds);
		}

	}

}