using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class OauthGrantSchema : VertexSchema {

		public DomainProperty<string> RedirectUri { get; private set; }
		public DomainProperty<string> Code { get; private set; }
		public DomainProperty<long> Expires { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrantSchema() {
			Names = new NameProvider("OauthGrant", "OauthGrants", "og");

			////

			RedirectUri = new DomainProperty<string>("RedirectUri", "og.ru");
			RedirectUri.ToLowerCase = true;

			Code = new DomainProperty<string>("Code", "og.co");
			Code.IsUnique = true;
			Code.IsIndexed = true;

			Expires = new DomainProperty<long>("Expires", "og.ex");
		}

	}

}