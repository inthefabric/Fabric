using Fabric.Domain.Meta.Vertices.Tools;

namespace Fabric.Domain.Meta.Vertices {
	
	/*================================================================================================*/
	public class OauthScopeSchema : VertexSchema {

		public DomainProperty<bool> Allow { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeSchema() {
			Names = new NameProvider("OauthScope", "OauthScopes", "os");
			IsInternal = true;

			////

			Allow = new DomainProperty<bool>("Allow", "os.al");
		}

	}

}