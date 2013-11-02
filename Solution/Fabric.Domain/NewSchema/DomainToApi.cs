
// GENERATED CODE
// Changes made to this source file will be overwritten

namespace Fabric.Domain.NewSchema {

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
			pApi.Name = pDomain.Name;
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
		public static FabFactor FromFactor(Factor pDomain) {
			var api = new FabFactor();
			FromFactor(api, pDomain);
			return api;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromFactor(FabFactor pApi, Factor pDomain) {
			FromArtifact(pApi, pDomain);
			pApi.Descriptor = new FabDescriptor();
			pApi.Director = new FabDirector();
			pApi.Eventor = new FabEventor();
			pApi.Identor = new FabIdentor();
			pApi.Locator = new FabLocator();
			pApi.Vector = new FabVector();
			pApi.AssertionType = pDomain.AssertionType;
			pApi.IsDefining = pDomain.IsDefining;
			pApi.Note = pDomain.Note;
			pApi.Descriptor.DescriptorType = pDomain.DescriptorType.GetValueOrDefault();
			pApi.Director.DirectorType = pDomain.DirectorType.GetValueOrDefault();
			pApi.Director.PrimaryAction = pDomain.DirectorPrimaryAction.GetValueOrDefault();
			pApi.Director.RelatedAction = pDomain.DirectorRelatedAction.GetValueOrDefault();
			pApi.Eventor.EventorType = pDomain.EventorType.GetValueOrDefault();
			//pApi.Eventor.Year <== pDomain.EventorDateTime  (requires custom)
			//pApi.Eventor.Month <== pDomain.EventorDateTime  (requires custom)
			//pApi.Eventor.Day <== pDomain.EventorDateTime  (requires custom)
			//pApi.Eventor.Hour <== pDomain.EventorDateTime  (requires custom)
			//pApi.Eventor.Minute <== pDomain.EventorDateTime  (requires custom)
			//pApi.Eventor.Second <== pDomain.EventorDateTime  (requires custom)
			pApi.Identor.IdentorType = pDomain.IdentorType.GetValueOrDefault();
			pApi.Identor.Value = pDomain.Note;
			pApi.Locator.LocatorType = pDomain.LocatorType.GetValueOrDefault();
			pApi.Locator.ValueX = pDomain.LocatorValueX.GetValueOrDefault();
			pApi.Locator.ValueY = pDomain.LocatorValueY.GetValueOrDefault();
			pApi.Locator.ValueZ = pDomain.LocatorValueZ.GetValueOrDefault();
			pApi.Vector.VectorType = pDomain.VectorType.GetValueOrDefault();
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
			pApi.AccessType = pDomain.AccessType;
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
			pApi.Name = pDomain.Name;
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
			pApi.Id = pDomain.Id;
			//pApi.IdStr <== pDomain.Id  (requires custom)
			//pApi.Timestamp <== pDomain.Timestamp  (requires custom)
			FromVertexCustom(pApi, pDomain);
		}

	}

}