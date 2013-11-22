using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class UserSchema : ArtifactSchema {

		public DomainProperty<string> Name { get; private set; }
		public DomainProperty<string> NameKey { get; private set; }
		public DomainProperty<string> Password { get; private set; }

		public ApiProperty<string> FabName { get; private set; }
		public ApiProperty<string> FabPassword { get; private set; }

		public PropertyMapping<string, string> FabNameMap { get; private set; }
		public PropertyMapping<string, string> FabPasswordMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserSchema() {
			Names = new NameProvider("User", "Users", "u");
			GetAccess = Access.All;
			CreateAccess = Access.Internal;
			DeleteAccess = Access.Internal;
			IsAbstract = false;

			////

			Name = new DomainProperty<string>("Name", "u_na");
			Name.IsUnique = true;
			Name.IsElastic = true;

			NameKey = new DomainProperty<string>("NameKey", "u_nk");
			NameKey.EnforceUnique = true;
			NameKey.ToLowerCase = true;
			NameKey.IsIndexed = true;
			Name.ExactIndexVia = NameKey;

			Password = new DomainProperty<string>("Password", "u_pa");

			////

			FabName = new ApiProperty<string>("Name");
			FabName.GetAccess = Access.All;
			FabName.IsUnique = true;
			FabName.LenMin = 3;
			FabName.LenMax = 64;
			FabName.ValidRegex = ApiProperty.ValidUserRegex;
			FabName.TraversalHas = Matching.None;

			FabPassword = new ApiProperty<string>("Password");
			FabPassword.LenMin = 8;
			FabPassword.LenMax = 128;
			FabPassword.ValidRegex = ApiProperty.ValidCodeRegex;

			////

			FabNameMap = new PropertyMapping<string, string>(Name, FabName, true);
			FabNameMap.ApiToDomainNote = "Set Domain.NameKey = Api.Name.ToLower()";
			FabNameMap.DomainToApiNote = "Direct mapping.";

			FabPasswordMap = new PropertyMapping<string, string>(Password, FabPassword, true);
			FabPasswordMap.ApiToDomainNote = "Encrypt Api.Password.";
			FabPasswordMap.DomainToApiNote = "Direct mapping.";
		}

	}

}