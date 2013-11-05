
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Domain;

namespace Fabric.New.Api.Objects {
		

	/*================================================================================================*/
	public class FabApp : FabArtifact {
		
		public virtual string Name { get; set; }
		
		public virtual string Secret { get; set; }


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
		
		public virtual string Name { get; set; }
		
		public virtual string Disamb { get; set; }
		
		public virtual string Note { get; set; }


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
		
		public virtual string Secret { get; set; }
		
		public virtual string Code { get; set; }
		
		public virtual bool Verified { get; set; }


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
	public class FabFactor : FabVertex {
		
		public virtual byte AssertionType { get; set; }
		
		public virtual bool IsDefining { get; set; }
		
		public virtual string Note { get; set; }

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
		
		public virtual byte Type { get; set; }

	}


	/*================================================================================================*/
	public class FabDirector : FabObject {
		
		public virtual byte Type { get; set; }
		
		public virtual byte PrimaryAction { get; set; }
		
		public virtual byte RelatedAction { get; set; }

	}


	/*================================================================================================*/
	public class FabEventor : FabObject {
		
		public virtual byte Type { get; set; }
		
		public virtual long Year { get; set; }
		
		public virtual byte? Month { get; set; }
		
		public virtual byte? Day { get; set; }
		
		public virtual byte? Hour { get; set; }
		
		public virtual byte? Minute { get; set; }
		
		public virtual byte? Second { get; set; }

	}


	/*================================================================================================*/
	public class FabIdentor : FabObject {
		
		public virtual byte Type { get; set; }
		
		public virtual string Value { get; set; }

	}


	/*================================================================================================*/
	public class FabLocator : FabObject {
		
		public virtual byte Type { get; set; }
		
		public virtual double ValueX { get; set; }
		
		public virtual double ValueY { get; set; }
		
		public virtual double ValueZ { get; set; }

	}


	/*================================================================================================*/
	public class FabVector : FabObject {
		
		public virtual byte Type { get; set; }
		
		public virtual byte Unit { get; set; }
		
		public virtual byte UnitPrefix { get; set; }
		
		public virtual long Value { get; set; }

	}
		

	/*================================================================================================*/
	public class FabInstance : FabArtifact {
		
		public virtual string Name { get; set; }
		
		public virtual string Disamb { get; set; }
		
		public virtual string Note { get; set; }


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
		
		public virtual byte Type { get; set; }


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
		
		public virtual string Name { get; set; }
		
		public virtual string FullPath { get; set; }


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
		
		public virtual string Name { get; set; }
		
		public virtual string Password { get; set; }


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
		
		public virtual long Id { get; set; }
		
		public virtual string IdStr { get; set; }
		
		public virtual float Timestamp { get; set; }
		
		public virtual byte VertexType { get; set; }


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
		
		//[Access(Internal)]
		public virtual string Name { get; set; }
		
		//[Access(Internal)]
		public virtual string Secret { get; set; }


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

			//Validate edges
		}

	}
		

	/*================================================================================================*/
	public class CreateFabArtifact : CreateFabVertex {
		
		//[Access(Internal)]
		public virtual long CreatedByMemberId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate edges
			ValidVertexId("CreatedBy", CreatedByMemberId);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabClass : CreateFabArtifact {
		
		//[Access(All)]
		public virtual string Name { get; set; }
		
		//[Access(All)]
		public virtual string Disamb { get; set; }
		
		//[Access(All)]
		public virtual string Note { get; set; }


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

			//Validate edges
		}

	}
		

	/*================================================================================================*/
	public class CreateFabEmail : CreateFabVertex {
		
		//[Access(Internal)]
		public virtual string Secret { get; set; }
		
		//[Access(Internal)]
		public virtual string Code { get; set; }
		
		//[Access(Internal)]
		public virtual bool Verified { get; set; }


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

