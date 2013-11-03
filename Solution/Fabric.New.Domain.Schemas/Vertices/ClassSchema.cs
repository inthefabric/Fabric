using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class ClassSchema : ArtifactSchema {

		public DomainProperty<string> Name { get; private set; }
		public DomainProperty<string> NameKey { get; private set; }
		public DomainProperty<string> Disamb { get; private set; }
		public DomainProperty<string> Note { get; private set; }

		public ApiProperty<string> FabName { get; private set; }
		public ApiProperty<string> FabDisamb { get; private set; }
		public ApiProperty<string> FabNote { get; private set; }

		public PropertyMapping<string, string> FabNameMap { get; private set; }
		public PropertyMapping<string, string> FabDisambMap { get; private set; }
		public PropertyMapping<string, string> FabNoteMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassSchema() {
			Names = new NameProvider("Class", "Classes", "c");

			Actions.Add = new ActionAccess();
			Actions.Modify = new ActionAccess { Creator = true, AppDataProvider = true };
			Actions.Delete = new ActionAccess { Creator = true, AppDataProvider = true };

			////

			Name = new DomainProperty<string>("Name", "c.na");
			Name.IsUnique = true;
			Name.IsElastic = true;

			NameKey = new DomainProperty<string>("NameKey", "c.nk");
			NameKey.IsUnique = true;
			NameKey.ToLowerCase = true;
			NameKey.IsIndexed = true;

			Disamb = new DomainProperty<string>("Disamb", "c.di");
			Disamb.IsNullable = true;
			Disamb.IsElastic = true;

			Note = new DomainProperty<string>("Note", "c.no");
			Note.IsNullable = true;

			////

			FabName = new ApiProperty<string>("Name", true, true);
			FabName.IsUnique = true;
			FabName.LenMin = 1;
			FabName.LenMax = 128;
			FabName.ValidRegex = ApiProperty.ValidTitleRegex;

			FabDisamb = new ApiProperty<string>("Disamb", true, true);
			FabDisamb.IsNullable = true;
			FabDisamb.LenMin = 1;
			FabDisamb.LenMax = 128;
			FabDisamb.ValidRegex = ApiProperty.ValidTitleRegex;

			FabNote = new ApiProperty<string>("Note", true, true);
			FabNote.IsNullable = true;
			FabNote.LenMin = 1;
			FabNote.LenMax = 256;

			////

			FabNameMap = new PropertyMapping<string, string>(Name, FabName);
			FabDisambMap = new PropertyMapping<string, string>(Disamb, FabDisamb);
			FabNoteMap = new PropertyMapping<string, string>(Note, FabNote);
		}

	}

}