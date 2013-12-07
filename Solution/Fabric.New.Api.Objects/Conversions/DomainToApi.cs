
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Domain;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class DomainToApi {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromElement(FabElement pApi, Vertex pDomain) {
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
			//Custom: 
			//pApi.Name <== pDomain.Name  (requires custom)
			pApi.Disamb = pDomain.Disamb;
			pApi.Note = pDomain.Note;
			FromClassCustom(pApi, pDomain);
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
			pApi.Descriptor.Type = pDomain.DescriptorType;
			pApi.Director.Type = pDomain.DirectorType.GetValueOrDefault();
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
			pApi.Identor.Value = pDomain.IdentorValue;
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
			//Custom: Direct mapping.
			//pApi.Name <== pDomain.Name  (requires custom)
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
			FromElement(pApi, pDomain);
			pApi.Id = pDomain.VertexId;
			//Custom: Convert Domain.Timestamp to Unix-based seconds.
			//pApi.Timestamp <== pDomain.Timestamp  (requires custom)
			pApi.VertexType = pDomain.VertexType;
			FromVertexCustom(pApi, pDomain);
		}

	}

}