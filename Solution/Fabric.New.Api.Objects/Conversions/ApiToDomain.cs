
// GENERATED CODE
// Changes made to this source file will be overwritten

using System;
using System.Collections.Generic;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class ApiToDomain {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromCreateFabElement(Vertex pDomain, CreateFabElement pApi) {
			//do nothing...
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string ToLowerCase(string pValue) {
			return (pValue == null ? null : pValue.ToLower());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static VertexType.Id GetVertexTypeId(Type pFabType) {
			return VertexTypeIdMap[pFabType];
		}

		/*--------------------------------------------------------------------------------------------*/
		private static readonly IDictionary<Type, VertexType.Id> VertexTypeIdMap = 
			new Dictionary<Type, VertexType.Id> {
				{ typeof(FabApp), VertexType.Id.App },
				{ typeof(FabArtifact), VertexType.Id.Artifact },
				{ typeof(FabClass), VertexType.Id.Class },
				{ typeof(FabFactor), VertexType.Id.Factor },
				{ typeof(FabInstance), VertexType.Id.Instance },
				{ typeof(FabMember), VertexType.Id.Member },
				{ typeof(FabUrl), VertexType.Id.Url },
				{ typeof(FabUser), VertexType.Id.User },
				{ typeof(FabVertex), VertexType.Id.Vertex },
			};


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
			//Custom: Set Domain.NameKey = Api.Name.ToLower()
			//pDomain.Name <== pApi.Name  (requires custom)
			pDomain.Disamb = pApi.Disamb;
			pDomain.Note = pApi.Note;
			FromCreateFabClassCustom(pDomain, pApi);
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
			pDomain.Address = ToLowerCase(pApi.Address);
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
			if ( pApi.Identor != null ) { pDomain.IdentorValue = pApi.Identor.Value; }
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
			pDomain.OauthGrantRedirectUri = ToLowerCase(pApi.OauthGrantRedirectUri);
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
			pDomain.FullPath = ToLowerCase(pApi.FullPath);
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
			//Custom: Set Domain.NameKey = Api.Name.ToLower()
			//pDomain.Name <== pApi.Name  (requires custom)
			//Custom: Encrypt Api.Password.
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
			FromCreateFabElement(pDomain, pApi);
		}

	}

}