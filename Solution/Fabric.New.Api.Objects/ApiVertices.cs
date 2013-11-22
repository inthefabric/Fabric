
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Spec;

namespace Fabric.New.Api.Objects {
		

	/*================================================================================================*/
	public class FabApp : FabArtifact {
		
		[SpecLen(3, 64)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		[SpecUnique]
		public virtual string Name { get; set; }


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
		
		[SpecLen(1, 128)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		public virtual string Name { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 128)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		public virtual string Disamb { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 256)]
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
		

	/*================================================================================================*/
	public class FabFactor : FabVertex {
		
		[SpecFromEnum("FactorAssertion")]
		public virtual byte AssertionType { get; set; }
		
		public virtual bool IsDefining { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 256)]
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

		
		[SpecFromEnum("DescriptorType")]
		public virtual byte Type { get; set; }

	}


	/*================================================================================================*/
	public class FabDirector : FabObject {

		
		[SpecFromEnum("DirectorType")]
		public virtual byte Type { get; set; }
		
		[SpecFromEnum("DirectorAction")]
		public virtual byte PrimaryAction { get; set; }
		
		[SpecFromEnum("DirectorAction")]
		public virtual byte RelatedAction { get; set; }

	}


	/*================================================================================================*/
	public class FabEventor : FabObject {

		
		[SpecFromEnum("EventorType")]
		public virtual byte Type { get; set; }
		
		public virtual long Year { get; set; }
		
		[SpecOptional]
		public virtual byte? Month { get; set; }
		
		[SpecOptional]
		public virtual byte? Day { get; set; }
		
		[SpecOptional]
		public virtual byte? Hour { get; set; }
		
		[SpecOptional]
		public virtual byte? Minute { get; set; }
		
		[SpecOptional]
		public virtual byte? Second { get; set; }

	}


	/*================================================================================================*/
	public class FabIdentor : FabObject {

		
		[SpecFromEnum("IdentorType")]
		public virtual byte Type { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 256)]
		public virtual string Value { get; set; }

	}


	/*================================================================================================*/
	public class FabLocator : FabObject {

		
		[SpecFromEnum("LocatorType")]
		public virtual byte Type { get; set; }
		
		public virtual double ValueX { get; set; }
		
		public virtual double ValueY { get; set; }
		
		public virtual double ValueZ { get; set; }

	}


	/*================================================================================================*/
	public class FabVector : FabObject {

		
		[SpecFromEnum("VectorType")]
		public virtual byte Type { get; set; }
		
		[SpecFromEnum("VectorUnit")]
		public virtual byte Unit { get; set; }
		
		[SpecFromEnum("VectorUnitPrefix")]
		public virtual byte UnitPrefix { get; set; }
		
		public virtual long Value { get; set; }

	}
		

	/*================================================================================================*/
	public class FabInstance : FabArtifact {
		
		[SpecOptional]
		[SpecLen(1, 128)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		public virtual string Name { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 128)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		public virtual string Disamb { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 256)]
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
		
		[SpecFromEnum("MemberType")]
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
		

	/*================================================================================================*/
	public class FabUrl : FabArtifact {
		