			//Validate edges
		}

	}
		

	/*================================================================================================*/
	public class CreateFabFactor : CreateFabVertex {
		
		//[Access(All)]
		public virtual byte AssertionType { get; set; }
		
		//[Access(All)]
		public virtual bool IsDefining { get; set; }
		
		//[Access(All)]
		public virtual string Note { get; set; }
		
		//[Access(Internal)]
		public virtual long CreatedByMemberId { get; set; }
		
		//[Access(All)]
		public virtual long UsesPrimaryArtifactId { get; set; }
		
		//[Access(All)]
		public virtual long UsesRelatedArtifactId { get; set; }

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

			//Validate edges
			ValidVertexId("CreatedBy", CreatedByMemberId);
			ValidVertexId("UsesPrimary", UsesPrimaryArtifactId);
			ValidVertexId("UsesRelated", UsesRelatedArtifactId);
		}

	}


	/*================================================================================================*/
	public class CreateFabDescriptor : CreateFabObject {
		
		//[Access(All)]
		public virtual byte Type { get; set; }
		
		//[Access(All)]
		public virtual long? RefinesPrimaryWithArtifactId { get; set; }
		
		//[Access(All)]
		public virtual long? RefinesRelatedWithArtifactId { get; set; }
		
		//[Access(All)]
		public virtual long? RefinesTypeWithArtifactId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<FactorDescriptorType>("Descriptor.Type", Type);

			//Validate edges
			ValidVertexId("Descriptor.RefinesPrimaryWith", RefinesPrimaryWithArtifactId);
			ValidVertexId("Descriptor.RefinesRelatedWith", RefinesRelatedWithArtifactId);
			ValidVertexId("Descriptor.RefinesTypeWith", RefinesTypeWithArtifactId);
		}

	}


	/*================================================================================================*/
	public class CreateFabDirector : CreateFabObject {
		
		//[Access(All)]
		public virtual byte Type { get; set; }
		
		//[Access(All)]
		public virtual byte PrimaryAction { get; set; }
		
		//[Access(All)]
		public virtual byte RelatedAction { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<FactorDirectorType>("Director.Type", Type);

			//Validate PrimaryAction
			ValidEnum<FactorDirectorAction>("Director.PrimaryAction", PrimaryAction);

			//Validate RelatedAction
			ValidEnum<FactorDirectorAction>("Director.RelatedAction", RelatedAction);

			//Validate edges
		}

	}


	/*================================================================================================*/
	public class CreateFabEventor : CreateFabObject {
		
		//[Access(All)]
		public virtual byte Type { get; set; }
		
		//[Access(All)]
		public virtual long Year { get; set; }
		
		//[Access(All)]
		public virtual byte? Month { get; set; }
		
		//[Access(All)]
		public virtual byte? Day { get; set; }
		
		//[Access(All)]
		public virtual byte? Hour { get; set; }
		
		//[Access(All)]
		public virtual byte? Minute { get; set; }
		
		//[Access(All)]
		public virtual byte? Second { get; set; }


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

			//Validate edges
		}

	}


	/*================================================================================================*/
	public class CreateFabIdentor : CreateFabObject {
		
		//[Access(All)]
		public virtual byte Type { get; set; }
		
		//[Access(All)]
		public virtual string Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<FactorIdentorType>("Identor.Type", Type);

			//Validate Value
			LenMin("Identor.Value", Value, 1);
			LenMax("Identor.Value", Value, 256);

			//Validate edges
		}

	}


	/*================================================================================================*/
	public class CreateFabLocator : CreateFabObject {
		
		//[Access(All)]
		public virtual byte Type { get; set; }
		
		//[Access(All)]
		public virtual double ValueX { get; set; }
		
		//[Access(All)]
		public virtual double ValueY { get; set; }
		
		//[Access(All)]
		public virtual double ValueZ { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<FactorLocatorType>("Locator.Type", Type);

			//Validate ValueX

			//Validate ValueY

			//Validate ValueZ

			//Validate edges
		}

	}


	/*================================================================================================*/
	public class CreateFabVector : CreateFabObject {
		
		//[Access(All)]
		public virtual byte Type { get; set; }
		
		//[Access(All)]
		public virtual byte Unit { get; set; }
		
		//[Access(All)]
		public virtual byte UnitPrefix { get; set; }
		
		//[Access(All)]
		public virtual long Value { get; set; }
		
		//[Access(All)]
		public virtual long? UsesAxisArtifactId { get; set; }


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

			//Validate edges
			ValidVertexId("Vector.UsesAxis", UsesAxisArtifactId);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabInstance : CreateFabArtifact {
		
		//[Access(All)]
		public virtual string Name { get; set; }
		
		//[Access(All)]
		public virtual string Disamb { get; set; }
		
		//[Access(All)]
		public virtual string Note { get; set; }


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

			//Validate edges
		}

	}
		

	/*================================================================================================*/
	public class CreateFabMember : CreateFabVertex {
		
		//[Access(All)]
		public virtual byte Type { get; set; }
		
		//[Access(Internal)]
		public virtual long DefinedByAppId { get; set; }
		
		//[Access(Internal)]
		public virtual long DefinedByUserId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<MemberType>("Type", Type);

			//Validate edges
			ValidVertexId("DefinedBy", DefinedByAppId);
			ValidVertexId("DefinedBy", DefinedByUserId);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabOauthAccess : CreateFabVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate edges
		}

	}
		

	/*================================================================================================*/
	public class CreateFabOauthDomain : CreateFabVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate edges
		}

	}
		

	/*================================================================================================*/
	public class CreateFabOauthGrant : CreateFabVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate edges
		}

	}
		

	/*================================================================================================*/
	public class CreateFabOauthScope : CreateFabVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate edges
		}

	}
		

	/*================================================================================================*/
	public class CreateFabUrl : CreateFabArtifact {
		
		//[Access(All)]
		public virtual string Name { get; set; }
		
		//[Access(All)]
		public virtual string FullPath { get; set; }


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

			//Validate edges
		}

	}
		

	/*================================================================================================*/
	public class CreateFabUser : CreateFabArtifact {
		
		//[Access(Internal)]
		public virtual string Name { get; set; }
		
		//[Access(Internal)]
		public virtual string Password { get; set; }


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

			//Validate edges
		}

	}
		

	/*================================================================================================*/
	public class CreateFabVertex : CreateFabObject {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate edges
		}

	}

}
