using Fabric.Domain.Schemas.Utils;

namespace Fabric.Domain.Schemas.Vertices {
	
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
			GetAccess = Access.All;
			CreateAccess = Access.All;
			DeleteAccess = Access.CreatorUserAndApp;
			IsAbstract = false;

			////

			Name = new DomainProperty<string>("Name", "r_na");
			Name.IsNullable = true;
			Name.IsElastic = true;

			FullPath = new DomainProperty<string>("FullPath", "r_fp");
			FullPath.EnforceUnique = true;
			FullPath.ToLowerCase = true;
			FullPath.IsIndexed = true;

			////

			FabName = new ApiProperty<string>("Name");
			FabName.SetOpenAccess();
			FabName.IsNullable = true;
			FabName.LenMin = 1;
			FabName.LenMax = 128;
			FabName.ValidRegex = ApiProperty.ValidTitleRegex;
			FabName.TraversalHas = Matching.None;

			FabFullPath = new ApiProperty<string>("FullPath");
			FabFullPath.SetOpenAccess();
			FabFullPath.IsUnique = true;
			FabFullPath.ToLowerCase = true;
			FabFullPath.LenMin = 1;
			FabFullPath.LenMax = 2048;
			FabFullPath.TraversalHas = Matching.None;

			////

			FabNameMap = new PropertyMapping<string, string>(Name, FabName);
			FabFullPathMap = new PropertyMapping<string, string>(FullPath, FabFullPath);
		}

	}

}