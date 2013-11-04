using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberCreatesFactorSchema : EdgeSchema<MemberSchema, FactorSchema> {

		public EdgeProperty<long> Timestamp { get; private set; }
		public EdgeProperty<byte> DescriptorType { get; private set; }
		public EdgeProperty<long> PrimaryArtifactId { get; private set; }
		public EdgeProperty<long> RelatedArtifactId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberCreatesFactorSchema() : base(EdgeQuantity.Many) {
			Names = new NameProvider("CreatesFactor", "CreatesFactors", "cf");

			Timestamp = new EdgeProperty<long>("Timestamp", "cf.ts", InVertex.Timestamp);
			DescriptorType = new EdgeProperty<byte>("DescriptorType", "cf.dt", InVertex.DescriptorType);
			PrimaryArtifactId = new EdgeProperty<long>("PrimaryArtifactId", "cf.pa",
				InVertex.UsesPrimaryArtifact.ToVertexId);
			RelatedArtifactId = new EdgeProperty<long>("RelatedArtifactId", "cf.ra",
				InVertex.UsesRelatedArtifact.ToVertexId);
		}

	}

}