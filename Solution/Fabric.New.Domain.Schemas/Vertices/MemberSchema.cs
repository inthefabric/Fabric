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
		public ApiProperty<bool> FabOauthScopeAllow { get; private set; }
		public ApiProperty<string> FabOauthGrantRedirectUri { get; private set; }
		public ApiProperty<string> FabOauthGrantCode { get; private set; }
		public ApiProperty<long> FabOauthGrantExpires { get; private set; }

		public PropertyMapping<byte, byte> FabMemberTypeMap { get; private set; }
		public PropertyMapping<bool, bool> FabOauthScopeAllowMap { get; private set; }
		public PropertyMapping<string, string> FabOauthGrantRedirectUriMap { get; private set; }
		public PropertyMapping<string, string> FabOauthGrantCodeMap { get; private set; }
		public PropertyMapping<long, long> FabOauthGrantExpiresMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberSchema() {
			Names = new NameProvider("Member", "Members", "m");
			GetAccess = Access.All;
			CreateAccess = Access.All;
			DeleteAccess = Access.CreatorApp;

			////

			MemberType = new DomainProperty<byte>("MemberType", "m.at");

			OauthScopeAllow = new DomainProperty<bool>("OauthScopeAllow", "m.osa");
			OauthScopeAllow.IsNullable = true;

			OauthGrantRedirectUri = new DomainProperty<string>("OauthGrantRedirectUri", "m.ogr");
			OauthGrantRedirectUri.IsNullable = true;
			OauthGrantRedirectUri.ToLowerCase = true;

			OauthGrantCode = new DomainProperty<string>("OauthGrantCode", "m.ogc");
			OauthGrantCode.IsNullable = true;
			OauthGrantCode.IsUnique = true;
			OauthGrantCode.IsIndexed = true;

			OauthGrantExpires = new DomainProperty<long>("OauthGrantExpires", "m.oge");
			OauthGrantExpires.IsNullable = true;
			
			////

			FabMemberType = new ApiProperty<byte>("Type");
			FabMemberType.SetOpenAccess();
			FabMemberType.FromEnum = "MemberType";

			FabOauthScopeAllow = new ApiProperty<bool>("OauthScopeAllow");
			FabOauthScopeAllow.IsNullable = true;

			FabOauthGrantRedirectUri = new ApiProperty<string>("OauthGrantRedirectUri");
			FabOauthGrantRedirectUri.LenMin = 1;
			FabOauthGrantRedirectUri.LenMax = 1024;
			FabOauthGrantRedirectUri.ToLowerCase = true;
			FabOauthGrantRedirectUri.IsNullable = true;

			FabOauthGrantCode = new ApiProperty<string>("OauthGrantCode");
			FabOauthGrantCode.LenMin = 32;
			FabOauthGrantCode.LenMax = 32;
			FabOauthGrantCode.ValidRegex = ApiProperty.ValidCodeRegex;
			FabOauthGrantCode.IsNullable = true;

			FabOauthGrantExpires = new ApiProperty<long>("OauthGrantExpires");
			FabOauthGrantExpires.IsNullable = true;

			////
			
			FabMemberTypeMap = new PropertyMapping<byte, byte>(MemberType, FabMemberType);
			FabOauthScopeAllowMap = new PropertyMapping<bool, bool>(
				OauthScopeAllow, FabOauthScopeAllow);
			FabOauthGrantRedirectUriMap = new PropertyMapping<string, string>(
				OauthGrantRedirectUri, FabOauthGrantRedirectUri);
			FabOauthGrantCodeMap = new PropertyMapping<string, string>(
				OauthGrantCode, FabOauthGrantCode);
			FabOauthGrantExpiresMap = new PropertyMapping<long, long>(
				OauthGrantExpires, FabOauthGrantExpires);
		}

	}

}