
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Domain.Enums;

namespace Fabric.New.Api.Objects.Conversions {
		

	/*================================================================================================*/
	public class CreateFabAppValidator : CreateFabArtifactValidator {
		
		public const string NameName = "Name";
		public const string SecretName = "Secret";
		public const string OauthDomainsName = "OauthDomains";
		
		private readonly CreateFabApp vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabAppValidator(CreateFabApp pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Name(vCreateObj.Name);
			Secret(vCreateObj.Secret);
			OauthDomains(vCreateObj.OauthDomains);
			ApiValidatorsCustom.ValidateApp(vCreateObj);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Name(string pValue) {
			NotNull("Name", pValue);
			LenMin("Name", pValue, 3);
			LenMax("Name", pValue, 64);
			ValidRegex("Name", pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Secret(string pValue) {
			NotNull("Secret", pValue);
			LenMin("Secret", pValue, 32);
			LenMax("Secret", pValue, 32);
			ValidRegex("Secret", pValue, @"^[a-zA-Z0-9]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void OauthDomains(string pValue) {
			NotNull("OauthDomains", pValue);
			ApiValidatorsCustom.ValidateAppOauthDomains("OauthDomains", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
		}

	}
		

	/*================================================================================================*/
	public class CreateFabArtifactValidator : CreateFabVertexValidator {
		
		
		private readonly CreateFabArtifact vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabArtifactValidator(CreateFabArtifact pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
			ValidVertexId("CreatedByMemberId", vCreateObj.CreatedByMemberId);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabClassValidator : CreateFabArtifactValidator {
		
		public const string NameName = "Name";
		public const string DisambName = "Disamb";
		public const string NoteName = "Note";
		
		private readonly CreateFabClass vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabClassValidator(CreateFabClass pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Name(vCreateObj.Name);
			Disamb(vCreateObj.Disamb);
			Note(vCreateObj.Note);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Name(string pValue) {
			NotNull("Name", pValue);
			LenMin("Name", pValue, 1);
			LenMax("Name", pValue, 128);
			ValidRegex("Name", pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Disamb(string pValue) {
			LenMin("Disamb", pValue, 1);
			LenMax("Disamb", pValue, 128);
			ValidRegex("Disamb", pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Note(string pValue) {
			LenMin("Note", pValue, 1);
			LenMax("Note", pValue, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
		}

	}
		

	/*================================================================================================*/
	public class CreateFabEmailValidator : CreateFabVertexValidator {
		
		public const string AddressName = "Address";
		public const string CodeName = "Code";
		public const string VerifiedName = "Verified";
		
		private readonly CreateFabEmail vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabEmailValidator(CreateFabEmail pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Address(vCreateObj.Address);
			Code(vCreateObj.Code);
			Verified(vCreateObj.Verified);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Address(string pValue) {
			NotNull("Address", pValue);
			LenMin("Address", pValue, 1);
			LenMax("Address", pValue, 256);
			ValidRegex("Address", pValue, @"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Code(string pValue) {
			NotNull("Code", pValue);
			LenMin("Code", pValue, 32);
			LenMax("Code", pValue, 32);
			ValidRegex("Code", pValue, @"^[a-zA-Z0-9]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Verified(bool pValue) {
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
			ValidVertexId("UsedByArtifactId", vCreateObj.UsedByArtifactId);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabFactorValidator : CreateFabVertexValidator {
		
		public const string AssertionTypeName = "AssertionType";
		public const string IsDefiningName = "IsDefining";
		public const string NoteName = "Note";
		
		private readonly CreateFabFactor vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabFactorValidator(CreateFabFactor pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			AssertionType(vCreateObj.AssertionType);
			IsDefining(vCreateObj.IsDefining);
			Note(vCreateObj.Note);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void AssertionType(byte pValue) {
			ValidEnum<FactorAssertion.Id>("AssertionType", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void IsDefining(bool pValue) {
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Note(string pValue) {
			LenMin("Note", pValue, 1);
			LenMax("Note", pValue, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
			ValidVertexId("CreatedByMemberId", vCreateObj.CreatedByMemberId);
			ValidVertexId("UsesPrimaryArtifactId", vCreateObj.UsesPrimaryArtifactId);
			ValidVertexId("UsesRelatedArtifactId", vCreateObj.UsesRelatedArtifactId);
		}

	}


	/*================================================================================================*/
	public class CreateFabDescriptorValidator : CreateFabObjectValidator {
		
		public const string TypeName = "Descriptor.Type";
		
		private readonly CreateFabDescriptor vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabDescriptorValidator(CreateFabDescriptor pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Type(vCreateObj.Type);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Type(byte pValue) {
			ValidEnum<DescriptorType.Id>("Descriptor.Type", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
			ValidVertexId("Descriptor.RefinesPrimaryWithArtifactId", vCreateObj.RefinesPrimaryWithArtifactId);
			ValidVertexId("Descriptor.RefinesRelatedWithArtifactId", vCreateObj.RefinesRelatedWithArtifactId);
			ValidVertexId("Descriptor.RefinesTypeWithArtifactId", vCreateObj.RefinesTypeWithArtifactId);
		}

	}


	/*================================================================================================*/
	public class CreateFabDirectorValidator : CreateFabObjectValidator {
		
		public const string TypeName = "Director.Type";
		public const string PrimaryActionName = "Director.PrimaryAction";
		public const string RelatedActionName = "Director.RelatedAction";
		
		private readonly CreateFabDirector vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabDirectorValidator(CreateFabDirector pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Type(vCreateObj.Type);
			PrimaryAction(vCreateObj.PrimaryAction);
			RelatedAction(vCreateObj.RelatedAction);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Type(byte pValue) {
			ValidEnum<DirectorType.Id>("Director.Type", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void PrimaryAction(byte pValue) {
			ValidEnum<DirectorAction.Id>("Director.PrimaryAction", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void RelatedAction(byte pValue) {
			ValidEnum<DirectorAction.Id>("Director.RelatedAction", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
		}

	}


	/*================================================================================================*/
	public class CreateFabEventorValidator : CreateFabObjectValidator {
		
		public const string TypeName = "Eventor.Type";
		public const string YearName = "Eventor.Year";
		public const string MonthName = "Eventor.Month";
		public const string DayName = "Eventor.Day";
		public const string HourName = "Eventor.Hour";
		public const string MinuteName = "Eventor.Minute";
		public const string SecondName = "Eventor.Second";
		
		private readonly CreateFabEventor vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabEventorValidator(CreateFabEventor pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Type(vCreateObj.Type);
			Year(vCreateObj.Year);
			Month(vCreateObj.Month);
			Day(vCreateObj.Day);
			Hour(vCreateObj.Hour);
			Minute(vCreateObj.Minute);
			Second(vCreateObj.Second);
			ApiValidatorsCustom.ValidateFactorEventor(vCreateObj);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Type(byte pValue) {
			ValidEnum<EventorType.Id>("Eventor.Type", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Year(long pValue) {
			Range("Eventor.Year", pValue, -100000000000, 100000000000);
			ApiValidatorsCustom.ValidateFactorEventorYear("Eventor.Year", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Month(byte? pValue) {
			Range("Eventor.Month", pValue, 1, 12);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Day(byte? pValue) {
			Range("Eventor.Day", pValue, 0, 31);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Hour(byte? pValue) {
			Range("Eventor.Hour", pValue, 0, 23);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Minute(byte? pValue) {
			Range("Eventor.Minute", pValue, 0, 59);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Second(byte? pValue) {
			Range("Eventor.Second", pValue, 0, 59);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
		}

	}


	/*================================================================================================*/
	public class CreateFabIdentorValidator : CreateFabObjectValidator {
		
		public const string TypeName = "Identor.Type";
		public const string ValueName = "Identor.Value";
		
		private readonly CreateFabIdentor vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabIdentorValidator(CreateFabIdentor pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Type(vCreateObj.Type);
			Value(vCreateObj.Value);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Type(byte pValue) {
			ValidEnum<IdentorType.Id>("Identor.Type", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Value(string pValue) {
			LenMin("Identor.Value", pValue, 1);
			LenMax("Identor.Value", pValue, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
		}

	}


	/*================================================================================================*/
	public class CreateFabLocatorValidator : CreateFabObjectValidator {
		
		public const string TypeName = "Locator.Type";
		public const string ValueXName = "Locator.ValueX";
		public const string ValueYName = "Locator.ValueY";
		public const string ValueZName = "Locator.ValueZ";
		
		private readonly CreateFabLocator vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabLocatorValidator(CreateFabLocator pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Type(vCreateObj.Type);
			ValueX(vCreateObj.ValueX);
			ValueY(vCreateObj.ValueY);
			ValueZ(vCreateObj.ValueZ);
			ApiValidatorsCustom.ValidateFactorLocator(vCreateObj);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Type(byte pValue) {
			ValidEnum<LocatorType.Id>("Locator.Type", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValueX(double pValue) {
			ApiValidatorsCustom.ValidateFactorLocatorValueX("Locator.ValueX", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValueY(double pValue) {
			ApiValidatorsCustom.ValidateFactorLocatorValueY("Locator.ValueY", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void ValueZ(double pValue) {
			ApiValidatorsCustom.ValidateFactorLocatorValueZ("Locator.ValueZ", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
		}

	}


	/*================================================================================================*/
	public class CreateFabVectorValidator : CreateFabObjectValidator {
		
		public const string TypeName = "Vector.Type";
		public const string UnitName = "Vector.Unit";
		public const string UnitPrefixName = "Vector.UnitPrefix";
		public const string ValueName = "Vector.Value";
		
		private readonly CreateFabVector vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabVectorValidator(CreateFabVector pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Type(vCreateObj.Type);
			Unit(vCreateObj.Unit);
			UnitPrefix(vCreateObj.UnitPrefix);
			Value(vCreateObj.Value);
			ApiValidatorsCustom.ValidateFactorVector(vCreateObj);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Type(byte pValue) {
			ValidEnum<VectorType.Id>("Vector.Type", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Unit(byte pValue) {
			ValidEnum<VectorUnit.Id>("Vector.Unit", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void UnitPrefix(byte pValue) {
			ValidEnum<VectorUnitPrefix.Id>("Vector.UnitPrefix", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Value(long pValue) {
			ApiValidatorsCustom.ValidateFactorVectorValue("Vector.Value", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
			ValidVertexId("Vector.UsesAxisArtifactId", vCreateObj.UsesAxisArtifactId);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabInstanceValidator : CreateFabArtifactValidator {
		
		public const string NameName = "Name";
		public const string DisambName = "Disamb";
		public const string NoteName = "Note";
		
		private readonly CreateFabInstance vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabInstanceValidator(CreateFabInstance pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Name(vCreateObj.Name);
			Disamb(vCreateObj.Disamb);
			Note(vCreateObj.Note);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Name(string pValue) {
			LenMin("Name", pValue, 1);
			LenMax("Name", pValue, 128);
			ValidRegex("Name", pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Disamb(string pValue) {
			LenMin("Disamb", pValue, 1);
			LenMax("Disamb", pValue, 128);
			ValidRegex("Disamb", pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Note(string pValue) {
			LenMin("Note", pValue, 1);
			LenMax("Note", pValue, 256);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
		}

	}
		

	/*================================================================================================*/
	public class CreateFabMemberValidator : CreateFabVertexValidator {
		
		public const string TypeName = "Type";
		public const string OauthScopeAllowName = "OauthScopeAllow";
		public const string OauthGrantRedirectUriName = "OauthGrantRedirectUri";
		public const string OauthGrantCodeName = "OauthGrantCode";
		public const string OauthGrantExpiresName = "OauthGrantExpires";
		
		private readonly CreateFabMember vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabMemberValidator(CreateFabMember pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Type(vCreateObj.Type);
			OauthScopeAllow(vCreateObj.OauthScopeAllow);
			OauthGrantRedirectUri(vCreateObj.OauthGrantRedirectUri);
			OauthGrantCode(vCreateObj.OauthGrantCode);
			OauthGrantExpires(vCreateObj.OauthGrantExpires);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Type(byte pValue) {
			ValidEnum<MemberType.Id>("Type", pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void OauthScopeAllow(bool? pValue) {
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void OauthGrantRedirectUri(string pValue) {
			LenMin("OauthGrantRedirectUri", pValue, 1);
			LenMax("OauthGrantRedirectUri", pValue, 1024);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void OauthGrantCode(string pValue) {
			LenMin("OauthGrantCode", pValue, 32);
			LenMax("OauthGrantCode", pValue, 32);
			ValidRegex("OauthGrantCode", pValue, @"^[a-zA-Z0-9]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void OauthGrantExpires(long? pValue) {
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
			ValidVertexId("DefinedByAppId", vCreateObj.DefinedByAppId);
			ValidVertexId("DefinedByUserId", vCreateObj.DefinedByUserId);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabOauthAccessValidator : CreateFabVertexValidator {
		
		public const string TokenName = "Token";
		public const string RefreshName = "Refresh";
		public const string ExpiresName = "Expires";
		public const string IsDataProvName = "IsDataProv";
		
		private readonly CreateFabOauthAccess vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabOauthAccessValidator(CreateFabOauthAccess pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Token(vCreateObj.Token);
			Refresh(vCreateObj.Refresh);
			Expires(vCreateObj.Expires);
			IsDataProv(vCreateObj.IsDataProv);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Token(string pValue) {
			LenMin("Token", pValue, 32);
			LenMax("Token", pValue, 32);
			ValidRegex("Token", pValue, @"^[a-zA-Z0-9]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Refresh(string pValue) {
			LenMin("Refresh", pValue, 32);
			LenMax("Refresh", pValue, 32);
			ValidRegex("Refresh", pValue, @"^[a-zA-Z0-9]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Expires(long pValue) {
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void IsDataProv(bool pValue) {
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
			ValidVertexId("AuthenticatesMemberId", vCreateObj.AuthenticatesMemberId);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabUrlValidator : CreateFabArtifactValidator {
		
		public const string NameName = "Name";
		public const string FullPathName = "FullPath";
		
		private readonly CreateFabUrl vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabUrlValidator(CreateFabUrl pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Name(vCreateObj.Name);
			FullPath(vCreateObj.FullPath);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Name(string pValue) {
			LenMin("Name", pValue, 1);
			LenMax("Name", pValue, 128);
			ValidRegex("Name", pValue, @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FullPath(string pValue) {
			NotNull("FullPath", pValue);
			LenMin("FullPath", pValue, 1);
			LenMax("FullPath", pValue, 2048);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
		}

	}
		

	/*================================================================================================*/
	public class CreateFabUserValidator : CreateFabArtifactValidator {
		
		public const string NameName = "Name";
		public const string PasswordName = "Password";
		
		private readonly CreateFabUser vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabUserValidator(CreateFabUser pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			Name(vCreateObj.Name);
			Password(vCreateObj.Password);
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Name(string pValue) {
			NotNull("Name", pValue);
			LenMin("Name", pValue, 3);
			LenMax("Name", pValue, 64);
			ValidRegex("Name", pValue, @"^[a-zA-Z0-9_]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void Password(string pValue) {
			NotNull("Password", pValue);
			LenMin("Password", pValue, 8);
			LenMax("Password", pValue, 128);
			ValidRegex("Password", pValue, @"^[a-zA-Z0-9]*$");
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
		}

	}
		

	/*================================================================================================*/
	public class CreateFabVertexValidator : CreateFabElementValidator {
		
		
		private readonly CreateFabVertex vCreateObj;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateFabVertexValidator(CreateFabVertex pCreateObj) : base(pCreateObj) {
			vCreateObj = pCreateObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
			ValidateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ValidateEdges() {
		}

	}

}
