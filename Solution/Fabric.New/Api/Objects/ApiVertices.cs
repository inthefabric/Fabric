
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Domain;

namespace Fabric.New.Api.Objects {
		

	/*================================================================================================*/
	public class FabApp : FabArtifact {

		public string Name { get; set; }
		public string Secret { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromApp(this, (App)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabApp FromApp(App pVertex) {
			var v = new FabApp();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabArtifact : FabVertex {



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromArtifact(this, (Artifact)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabArtifact FromArtifact(Artifact pVertex) {
			var v = new FabArtifact();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabClass : FabArtifact {

		public string Name { get; set; }
		public string Disamb { get; set; }
		public string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromClass(this, (Class)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabClass FromClass(Class pVertex) {
			var v = new FabClass();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabEmail : FabVertex {

		public string Secret { get; set; }
		public string Code { get; set; }
		public bool Verified { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromEmail(this, (Email)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabEmail FromEmail(Email pVertex) {
			var v = new FabEmail();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabFactor : FabArtifact {

		public byte AssertionType { get; set; }
		public bool IsDefining { get; set; }
		public string Note { get; set; }
		public FabDescriptor Descriptor { get; set; }
		public FabDirector Director { get; set; }
		public FabEventor Eventor { get; set; }
		public FabIdentor Identor { get; set; }
		public FabLocator Locator { get; set; }
		public FabVector Vector { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromFactor(this, (Factor)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabFactor FromFactor(Factor pVertex) {
			var v = new FabFactor();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabDescriptor : FabObject {

		public byte Type { get; set; }

	}


	/*================================================================================================*/
	public class FabDirector : FabObject {

		public byte DirectorType { get; set; }
		public byte PrimaryAction { get; set; }
		public byte RelatedAction { get; set; }

	}


	/*================================================================================================*/
	public class FabEventor : FabObject {

		public byte Type { get; set; }
		public long Year { get; set; }
		public byte? Month { get; set; }
		public byte? Day { get; set; }
		public byte? Hour { get; set; }
		public byte? Minute { get; set; }
		public byte? Second { get; set; }

	}


	/*================================================================================================*/
	public class FabIdentor : FabObject {

		public byte Type { get; set; }
		public string Value { get; set; }

	}


	/*================================================================================================*/
	public class FabLocator : FabObject {

		public byte Type { get; set; }
		public double ValueX { get; set; }
		public double ValueY { get; set; }
		public double ValueZ { get; set; }

	}


	/*================================================================================================*/
	public class FabVector : FabObject {

		public byte Type { get; set; }
		public byte Unit { get; set; }
		public byte UnitPrefix { get; set; }
		public long Value { get; set; }

	}
		

	/*================================================================================================*/
	public class FabInstance : FabArtifact {

		public string Name { get; set; }
		public string Disamb { get; set; }
		public string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromInstance(this, (Instance)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabInstance FromInstance(Instance pVertex) {
			var v = new FabInstance();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabMember : FabVertex {

		public byte Type { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromMember(this, (Member)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabMember FromMember(Member pVertex) {
			var v = new FabMember();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabOauthAccess : FabVertex {



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromOauthAccess(this, (OauthAccess)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabOauthAccess FromOauthAccess(OauthAccess pVertex) {
			var v = new FabOauthAccess();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabOauthDomain : FabVertex {



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromOauthDomain(this, (OauthDomain)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabOauthDomain FromOauthDomain(OauthDomain pVertex) {
			var v = new FabOauthDomain();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabOauthGrant : FabVertex {



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromOauthGrant(this, (OauthGrant)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabOauthGrant FromOauthGrant(OauthGrant pVertex) {
			var v = new FabOauthGrant();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabOauthScope : FabVertex {



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromOauthScope(this, (OauthScope)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabOauthScope FromOauthScope(OauthScope pVertex) {
			var v = new FabOauthScope();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabUrl : FabArtifact {

		public string Name { get; set; }
		public string FullPath { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromUrl(this, (Url)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabUrl FromUrl(Url pVertex) {
			var v = new FabUrl();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabUser : FabArtifact {

		public string Name { get; set; }
		public string Password { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromUser(this, (User)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabUser FromUser(User pVertex) {
			var v = new FabUser();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class FabVertex : FabObject {

		public long Id { get; set; }
		public string IdStr { get; set; }
		public float Timestamp { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromVertex(this, (Vertex)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabVertex FromVertex(Vertex pVertex) {
			var v = new FabVertex();
			v.Fill(pVertex);
			return v;
		}

	}
		

	/*================================================================================================*/
	public class CreateFabApp : CreateFabArtifact {

		public string Name { get; set; }
		public string Secret { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Name
			NotNull("Name", Name);
			LenMin("Name", Name, 3);
			LenMax("Name", Name, 64);
			ValidRegex("Name", Name,
				@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");

			//Validate Secret
			NotNull("Secret", Secret);
			LenMin("Secret", Secret, 32);
			LenMax("Secret", Secret, 32);
			ValidRegex("Secret", Secret,
				@"^[a-zA-Z0-9]*$");
		}

	}
		

	/*================================================================================================*/
	public class CreateFabArtifact : CreateFabVertex {



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
		}

	}
		

	/*================================================================================================*/
	public class CreateFabClass : CreateFabArtifact {

		public string Name { get; set; }
		public string Disamb { get; set; }
		public string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Name
			NotNull("Name", Name);
			LenMin("Name", Name, 1);
			LenMax("Name", Name, 128);
			ValidRegex("Name", Name,
				@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");

			//Validate Disamb
			LenMin("Disamb", Disamb, 1);
			LenMax("Disamb", Disamb, 128);
			ValidRegex("Disamb", Disamb,
				@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");

			//Validate Note
			LenMin("Note", Note, 1);
			LenMax("Note", Note, 256);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabEmail : CreateFabVertex {

		public string Secret { get; set; }
		public string Code { get; set; }
		public bool Verified { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Secret
			NotNull("Secret", Secret);
			LenMin("Secret", Secret, 1);
			LenMax("Secret", Secret, 256);
			ValidRegex("Secret", Secret,
				@"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");

			//Validate Code
			NotNull("Code", Code);
			LenMin("Code", Code, 32);
			LenMax("Code", Code, 32);
			ValidRegex("Code", Code,
				@"^[a-zA-Z0-9]*$");

			//Validate Verified
		}

	}
		

	/*================================================================================================*/
	public class CreateFabFactor : CreateFabArtifact {

		public byte AssertionType { get; set; }
		public bool IsDefining { get; set; }
		public string Note { get; set; }
		public CreateFabDescriptor Descriptor { get; set; }
		public CreateFabDirector Director { get; set; }
		public CreateFabEventor Eventor { get; set; }
		public CreateFabIdentor Identor { get; set; }
		public CreateFabLocator Locator { get; set; }
		public CreateFabVector Vector { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate AssertionType
			ValidEnum<FactorAssertionType>("AssertionType", AssertionType);

			//Validate IsDefining

			//Validate Note
			LenMin("Note", Note, 1);
			LenMax("Note", Note, 256);
		}

	}


	/*================================================================================================*/
	public class CreateFabDescriptor : CreateFabObject {

		public byte Type { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<FactorDescriptorType>("Descriptor.Type", Type);
		}

	}


	/*================================================================================================*/
	public class CreateFabDirector : CreateFabObject {

		public byte DirectorType { get; set; }
		public byte PrimaryAction { get; set; }
		public byte RelatedAction { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate DirectorType
			ValidEnum<FactorDirectorType>("Director.DirectorType", DirectorType);

			//Validate PrimaryAction
			ValidEnum<FactorDirectorAction>("Director.PrimaryAction", PrimaryAction);

			//Validate RelatedAction
			ValidEnum<FactorDirectorAction>("Director.RelatedAction", RelatedAction);
		}

	}


	/*================================================================================================*/
	public class CreateFabEventor : CreateFabObject {

		public byte Type { get; set; }
		public long Year { get; set; }
		public byte? Month { get; set; }
		public byte? Day { get; set; }
		public byte? Hour { get; set; }
		public byte? Minute { get; set; }
		public byte? Second { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<FactorEventorType>("Eventor.Type", Type);

			//Validate Year

			//Validate Month

			//Validate Day

			//Validate Hour

			//Validate Minute

			//Validate Second
		}

	}


	/*================================================================================================*/
	public class CreateFabIdentor : CreateFabObject {

		public byte Type { get; set; }
		public string Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<FactorIdentorType>("Identor.Type", Type);

			//Validate Value
			LenMin("Identor.Value", Value, 1);
			LenMax("Identor.Value", Value, 256);
		}

	}


	/*================================================================================================*/
	public class CreateFabLocator : CreateFabObject {

		public byte Type { get; set; }
		public double ValueX { get; set; }
		public double ValueY { get; set; }
		public double ValueZ { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<FactorLocatorType>("Locator.Type", Type);

			//Validate ValueX

			//Validate ValueY

			//Validate ValueZ
		}

	}


	/*================================================================================================*/
	public class CreateFabVector : CreateFabObject {

		public byte Type { get; set; }
		public byte Unit { get; set; }
		public byte UnitPrefix { get; set; }
		public long Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<FactorVectorType>("Vector.Type", Type);

			//Validate Unit
			ValidEnum<FactorVectorUnit>("Vector.Unit", Unit);

			//Validate UnitPrefix
			ValidEnum<FactorVectorUnitPrefix>("Vector.UnitPrefix", UnitPrefix);

			//Validate Value
		}

	}
		

	/*================================================================================================*/
	public class CreateFabInstance : CreateFabArtifact {

		public string Name { get; set; }
		public string Disamb { get; set; }
		public string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Name
			LenMin("Name", Name, 1);
			LenMax("Name", Name, 128);
			ValidRegex("Name", Name,
				@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");

			//Validate Disamb
			LenMin("Disamb", Disamb, 1);
			LenMax("Disamb", Disamb, 128);
			ValidRegex("Disamb", Disamb,
				@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");

			//Validate Note
			LenMin("Note", Note, 1);
			LenMax("Note", Note, 256);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabMember : CreateFabVertex {

		public byte Type { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<MemberType>("Type", Type);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabOauthAccess : CreateFabVertex {



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
		}

	}
		

	/*================================================================================================*/
	public class CreateFabOauthDomain : CreateFabVertex {



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
		}

	}
		

	/*================================================================================================*/
	public class CreateFabOauthGrant : CreateFabVertex {



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
		}

	}
		

	/*================================================================================================*/
	public class CreateFabOauthScope : CreateFabVertex {



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
		}

	}
		

	/*================================================================================================*/
	public class CreateFabUrl : CreateFabArtifact {

		public string Name { get; set; }
		public string FullPath { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Name
			LenMin("Name", Name, 1);
			LenMax("Name", Name, 128);
			ValidRegex("Name", Name,
				@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$");

			//Validate FullPath
			NotNull("FullPath", FullPath);
			LenMin("FullPath", FullPath, 1);
			LenMax("FullPath", FullPath, 2048);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabUser : CreateFabArtifact {

		public string Name { get; set; }
		public string Password { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Name
			NotNull("Name", Name);
			LenMin("Name", Name, 3);
			LenMax("Name", Name, 64);
			ValidRegex("Name", Name,
				@"^[a-zA-Z0-9_]*$");

			//Validate Password
			NotNull("Password", Password);
			LenMin("Password", Password, 8);
			LenMax("Password", Password, 128);
			ValidRegex("Password", Password,
				@"^[a-zA-Z0-9]*$");
		}

	}
		

	/*================================================================================================*/
	public class CreateFabVertex : CreateFabObject {



		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();
		}

	}

}
