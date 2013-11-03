using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class UserSchema : ArtifactSchema {

		public DomainProperty<string> Name { get; private set; }
		public DomainProperty<string> NameKey { get; private set; }
		public DomainProperty<string> Password { get; private set; }

		public ApiProperty<string> FabName { get; private set; }

		public PropertyMapping<string, string> FabNameMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserSchema() {
			Names = new NameProvider("User", "Users", "u");

			Actions.Modify = new ActionAccess { AppDataProvider = true };

			////

			Name = new DomainProperty<string>("Name", "u.na");
			Name.IsUnique = true;
			Name.IsElastic = true;

			NameKey = new DomainProperty<string>("NameKey", "u.nk");
			NameKey.IsUnique = true;
			NameKey.ToLowerCase = true;
			NameKey.IsIndexed = true;

			Password = new DomainProperty<string>("Password", "u.pa");

			////

			FabName = new ApiProperty<string>("Name", false, false);
			FabName.IsUnique = true;
			FabName.LenMin = 3;
			FabName.LenMax = 64;
			FabName.ValidRegex = ApiProperty.ValidTitleRegex;

			////

			FabNameMap = new PropertyMapping<string, string>(Name, FabName);
		}

	}

}