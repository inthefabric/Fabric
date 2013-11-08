
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Domain;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class ApiToDomain {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabObject(Vertex pDomain, CreateFabObject pApi) {
			//do nothing...
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static App FromCreateFabApp(CreateFabApp pApi) {
			var dom = new App();
			FromCreateFabApp(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabApp(App pDomain, CreateFabApp pApi) {
			FromCreateFabArtifact(pDomain, pApi);
			//Custom: Set Domain.NameKey = Api.Name.ToLower()
			//pDomain.Name <== pApi.Name  (requires custom)
			pDomain.Secret = pApi.Secret;
			pDomain.OauthDomains = pApi.OauthDomains;
			FromCreateFabAppCustom(pDomain, pApi);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Artifact FromCreateFabArtifact(CreateFabArtifact pApi) {
			var dom = new Artifact();
			FromCreateFabArtifact(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabArtifact(Artifact pDomain, CreateFabArtifact pApi) {
			FromCreateFabVertex(pDomain, pApi);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Class FromCreateFabClass(CreateFabClass pApi) {
			var dom = new Class();
			FromCreateFabClass(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabClass(Class pDomain, CreateFabClass pApi) {
			FromCreateFabArtifact(pDomain, pApi);
			pDomain.Name = pApi.Name;
			pDomain.Disamb = pApi.Disamb;
			pDomain.Note = pApi.Note;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Email FromCreateFabEmail(CreateFabEmail pApi) {
			var dom = new Email();
			FromCreateFabEmail(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabEmail(Email pDomain, CreateFabEmail pApi) {
			FromCreateFabVertex(pDomain, pApi);
			pDomain.Address = pApi.Secret;
			pDomain.Code = pApi.Code;
			pDomain.Verified = pApi.Verified;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Factor FromCreateFabFactor(CreateFabFactor pApi) {
			var dom = new Factor();
			FromCreateFabFactor(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabFactor(Factor pDomain, CreateFabFactor pApi) {
			FromCreateFabVertex(pDomain, pApi);
			pDomain.AssertionType = pApi.AssertionType;
			pDomain.IsDefining = pApi.IsDefining;
			pDomain.Note = pApi.Note;
			if ( pApi.Identor != null ) { pDomain.Note = pApi.Identor.Value; }
			if ( pApi.Descriptor != null ) { pDomain.DescriptorType = pApi.Descriptor.Type; }
			if ( pApi.Director != null ) { pDomain.DirectorType = pApi.Director.Type; }
			if ( pApi.Director != null ) { pDomain.DirectorPrimaryAction = pApi.Director.PrimaryAction; }
			if ( pApi.Director != null ) { pDomain.DirectorRelatedAction = pApi.Director.RelatedAction; }
			if ( pApi.Eventor != null ) { pDomain.EventorType = pApi.Eventor.Type; }
			//Custom: Set Domain.EventorDateTime using Api.Year/Month/etc.
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			//Custom: 
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			//Custom: 
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			//Custom: 
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			//Custom: 
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			//Custom: 
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			if ( pApi.Identor != null ) { pDomain.IdentorType = pApi.Identor.Type; }
			if ( pApi.Locator != null ) { pDomain.LocatorType = pApi.Locator.Type; }
			if ( pApi.Locator != null ) { pDomain.LocatorValueX = pApi.Locator.ValueX; }
			if ( pApi.Locator != null ) { pDomain.LocatorValueY = pApi.Locator.ValueY; }
			if ( pApi.Locator != null ) { pDomain.LocatorValueZ = pApi.Locator.ValueZ; }
			if ( pApi.Vector != null ) { pDomain.VectorType = pApi.Vector.Type; }
			if ( pApi.Vector != null ) { pDomain.VectorUnit = pApi.Vector.Unit; }
			if ( pApi.Vector != null ) { pDomain.VectorUnitPrefix = pApi.Vector.UnitPrefix; }
			if ( pApi.Vector != null ) { pDomain.VectorValue = pApi.Vector.Value; }
			FromCreateFabFactorCustom(pDomain, pApi);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Instance FromCreateFabInstance(CreateFabInstance pApi) {
			var dom = new Instance();
			FromCreateFabInstance(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabInstance(Instance pDomain, CreateFabInstance pApi) {
			FromCreateFabArtifact(pDomain, pApi);
			pDomain.Name = pApi.Name;
			pDomain.Disamb = pApi.Disamb;
			pDomain.Note = pApi.Note;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Member FromCreateFabMember(CreateFabMember pApi) {
			var dom = new Member();
			FromCreateFabMember(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabMember(Member pDomain, CreateFabMember pApi) {
			FromCreateFabVertex(pDomain, pApi);
			pDomain.MemberType = pApi.Type;
			pDomain.OauthScopeAllow = pApi.OauthScopeAllow;
			pDomain.OauthGrantRedirectUri = pApi.OauthGrantRedirectUri;
			pDomain.OauthGrantCode = pApi.OauthGrantCode;
			pDomain.OauthGrantExpires = pApi.OauthGrantExpires;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static OauthAccess FromCreateFabOauthAccess(CreateFabOauthAccess pApi) {
			var dom = new OauthAccess();
			FromCreateFabOauthAccess(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabOauthAccess(OauthAccess pDomain, CreateFabOauthAccess pApi) {
			FromCreateFabVertex(pDomain, pApi);
			pDomain.Token = pApi.Token;
			pDomain.Refresh = pApi.Refresh;
			pDomain.Expires = pApi.Expires;
			pDomain.IsClientOnly = pApi.IsClientOnly;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Url FromCreateFabUrl(CreateFabUrl pApi) {
			var dom = new Url();
			FromCreateFabUrl(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabUrl(Url pDomain, CreateFabUrl pApi) {
			FromCreateFabArtifact(pDomain, pApi);
			pDomain.Name = pApi.Name;
			pDomain.FullPath = pApi.FullPath;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static User FromCreateFabUser(CreateFabUser pApi) {
			var dom = new User();
			FromCreateFabUser(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabUser(User pDomain, CreateFabUser pApi) {
			FromCreateFabArtifact(pDomain, pApi);
			//Custom: Encrypt Api.Password.
			//pDomain.Name <== pApi.Name  (requires custom)
			//Custom: 
			//pDomain.Password <== pApi.Password  (requires custom)
			FromCreateFabUserCustom(pDomain, pApi);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Vertex FromCreateFabVertex(CreateFabVertex pApi) {
			var dom = new Vertex();
			FromCreateFabVertex(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabVertex(Vertex pDomain, CreateFabVertex pApi) {
			FromCreateFabObject(pDomain, pApi);
		}

	}

}