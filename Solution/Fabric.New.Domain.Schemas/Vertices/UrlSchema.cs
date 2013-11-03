using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class UrlSchema : ArtifactSchema {

		public DomainProperty<string> Name { get; private set; }
		public DomainProperty<string> FullPath { get; private set; }

		public ApiProperty<string> FabName { get; private set; }
		public ApiProperty<string> FabFullPath { get; private set; }

		public PropertyMapping<string, string> FabNameMap { get; private set; }
		public PropertyMapping<string, string> FabFullPathMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlSchema() {
			Names = new NameProvider("Url", "Urls", "r");

			Actions.Add = new ActionAccess();
			Actions.Modify = new ActionAccess { Creator = true, AppDataProvider = true };
			Actions.Delete = new ActionAccess { Creator = true, AppDataProvider = true };

			////

			Name = new DomainProperty<string>("Name", "r.na");
			Name.IsNullable = true;
			Name.IsElastic = true;

			FullPath = new DomainProperty<string>("FullPath", "r.fp");
			FullPath.IsUnique = true;
			FullPath.ToLowerCase = true;
			FullPath.IsIndexed = true;

			////

			FabName = new ApiProperty<string>("Name", true, true);
			FabName.IsNullable = true;
			FabName.LenMin = 1;
			FabName.LenMax = 128;
			FabName.ValidRegex = ApiProperty.ValidTitleRegex;

			FabFullPath = new ApiProperty<string>("FullPath", true, true);
			FabFullPath.IsUnique = true;
			FabFullPath.ToLowerCase = true;
			FabFullPath.LenMin = 1;
			FabFullPath.LenMax = 2048;

			////

			FabNameMap = new PropertyMapping<string, string>(Name, FabName);
			FabFullPathMap = new PropertyMapping<string, string>(FullPath, FabFullPath);
		}

	}

}