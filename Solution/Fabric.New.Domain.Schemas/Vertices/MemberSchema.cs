using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class MemberSchema : VertexSchema {

		public DomainProperty<byte> MemberType { get; private set; }
		public DomainProperty<bool> OauthScopeAllow { get; private set; }
		public DomainProperty<string> OauthGrantRedirectUri { get; private set; }
		public DomainProperty<string> OauthGrantCode { get; private set; }
		public DomainProperty<long> OauthGrantExpires { get; private set; }

		public ApiProperty<byte> FabMemberType { get; private set; }

		public PropertyMapping<byte, byte> FabMemberTypeMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberSchema() {
			Names = new NameProvider("Member", "Members", "m");
			GetAccess = Access.All;
			DeleteAccess = Access.CreatorApp;

			OauthScopeAllow = new DomainProperty<bool>("OauthScopeAllow", "m.osa");

			OauthGrantRedirectUri = new DomainProperty<string>("OauthGrantRedirectUri", "m.ogr");
			OauthGrantRedirectUri.ToLowerCase = true;

			OauthGrantCode = new DomainProperty<string>("OauthGrantCode", "m.ogc");
			OauthGrantCode.IsUnique = true;
			OauthGrantCode.IsIndexed = true;

			OauthGrantExpires = new DomainProperty<long>("OauthGrantExpires", "m.oge");

			////

			MemberType = new DomainProperty<byte>("MemberType", "m.at");

			////

			FabMemberType = new ApiProperty<byte>("Type");
			FabMemberType.SetOpenAccess();
			FabMemberType.FromEnum = "MemberType";

			////

			FabMemberTypeMap = new PropertyMapping<byte, byte>(MemberType, FabMemberType);
		}

	}

}