using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
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