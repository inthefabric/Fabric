﻿using Fabric.Domain.Schemas.Utils;

namespace Fabric.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class AppSchema : ArtifactSchema {

		public DomainProperty<string> Name { get; private set; }
		public DomainProperty<string> NameKey { get; private set; }
		public DomainProperty<string> Secret { get; private set; }
		public DomainProperty<string> OauthDomains { get; private set; }

		public ApiProperty<string> FabName { get; private set; }
		public ApiProperty<string> FabSecret { get; private set; }
		public ApiProperty<string> FabOauthDomains { get; private set; }

		public PropertyMapping<string, string> FabNameMap { get; private set; }
		public PropertyMapping<string, string> FabSecretMap { get; private set; }
		public PropertyMapping<string, string> FabOauthDomainsMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppSchema() {
			Names = new NameProvider("App", "Apps", "p");
			GetAccess = Access.All;
			CreateAccess = Access.Internal;
			DeleteAccess = Access.Internal;
			IsAbstract = false;

			////

			Name = new DomainProperty<string>("Name", "p_na");
			Name.IsUnique = true;
			Name.IsElastic = true;

			NameKey = new DomainProperty<string>("NameKey", "p_nk");
			NameKey.EnforceUnique = true;
			NameKey.ToLowerCase = true;
			NameKey.IsIndexed = true;
			Name.ExactIndexVia = NameKey;

			Secret = new DomainProperty<string>("Secret", "p_se");

			OauthDomains = new DomainProperty<string>("OauthDomains", "p_od");
			OauthDomains.IsNullable = true;

			////

			FabName = new ApiProperty<string>("Name");
			FabName.GetAccess = Access.All;
			FabName.IsUnique = true;
			FabName.LenMin = 3;
			FabName.LenMax = 64;
			FabName.ValidRegex = ApiProperty.ValidTitleRegex;
			FabName.TraversalHas = Matching.None;
			
			FabSecret = new ApiProperty<string>("Secret");
			FabSecret.LenMin = 32;
			FabSecret.LenMax = 32;
			FabSecret.ValidRegex = ApiProperty.ValidCodeRegex;

			FabOauthDomains = new ApiProperty<string>("OauthDomains");
			FabOauthDomains.IsNullable = true;
			FabOauthDomains.CustomValidation = true;

			////

			FabNameMap = new PropertyMapping<string, string>(Name, FabName, CustomDir.ApiToDomain);
			FabNameMap.ApiToDomainNote = "Set Domain.NameKey = Api.Name.ToLower()";

			FabSecretMap = new PropertyMapping<string, string>(Secret, FabSecret);

			FabOauthDomainsMap = new PropertyMapping<string, string>(OauthDomains, FabOauthDomains);
		}

	}

}