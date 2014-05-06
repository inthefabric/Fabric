
// GENERATED CODE
// Changes made to this source file will be overwritten

using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Interfaces;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Traversal;
using Fabric.Operations.Traversal;

namespace Fabric.Api.Executors {

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
			FabTravStep[] steps = null;
			
			Func<IList<FabElement>> getResp = (() => {
				string path = pApiReq.Path;
				path = path.Substring(path.ToLower().IndexOf("trav/")+5); //remove "/Trav/"

				var op = new TraversalOperation();

				IList<FabElement> result = op.Execute(pApiReq.OpCtx, path);
				steps = op.GetResultSteps().ToArray();
				return result;
			});

			var exec = new FabResponseExecutor<FabElement>(pApiReq, getResp);
			exec.NewFabResponse = (() => new FabTravResponse<FabElement> { Steps = steps });
			return exec.Execute();
		}
		
	}

}