using Fabric.Domain.Meta.Vertices.Tools;

namespace Fabric.Domain.Meta.Vertices {
	
	/*================================================================================================*/
	public class AppSchema : ArtifactSchema {

		public DomainProperty<string> Name { get; private set; }
		public DomainProperty<string> NameKey { get; private set; }
		public DomainProperty<string> Secret { get; private set; }

		public ApiProperty<string> FabName { get; private set; }

		public PropertyMapping<string, string> FabNameMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppSchema() {
			Names = new NameProvider("App", "Apps", "p");

			Actions.Modify = new ActionAccess { AppDataProvider = true };

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

			FabName = new ApiProperty<string>("Name", false, true);
			FabName.IsUnique = true;
			FabName.LenMin = 3;
			FabName.LenMax = 64;
			FabName.ValidRegex = ApiProperty.ValidTitleRegex;

			////

			FabNameMap = new PropertyMapping<string, string>(Name, FabName);
		}

	}

}