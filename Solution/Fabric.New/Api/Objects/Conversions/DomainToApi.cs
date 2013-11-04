
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Domain;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class DomainToApi {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromObject(FabObject pApi, Vertex pDomain) {
			//do nothing...
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabApp FromApp(App pDomain) {
			var api = new FabApp();
			FromApp(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromApp(FabApp pApi, App pDomain) {
			FromArtifact(pApi, pDomain);
			//Custom: 
			//pApi.Name <== pDomain.Name  (requires custom)
			pApi.Secret = pDomain.Secret;
			FromAppCustom(pApi, pDomain);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabArtifact FromArtifact(Artifact pDomain) {
			var api = new FabArtifact();
			FromArtifact(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromArtifact(FabArtifact pApi, Artifact pDomain) {
			FromVertex(pApi, pDomain);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabClass FromClass(Class pDomain) {
			var api = new FabClass();
			FromClass(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromClass(FabClass pApi, Class pDomain) {
			FromArtifact(pApi, pDomain);
			pApi.Name = pDomain.Name;
			pApi.Disamb = pDomain.Disamb;
			pApi.Note = pDomain.Note;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabEmail FromEmail(Email pDomain) {
			var api = new FabEmail();
			FromEmail(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromEmail(FabEmail pApi, Email pDomain) {
			FromVertex(pApi, pDomain);
			pApi.Secret = pDomain.Address;
			pApi.Code = pDomain.Code;
			pApi.Verified = pDomain.Verified;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabFactor FromFactor(Factor pDomain) {
			var api = new FabFactor();
			FromFactor(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromFactor(FabFactor pApi, Factor pDomain) {
			FromVertex(pApi, pDomain);
			pApi.Descriptor = new FabDescriptor();
			pApi.Director = new FabDirector();
			pApi.Eventor = new FabEventor();
			pApi.Identor = new FabIdentor();
			pApi.Locator = new FabLocator();
			pApi.Vector = new FabVector();
			pApi.AssertionType = pDomain.AssertionType;
			pApi.IsDefining = pDomain.IsDefining;
			pApi.Note = pDomain.Note;
			pApi.Descriptor.Type = pDomain.DescriptorType.GetValueOrDefault();
			pApi.Director.DirectorType = pDomain.DirectorType.GetValueOrDefault();
			pApi.Director.PrimaryAction = pDomain.DirectorPrimaryAction.GetValueOrDefault();
			pApi.Director.RelatedAction = pDomain.DirectorRelatedAction.GetValueOrDefault();
			pApi.Eventor.Type = pDomain.EventorType.GetValueOrDefault();
			//Custom: Set Api.Year/Momth/etc. using Domain.EventorDateTime.
			//pApi.Eventor.Year <== pDomain.EventorDateTime  (requires custom)
			//Custom: 
			//pApi.Eventor.Month <== pDomain.EventorDateTime  (requires custom)
			//Custom: 
			//pApi.Eventor.Day <== pDomain.EventorDateTime  (requires custom)
			//Custom: 
			//pApi.Eventor.Hour <== pDomain.EventorDateTime  (requires custom)
			//Custom: 
			//pApi.Eventor.Minute <== pDomain.EventorDateTime  (requires custom)
			//Custom: 
			//pApi.Eventor.Second <== pDomain.EventorDateTime  (requires custom)
			pApi.Identor.Type = pDomain.IdentorType.GetValueOrDefault();
			pApi.Identor.Value = pDomain.Note;
			pApi.Locator.Type = pDomain.LocatorType.GetValueOrDefault();
			pApi.Locator.ValueX = pDomain.LocatorValueX.GetValueOrDefault();
			pApi.Locator.ValueY = pDomain.LocatorValueY.GetValueOrDefault();
			pApi.Locator.ValueZ = pDomain.LocatorValueZ.GetValueOrDefault();
			pApi.Vector.Type = pDomain.VectorType.GetValueOrDefault();
			pApi.Vector.Unit = pDomain.VectorUnit.GetValueOrDefault();
			pApi.Vector.UnitPrefix = pDomain.VectorUnitPrefix.GetValueOrDefault();
			pApi.Vector.Value = pDomain.VectorValue.GetValueOrDefault();
			FromFactorCustom(pApi, pDomain);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabInstance FromInstance(Instance pDomain) {
			var api = new FabInstance();
			FromInstance(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromInstance(FabInstance pApi, Instance pDomain) {
			FromArtifact(pApi, pDomain);
			pApi.Name = pDomain.Name;
			pApi.Disamb = pDomain.Disamb;
			pApi.Note = pDomain.Note;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabMember FromMember(Member pDomain) {
			var api = new FabMember();
			FromMember(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromMember(FabMember pApi, Member pDomain) {
			FromVertex(pApi, pDomain);
			pApi.Type = pDomain.MemberType;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabOauthAccess FromOauthAccess(OauthAccess pDomain) {
			var api = new FabOauthAccess();
			FromOauthAccess(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromOauthAccess(FabOauthAccess pApi, OauthAccess pDomain) {
			FromVertex(pApi, pDomain);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabOauthDomain FromOauthDomain(OauthDomain pDomain) {
			var api = new FabOauthDomain();
			FromOauthDomain(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromOauthDomain(FabOauthDomain pApi, OauthDomain pDomain) {
			FromVertex(pApi, pDomain);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabOauthGrant FromOauthGrant(OauthGrant pDomain) {
			var api = new FabOauthGrant();
			FromOauthGrant(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromOauthGrant(FabOauthGrant pApi, OauthGrant pDomain) {
			FromVertex(pApi, pDomain);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabOauthScope FromOauthScope(OauthScope pDomain) {
			var api = new FabOauthScope();
			FromOauthScope(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromOauthScope(FabOauthScope pApi, OauthScope pDomain) {
			FromVertex(pApi, pDomain);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabUrl FromUrl(Url pDomain) {
			var api = new FabUrl();
			FromUrl(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromUrl(FabUrl pApi, Url pDomain) {
			FromArtifact(pApi, pDomain);
			pApi.Name = pDomain.Name;
			pApi.FullPath = pDomain.FullPath;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabUser FromUser(User pDomain) {
			var api = new FabUser();
			FromUser(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromUser(FabUser pApi, User pDomain) {
			FromArtifact(pApi, pDomain);
			//Custom: Leave Domain.Password encrpyted..
			//pApi.Name <== pDomain.Name  (requires custom)
			//Custom: 
			//pApi.Password <== pDomain.Password  (requires custom)
			FromUserCustom(pApi, pDomain);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabVertex FromVertex(Vertex pDomain) {
			var api = new FabVertex();
			FromVertex(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromVertex(FabVertex pApi, Vertex pDomain) {
			FromObject(pApi, pDomain);
			pApi.Id = pDomain.VertexId;
			//Custom: Set Api.IdStr = Domain.Id.ToString().
			//pApi.IdStr <== pDomain.VertexId  (requires custom)
			//Custom: Convert Domain.Timestamp to Unix-based seconds.
			//pApi.Timestamp <== pDomain.Timestamp  (requires custom)
			pApi.VertexType = pDomain.VertexType;
			FromVertexCustom(pApi, pDomain);
		}

	}

}