		[SpecOptional]
		[SpecLen(1, 128)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		public virtual string Name { get; set; }
		
		[SpecLen(1, 2048)]
		[SpecUnique]
		[SpecToLowerCase]
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
		
		[SpecLen(3, 64)]
		[SpecRegex(@"^[a-zA-Z0-9_]*$")]
		[SpecUnique]
		public virtual string Name { get; set; }


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
	public class FabVertex : FabElement {
		
		[SpecUnique]
		public virtual long Id { get; set; }
		
		public virtual long Timestamp { get; set; }
		
		[SpecFromEnum("VertexType")]
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
	[SpecInternal]
	public class CreateFabApp : CreateFabArtifact {
		
		[SpecInternal]
		[SpecLen(3, 64)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		[SpecUnique]
		public virtual string Name { get; set; }
		
		[SpecInternal]
		[SpecLen(32, 32)]
		[SpecRegex(@"^[a-zA-Z0-9]*$")]
		public virtual string Secret { get; set; }
		
		[SpecInternal]
		public virtual string OauthDomains { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabAppValidator(this).Validate();
		}

	}
		

	/*================================================================================================*/
	[SpecInternal]
	public class CreateFabArtifact : CreateFabVertex {
		
		[SpecInternal]
		public virtual long CreatedByMemberId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabArtifactValidator(this).Validate();
		}

	}
		

	/*================================================================================================*/
	public class CreateFabClass : CreateFabArtifact {
		
		[SpecLen(1, 128)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		public virtual string Name { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 128)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		public virtual string Disamb { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 256)]
		public virtual string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabClassValidator(this).Validate();
		}

	}
		

	/*================================================================================================*/
	[SpecInternal]
	public class CreateFabEmail : CreateFabVertex {
		
		[SpecInternal]
		[SpecLen(1, 256)]
		[SpecRegex(@"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$")]
		[SpecToLowerCase]
		public virtual string Address { get; set; }
		
		[SpecInternal]
		[SpecLen(32, 32)]
		[SpecRegex(@"^[a-zA-Z0-9]*$")]
		public virtual string Code { get; set; }
		
		[SpecInternal]
		public virtual bool Verified { get; set; }
		
		public virtual long UsedByArtifactId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabEmailValidator(this).Validate();
		}

	}
		

	/*================================================================================================*/
	public class CreateFabFactor : CreateFabVertex {
		
		[SpecFromEnum("FactorAssertion")]
		public virtual byte AssertionType { get; set; }
		
		public virtual bool IsDefining { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 256)]
		public virtual string Note { get; set; }
		
		[SpecInternal]
		public virtual long CreatedByMemberId { get; set; }
		
		public virtual long UsesPrimaryArtifactId { get; set; }
		
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
			new CreateFabFactorValidator(this).Validate();
		}

	}


	/*================================================================================================*/
	public class CreateFabDescriptor : CreateFabObject {

		
		[SpecFromEnum("DescriptorType")]
		public virtual byte Type { get; set; }
		
		[SpecOptional]
		public virtual long? RefinesPrimaryWithArtifactId { get; set; }
		
		[SpecOptional]
		public virtual long? RefinesRelatedWithArtifactId { get; set; }
		
