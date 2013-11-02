
// GENERATED CODE
// Changes made to this source file will be overwritten

namespace Fabric.Domain.NewSchema {

	/*================================================================================================*/
	public static partial class ApiToDomain {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromFabObject(Vertex pDomain, FabObject pApi) {
			//do nothing...
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static App FromFabApp(FabApp pApi) {
			var dom = new App();
			FromFabApp(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromFabApp(App pDomain, FabApp pApi) {
			FromFabArtifact(pDomain, pApi);
			pDomain.Name = pApi.Name;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Artifact FromFabArtifact(FabArtifact pApi) {
			var dom = new Artifact();
			FromFabArtifact(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromFabArtifact(Artifact pDomain, FabArtifact pApi) {
			FromFabVertex(pDomain, pApi);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Class FromFabClass(FabClass pApi) {
			var dom = new Class();
			FromFabClass(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromFabClass(Class pDomain, FabClass pApi) {
			FromFabArtifact(pDomain, pApi);
			pDomain.Name = pApi.Name;
			pDomain.Disamb = pApi.Disamb;
			pDomain.Note = pApi.Note;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Factor FromFabFactor(FabFactor pApi) {
			var dom = new Factor();
			FromFabFactor(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromFabFactor(Factor pDomain, FabFactor pApi) {
			FromFabArtifact(pDomain, pApi);
			pDomain.AssertionType = pApi.AssertionType;
			pDomain.IsDefining = pApi.IsDefining;
			pDomain.Note = pApi.Note;
			if ( pApi.Identor != null ) { pDomain.Note = pApi.Identor.Value; }
			if ( pApi.Descriptor != null ) { pDomain.DescriptorType = pApi.Descriptor.DescriptorType; }
			if ( pApi.Director != null ) { pDomain.DirectorType = pApi.Director.DirectorType; }
			if ( pApi.Director != null ) { pDomain.DirectorPrimaryAction = pApi.Director.PrimaryAction; }
			if ( pApi.Director != null ) { pDomain.DirectorRelatedAction = pApi.Director.RelatedAction; }
			if ( pApi.Eventor != null ) { pDomain.EventorType = pApi.Eventor.EventorType; }
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			//pDomain.EventorDateTime <== pApi.Eventor.EventorDateTime  (requires custom)
			if ( pApi.Identor != null ) { pDomain.IdentorType = pApi.Identor.IdentorType; }
			if ( pApi.Locator != null ) { pDomain.LocatorType = pApi.Locator.LocatorType; }
			if ( pApi.Locator != null ) { pDomain.LocatorValueX = pApi.Locator.ValueX; }
			if ( pApi.Locator != null ) { pDomain.LocatorValueY = pApi.Locator.ValueY; }
			if ( pApi.Locator != null ) { pDomain.LocatorValueZ = pApi.Locator.ValueZ; }
			if ( pApi.Vector != null ) { pDomain.VectorType = pApi.Vector.VectorType; }
			if ( pApi.Vector != null ) { pDomain.VectorUnit = pApi.Vector.Unit; }
			if ( pApi.Vector != null ) { pDomain.VectorUnitPrefix = pApi.Vector.UnitPrefix; }
			if ( pApi.Vector != null ) { pDomain.VectorValue = pApi.Vector.Value; }
			FromFabFactorCustom(pDomain, pApi);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Instance FromFabInstance(FabInstance pApi) {
			var dom = new Instance();
			FromFabInstance(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromFabInstance(Instance pDomain, FabInstance pApi) {
			FromFabArtifact(pDomain, pApi);
			pDomain.Name = pApi.Name;
			pDomain.Disamb = pApi.Disamb;
			pDomain.Note = pApi.Note;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Member FromFabMember(FabMember pApi) {
			var dom = new Member();
			FromFabMember(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromFabMember(Member pDomain, FabMember pApi) {
			FromFabVertex(pDomain, pApi);
			pDomain.AccessType = pApi.AccessType;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Url FromFabUrl(FabUrl pApi) {
			var dom = new Url();
			FromFabUrl(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromFabUrl(Url pDomain, FabUrl pApi) {
			FromFabArtifact(pDomain, pApi);
			pDomain.Name = pApi.Name;
			pDomain.FullPath = pApi.FullPath;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static User FromFabUser(FabUser pApi) {
			var dom = new User();
			FromFabUser(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromFabUser(User pDomain, FabUser pApi) {
			FromFabArtifact(pDomain, pApi);
			pDomain.Name = pApi.Name;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Vertex FromFabVertex(FabVertex pApi) {
			var dom = new Vertex();
			FromFabVertex(dom, pApi);
			return dom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FromFabVertex(Vertex pDomain, FabVertex pApi) {
			FromFabObject(pDomain, pApi);
			pDomain.Id = pApi.Id;
			//pDomain.Id <== pApi.Id  (requires custom)
			//pDomain.Timestamp <== pApi.Timestamp  (requires custom)
			FromFabVertexCustom(pDomain, pApi);
		}

	}

}