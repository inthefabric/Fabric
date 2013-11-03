using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class OauthDomainSchema : VertexSchema {

		public DomainProperty<string> Domain { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainSchema() {
			Names = new NameProvider("OauthDomain", "OauthDomains", "od");

			////

			Domain = new DomainProperty<string>("Domain", "od.do");
			Domain.ToLowerCase = true;
		}

	}

}