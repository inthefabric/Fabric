
// GENERATED CODE
// Changes made to this source file will be overwritten

namespace Fabric.Domain.NewSchema {

	/*================================================================================================*/
	public static partial class DomainToApi {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FromObject(FabObject pObject, Vertex pDomain) {
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
			//pApi.Name = pDomain.???;
			FromAppCustom(pApi, pDomain);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		static partial void FromAppCustom(FabApp pApi, App pDomain);


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
			FromArtifactCustom(pApi, pDomain);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		static partial void FromArtifactCustom(FabArtifact pApi, Artifact pDomain);


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
			//pApi.Name = pDomain.???;
			//pApi.Disamb = pDomain.???;
			//pApi.Note = pDomain.???;
			FromClassCustom(pApi, pDomain);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		static partial void FromClassCustom(FabClass pApi, Class pDomain);


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
			//pApi.AssertionType = pDomain.???;
			//pApi.IsDefining = pDomain.???;
			//pApi.Note = pDomain.???;
			FromFactorCustom(pApi, pDomain);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		static partial void FromFactorCustom(FabFactor pApi, Factor pDomain);


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
			//pApi.Name = pDomain.???;
			//pApi.Disamb = pDomain.???;
			//pApi.Note = pDomain.???;
			FromInstanceCustom(pApi, pDomain);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		static partial void FromInstanceCustom(FabInstance pApi, Instance pDomain);


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
			//pApi.AccessType = pDomain.???;
			FromMemberCustom(pApi, pDomain);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		static partial void FromMemberCustom(FabMember pApi, Member pDomain);


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
			//pApi.Name = pDomain.???;
			//pApi.FullPath = pDomain.???;
			FromUrlCustom(pApi, pDomain);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		static partial void FromUrlCustom(FabUrl pApi, Url pDomain);


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
			//pApi.Name = pDomain.???;
			FromUserCustom(pApi, pDomain);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		static partial void FromUserCustom(FabUser pApi, User pDomain);


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
			//pApi.Id = pDomain.???;
			//pApi.IdStr = pDomain.???;
			//pApi.Timestamp = pDomain.???;
			FromVertexCustom(pApi, pDomain);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		static partial void FromVertexCustom(FabVertex pApi, Vertex pDomain);

	}

}