using Fabric.Domain.Meta.Vertices.Tools;

namespace Fabric.Domain.Meta.Vertices {
	
	/*================================================================================================*/
	public class OauthAccessSchema : VertexSchema {

		public DomainProperty<string> Token { get; private set; }
		public DomainProperty<string> Refresh { get; private set; }
		public DomainProperty<long> Expires { get; private set; }
		public DomainProperty<bool> IsClientOnly { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessSchema() {
			Names = new NameProvider("OauthAccess", "OauthAccesses", "oa");
			IsInternal = true;

			////

			Token = new DomainProperty<string>("Token", "oa.to");
			Token.IsUnique = true;
			Token.IsNullable = true;
			Token.IsIndexed = true;

			Refresh = new DomainProperty<string>("Refresh", "oa.re");
			Refresh.IsUnique = true;
			Refresh.IsNullable = true;
			Refresh.IsIndexed = true;

			Expires = new DomainProperty<long>("Expires", "oa.ex");

			IsClientOnly = new DomainProperty<bool>("IsClientOnly", "oa.co");
		}

	}

}