		[SpecOptional]
		public virtual long? RefinesTypeWithArtifactId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabDescriptorValidator(this).Validate();
		}

	}


	/*================================================================================================*/
	public class CreateFabDirector : CreateFabObject {

		
		[SpecFromEnum("DirectorType")]
		public virtual byte Type { get; set; }
		
		[SpecFromEnum("DirectorAction")]
		public virtual byte PrimaryAction { get; set; }
		
		[SpecFromEnum("DirectorAction")]
		public virtual byte RelatedAction { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabDirectorValidator(this).Validate();
		}

	}


	/*================================================================================================*/
	public class CreateFabEventor : CreateFabObject {

		
		[SpecFromEnum("EventorType")]
		public virtual byte Type { get; set; }
		
		public virtual long Year { get; set; }
		
		[SpecOptional]
		public virtual byte? Month { get; set; }
		
		[SpecOptional]
		public virtual byte? Day { get; set; }
		
		[SpecOptional]
		public virtual byte? Hour { get; set; }
		
		[SpecOptional]
		public virtual byte? Minute { get; set; }
		
		[SpecOptional]
		public virtual byte? Second { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabEventorValidator(this).Validate();
		}

	}


	/*================================================================================================*/
	public class CreateFabIdentor : CreateFabObject {

		
		[SpecFromEnum("IdentorType")]
		public virtual byte Type { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 256)]
		public virtual string Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabIdentorValidator(this).Validate();
		}

	}


	/*================================================================================================*/
	public class CreateFabLocator : CreateFabObject {

		
		[SpecFromEnum("LocatorType")]
		public virtual byte Type { get; set; }
		
		public virtual double ValueX { get; set; }
		
		public virtual double ValueY { get; set; }
		
		public virtual double ValueZ { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabLocatorValidator(this).Validate();
		}

	}


	/*================================================================================================*/
	public class CreateFabVector : CreateFabObject {

		
		[SpecFromEnum("VectorType")]
		public virtual byte Type { get; set; }
		
		[SpecFromEnum("VectorUnit")]
		public virtual byte Unit { get; set; }
		
		[SpecFromEnum("VectorUnitPrefix")]
		public virtual byte UnitPrefix { get; set; }
		
		public virtual long Value { get; set; }
		
		[SpecOptional]
		public virtual long? UsesAxisArtifactId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabVectorValidator(this).Validate();
		}

	}
		

	/*================================================================================================*/
	public class CreateFabInstance : CreateFabArtifact {
		
		[SpecOptional]
		[SpecLen(1, 128)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		public virtual string Name { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 128)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		public virtual string Disamb { get; set; }
		
		[SpecOptional]
		[SpecLen(1, 256)]
		public virtual string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabInstanceValidator(this).Validate();
		}

	}
		

	/*================================================================================================*/
	public class CreateFabMember : CreateFabVertex {
		
		[SpecFromEnum("MemberType")]
		public virtual byte Type { get; set; }
		
		[SpecInternal]
		[SpecOptional]
		public virtual bool? OauthScopeAllow { get; set; }
		
		[SpecInternal]
		[SpecOptional]
		[SpecLen(1, 1024)]
		[SpecToLowerCase]
		public virtual string OauthGrantRedirectUri { get; set; }
		
		[SpecInternal]
		[SpecOptional]
		[SpecLen(32, 32)]
		[SpecRegex(@"^[a-zA-Z0-9]*$")]
		public virtual string OauthGrantCode { get; set; }
		
		[SpecInternal]
		[SpecOptional]
		public virtual long? OauthGrantExpires { get; set; }
		
		public virtual long DefinedByAppId { get; set; }
		
		public virtual long DefinedByUserId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabMemberValidator(this).Validate();
		}

	}
		

	/*================================================================================================*/
	[SpecInternal]
	public class CreateFabOauthAccess : CreateFabVertex {
		
		[SpecInternal]
		[SpecOptional]
		[SpecLen(32, 32)]
		[SpecRegex(@"^[a-zA-Z0-9]*$")]
		[SpecUnique]
		public virtual string Token { get; set; }
		
		[SpecInternal]
		[SpecOptional]
		[SpecLen(32, 32)]
		[SpecRegex(@"^[a-zA-Z0-9]*$")]
		[SpecUnique]
		public virtual string Refresh { get; set; }
		
		[SpecInternal]
		public virtual long Expires { get; set; }
		
		[SpecInternal]
		public virtual bool IsDataProv { get; set; }
		
		public virtual long AuthenticatesMemberId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabOauthAccessValidator(this).Validate();
		}

	}
		

	/*================================================================================================*/
	public class CreateFabUrl : CreateFabArtifact {
		
		[SpecOptional]
		[SpecLen(1, 128)]
		[SpecRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$")]
		public virtual string Name { get; set; }
		
		[SpecLen(1, 2048)]
		[SpecUnique]
		[SpecToLowerCase]
		public virtual string FullPath { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabUrlValidator(this).Validate();
		}

	}
		

	/*================================================================================================*/
	[SpecInternal]
	public class CreateFabUser : CreateFabArtifact {
		
		[SpecInternal]
		[SpecLen(3, 64)]
		[SpecRegex(@"^[a-zA-Z0-9_]*$")]
		[SpecUnique]
		public virtual string Name { get; set; }
		
		[SpecInternal]
		[SpecLen(8, 128)]
		[SpecRegex(@"^[a-zA-Z0-9]*$")]
		public virtual string Password { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabUserValidator(this).Validate();
		}

	}
		

	/*================================================================================================*/
	[SpecInternal]
	public class CreateFabVertex : CreateFabElement {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Validate() {
			new CreateFabVertexValidator(this).Validate();
		}

	}

}
