using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class OauthScopeSchema : VertexSchema {

		public DomainProperty<bool> Allow { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthScopeSchema() {
			Names = new NameProvider("OauthScope", "OauthScopes", "os");

			////

			Allow = new DomainProperty<bool>("Allow", "os.al");
		}

	}

}