using Fabric.Domain.Meta.Vertices.Tools;

namespace Fabric.Domain.Meta.Vertices {
	
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
			NameKey = new DomainProperty<string>("NameKey", "u.nk");
			Password = new DomainProperty<string>("Password", "u.pa");

			////

			FabName = new ApiProperty<string>("Name", false, false);

			////

			FabNameMap = new PropertyMapping<string, string>(Name, FabName);
			FabNameMap.DomainToApi = (x => x);
			FabNameMap.ApiToDomain = (x => x);
		}

	}

}