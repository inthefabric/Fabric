
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;

namespace Fabric.New.Api.Executors {

	/*================================================================================================*/
	public static class TraversalExecutors {

		public static readonly ApiEntry[] ApiEntries = new [] {
			ApiEntry.Get("/Trav/{*}", TravResp, typeof(FabResponse<FabObject>)),
			ApiEntry.Get("/Trav/Apps", TravResp, typeof(FabResponse<FabTravAppRoot>)),
			ApiEntry.Get("/Trav/Artifacts", TravResp, typeof(FabResponse<FabTravArtifactRoot>)),
			ApiEntry.Get("/Trav/Classes", TravResp, typeof(FabResponse<FabTravClassRoot>)),
			ApiEntry.Get("/Trav/Factors", TravResp, typeof(FabResponse<FabTravFactorRoot>)),
			ApiEntry.Get("/Trav/Instances", TravResp, typeof(FabResponse<FabTravInstanceRoot>)),
			ApiEntry.Get("/Trav/Members", TravResp, typeof(FabResponse<FabTravMemberRoot>)),
			ApiEntry.Get("/Trav/Urls", TravResp, typeof(FabResponse<FabTravUrlRoot>)),
			ApiEntry.Get("/Trav/Users", TravResp, typeof(FabResponse<FabTravUserRoot>)),
			ApiEntry.Get("/Trav/Vertices", TravResp, typeof(FabResponse<FabTravVertexRoot>)),
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse TravResp(IApiRequest pApiReq) {
			return new TraversalExecutor(pApiReq).Execute();
		}
		
	}

}