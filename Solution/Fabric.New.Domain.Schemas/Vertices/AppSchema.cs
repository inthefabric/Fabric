using Fabric.New.Domain.Schemas.Edges;
using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class AppSchema : ArtifactSchema {

		public DomainProperty<string> Name { get; private set; }
		public DomainProperty<string> NameKey { get; private set; }
		public DomainProperty<string> Secret { get; private set; }

		public ApiProperty<string> FabName { get; private set; }
		public ApiProperty<string> FabSecret { get; private set; }

		public PropertyMapping<string, string> FabNameMap { get; private set; }
		public PropertyMapping<string, string> FabSecretMap { get; private set; }

		public AppDefinesMemberSchema DefinesMember { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppSchema() {
			Names = new NameProvider("App", "Apps", "p");
			GetAccess = Access.Internal;
			DeleteAccess = Access.Internal;

			////

			Name = new DomainProperty<string>("Name", "p.na");
			Name.IsUnique = true;
			Name.IsElastic = true;

			NameKey = new DomainProperty<string>("NameKey", "p.nk");
			NameKey.IsUnique = true;
			NameKey.ToLowerCase = true;
			NameKey.IsIndexed = true;

			Secret = new DomainProperty<string>("Secret", "p.se");

			////

			FabName = new ApiProperty<string>("Name");
			FabName.GetAccess = Access.All;
			FabName.IsUnique = true;
			FabName.LenMin = 3;
			FabName.LenMax = 64;
			FabName.ValidRegex = ApiProperty.ValidTitleRegex;

			FabSecret = new ApiProperty<string>("Secret");
			FabSecret.LenMin = 32;
			FabSecret.LenMax = 32;
			FabSecret.ValidRegex = ApiProperty.ValidCodeRegex;

			////

			FabNameMap = new PropertyMapping<string, string>(Name, FabName, true);
			FabNameMap.ApiToDomainNote = "Set Domain.NameKey = Api.Name.ToLower()";

			FabSecretMap = new PropertyMapping<string, string>(Secret, FabSecret);

			////

			DefinesMember = new AppDefinesMemberSchema();
		}

	}

}