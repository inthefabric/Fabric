using Fabric.Domain.Meta.Vertices.Tools;

namespace Fabric.Domain.Meta.Vertices {
	
	/*================================================================================================*/
	public class OauthDomainSchema : VertexSchema {

		public DomainProperty<string> Domain { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomainSchema() {
			Names = new NameProvider("OauthDomain", "OauthDomains", "od");
			IsInternal = true;

			////

			Domain = new DomainProperty<string>("Domain", "od.do");
			Domain.ToLowerCase = true;
		}

	}

}