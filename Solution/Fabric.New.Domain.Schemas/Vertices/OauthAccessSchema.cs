using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class OauthAccessSchema : VertexSchema {

		public DomainProperty<string> Token { get; private set; }
		public DomainProperty<string> Refresh { get; private set; }
		public DomainProperty<long> Expires { get; private set; }
		public DomainProperty<bool> IsDataProv { get; private set; }

		public ApiProperty<string> FabToken { get; private set; }
		public ApiProperty<string> FabRefresh { get; private set; }
		public ApiProperty<long> FabExpires { get; private set; }
		public ApiProperty<bool> FabIsDataProv { get; private set; }

		public PropertyMapping<string, string> FabTokenMap { get; private set; }
		public PropertyMapping<string, string> FabRefreshMap { get; private set; }
		public PropertyMapping<long, long> FabExpiresMap { get; private set; }
		public PropertyMapping<bool, bool> FabIsDataProvMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessSchema() {
			Names = new NameProvider("OauthAccess", "OauthAccesses", "oa");
			GetAccess = Access.Internal;
			CreateAccess = Access.Internal;
			DeleteAccess = Access.Internal;
			IsAbstract = false;

			////

			Token = new DomainProperty<string>("Token", "oa_to");
			Token.IsUnique = true;
			Token.IsNullable = true;
			Token.IsIndexed = true;

			Refresh = new DomainProperty<string>("Refresh", "oa_re");
			Refresh.IsUnique = true;
			Refresh.IsNullable = true;
			Refresh.IsIndexed = true;

			Expires = new DomainProperty<long>("Expires", "oa_ex");

			IsDataProv = new DomainProperty<bool>("IsDataProv", "oa_dp");

			////
			
			FabToken = new ApiProperty<string>("Token");
			FabToken.IsNullable = true;
			FabToken.IsUnique = true;
			FabToken.LenMin = 32;
			FabToken.LenMax = 32;
			FabToken.ValidRegex = ApiProperty.ValidCodeRegex;

			FabRefresh = new ApiProperty<string>("Refresh");
			FabRefresh.IsNullable = true;
			FabRefresh.IsUnique = true;
			FabRefresh.LenMin = 32;
			FabRefresh.LenMax = 32;
			FabRefresh.ValidRegex = ApiProperty.ValidCodeRegex;

			FabExpires = new ApiProperty<long>("Expires");

			FabIsDataProv = new ApiProperty<bool>("IsDataProv");

			////

			FabTokenMap = new PropertyMapping<string, string>(Token, FabToken);
			FabRefreshMap = new PropertyMapping<string, string>(Refresh, FabRefresh);
			FabExpiresMap = new PropertyMapping<long, long>(Expires, FabExpires);
			FabIsDataProvMap = new PropertyMapping<bool, bool>(IsDataProv, FabIsDataProv);
		}

	}

}