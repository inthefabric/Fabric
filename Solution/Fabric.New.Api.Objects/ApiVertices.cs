
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;

namespace Fabric.New.Api.Objects {
		

	/*================================================================================================*/
	public class FabApp : FabArtifact {
		
		public virtual string Name { get; set; }
		
		public virtual string Secret { get; set; }
		
		public virtual string OauthDomains { get; set; }


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
		
		public virtual bool? OauthScopeAllow { get; set; }
		
		public virtual string OauthGrantRedirectUri { get; set; }
		
		public virtual string OauthGrantCode { get; set; }
		
		public virtual long? OauthGrantExpires { get; set; }


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
		
		public virtual string Token { get; set; }
		
		public virtual string Refresh { get; set; }
		
		public virtual long Expires { get; set; }
		
		public virtual bool IsClientOnly { get; set; }


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
		
		//[Access(Internal)]
		public virtual string OauthDomains { get; set; }


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

			//Validate OauthDomains
			NotNull("OauthDomains", OauthDomains);
			ApiVerticesCustom.ValidateAppOauthDomains(this, "OauthDomains", OauthDomains);

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
			ValidVertexId("CreatedByMemberId", CreatedByMemberId);
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
		
		//[Access(Internal)]
		public virtual long UsedByArtifactId { get; set; }


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
			ValidVertexId("UsedByArtifactId", UsedByArtifactId);
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
			ValidEnum<FactorAssertion.Id>("AssertionType", AssertionType);

			//Validate IsDefining

			//Validate Note
			LenMin("Note", Note, 1);
			LenMax("Note", Note, 256);

			//Validate edges
			ValidVertexId("CreatedByMemberId", CreatedByMemberId);
			ValidVertexId("UsesPrimaryArtifactId", UsesPrimaryArtifactId);
			ValidVertexId("UsesRelatedArtifactId", UsesRelatedArtifactId);
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
			ValidEnum<DescriptorType.Id>("Descriptor.Type", Type);

			//Validate edges
			ValidVertexId("Descriptor.RefinesPrimaryWithArtifactId", RefinesPrimaryWithArtifactId);
			ValidVertexId("Descriptor.RefinesRelatedWithArtifactId", RefinesRelatedWithArtifactId);
			ValidVertexId("Descriptor.RefinesTypeWithArtifactId", RefinesTypeWithArtifactId);
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
			ValidEnum<DirectorType.Id>("Director.Type", Type);

			//Validate PrimaryAction
			ValidEnum<DirectorAction.Id>("Director.PrimaryAction", PrimaryAction);

			//Validate RelatedAction
			ValidEnum<DirectorAction.Id>("Director.RelatedAction", RelatedAction);

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
			ValidEnum<EventorType.Id>("Eventor.Type", Type);

			//Validate Year
			ApiVerticesCustom.ValidateFactorEventorYear(this, "Eventor.Year", Year);

			//Validate Month
			ApiVerticesCustom.ValidateFactorEventorMonth(this, "Eventor.Month", Month);

			//Validate Day
			ApiVerticesCustom.ValidateFactorEventorDay(this, "Eventor.Day", Day);

			//Validate Hour
			ApiVerticesCustom.ValidateFactorEventorHour(this, "Eventor.Hour", Hour);

			//Validate Minute
			ApiVerticesCustom.ValidateFactorEventorMinute(this, "Eventor.Minute", Minute);

			//Validate Second
			ApiVerticesCustom.ValidateFactorEventorSecond(this, "Eventor.Second", Second);

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
			ValidEnum<IdentorType.Id>("Identor.Type", Type);

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
			ValidEnum<LocatorType.Id>("Locator.Type", Type);

			//Validate ValueX
			ApiVerticesCustom.ValidateFactorLocatorValueX(this, "Locator.ValueX", ValueX);

			//Validate ValueY
			ApiVerticesCustom.ValidateFactorLocatorValueY(this, "Locator.ValueY", ValueY);

			//Validate ValueZ
			ApiVerticesCustom.ValidateFactorLocatorValueZ(this, "Locator.ValueZ", ValueZ);

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
			ValidEnum<VectorType.Id>("Vector.Type", Type);

			//Validate Unit
			ValidEnum<VectorUnit.Id>("Vector.Unit", Unit);

			//Validate UnitPrefix
			ValidEnum<VectorUnitPrefix.Id>("Vector.UnitPrefix", UnitPrefix);

			//Validate Value
			ApiVerticesCustom.ValidateFactorVectorValue(this, "Vector.Value", Value);

			//Validate edges
			ValidVertexId("Vector.UsesAxisArtifactId", UsesAxisArtifactId);
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
		public virtual bool? OauthScopeAllow { get; set; }
		
		//[Access(Internal)]
		public virtual string OauthGrantRedirectUri { get; set; }
		
		//[Access(Internal)]
		public virtual string OauthGrantCode { get; set; }
		
		//[Access(Internal)]
		public virtual long? OauthGrantExpires { get; set; }
		
		//[Access(Internal)]
		public virtual long DefinedByAppId { get; set; }
		
		//[Access(Internal)]
		public virtual long DefinedByUserId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Type
			ValidEnum<MemberType.Id>("Type", Type);

			//Validate OauthScopeAllow

			//Validate OauthGrantRedirectUri
			LenMin("OauthGrantRedirectUri", OauthGrantRedirectUri, 1);
			LenMax("OauthGrantRedirectUri", OauthGrantRedirectUri, 1024);

			//Validate OauthGrantCode
			LenMin("OauthGrantCode", OauthGrantCode, 32);
			LenMax("OauthGrantCode", OauthGrantCode, 32);
			ValidRegex("OauthGrantCode", OauthGrantCode,
				@"^[a-zA-Z0-9]*$");

			//Validate OauthGrantExpires

			//Validate edges
			ValidVertexId("DefinedByAppId", DefinedByAppId);
			ValidVertexId("DefinedByUserId", DefinedByUserId);
		}

	}
		

	/*================================================================================================*/
	public class CreateFabOauthAccess : CreateFabVertex {
		
		//[Access(Internal)]
		public virtual string Token { get; set; }
		
		//[Access(Internal)]
		public virtual string Refresh { get; set; }
		
		//[Access(Internal)]
		public virtual long Expires { get; set; }
		
		//[Access(Internal)]
		public virtual bool IsClientOnly { get; set; }
		
		//[Access(Internal)]
		public virtual long AuthenticatesMemberId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			base.Validate();

			//Validate Token
			LenMin("Token", Token, 32);
			LenMax("Token", Token, 32);
			ValidRegex("Token", Token,
				@"^[a-zA-Z0-9]*$");

			//Validate Refresh
			LenMin("Refresh", Refresh, 32);
			LenMax("Refresh", Refresh, 32);
			ValidRegex("Refresh", Refresh,
				@"^[a-zA-Z0-9]*$");

			//Validate Expires

			//Validate IsClientOnly

			//Validate edges
			ValidVertexId("AuthenticatesMemberId", AuthenticatesMemberId);
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
