
// GENERATED CODE
// Changes made to this source file will be overwritten

using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal;

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
			FabTravStep[] steps = null;
			
			Func<IList<FabElement>> getResp = (() => {
				string path = pApiReq.Path.Substring(6); //remove "/Trav/"
				var op = new TraversalOperation();
				steps = op.GetResultSteps().ToArray();
				return op.Execute(pApiReq.OpCtx, path);
			});

			var exec = new FabResponseExecutor<FabElement>(pApiReq, getResp);
			exec.NewFabResponse = (() => new FabTravResponse<FabElement> { Steps = steps });
			return exec.Execute();
		}
		
	}

}