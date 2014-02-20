
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
			ApiEntry.Get("/Trav/Apps", AppsResp, typeof(FabResponse<FabTravAppRoot>)),
			ApiEntry.Get("/Trav/Artifacts", ArtifactsResp, typeof(FabResponse<FabTravArtifactRoot>)),
			ApiEntry.Get("/Trav/Classes", ClassesResp, typeof(FabResponse<FabTravClassRoot>)),
			ApiEntry.Get("/Trav/Factors", FactorsResp, typeof(FabResponse<FabTravFactorRoot>)),
			ApiEntry.Get("/Trav/Instances", InstancesResp, typeof(FabResponse<FabTravInstanceRoot>)),
			ApiEntry.Get("/Trav/Members", MembersResp, typeof(FabResponse<FabTravMemberRoot>)),
			ApiEntry.Get("/Trav/Urls", UrlsResp, typeof(FabResponse<FabTravUrlRoot>)),
			ApiEntry.Get("/Trav/Users", UsersResp, typeof(FabResponse<FabTravUserRoot>)),
			ApiEntry.Get("/Trav/Vertices", VerticesResp, typeof(FabResponse<FabTravVertexRoot>)),
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse ExecuteRoot<T>(IApiRequest pApiReq) where T : FabObject, new() {
			var exec = new FabResponseExecutor<T>(pApiReq, () => new List<T>(new[] { new T() }));
			return exec.Execute();
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse AppsResp(IApiRequest pApiReq) {
			return ExecuteRoot<FabTravAppRoot>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse ArtifactsResp(IApiRequest pApiReq) {
			return ExecuteRoot<FabTravArtifactRoot>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse ClassesResp(IApiRequest pApiReq) {
			return ExecuteRoot<FabTravClassRoot>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse FactorsResp(IApiRequest pApiReq) {
			return ExecuteRoot<FabTravFactorRoot>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse InstancesResp(IApiRequest pApiReq) {
			return ExecuteRoot<FabTravInstanceRoot>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse MembersResp(IApiRequest pApiReq) {
			return ExecuteRoot<FabTravMemberRoot>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse UrlsResp(IApiRequest pApiReq) {
			return ExecuteRoot<FabTravUrlRoot>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse UsersResp(IApiRequest pApiReq) {
			return ExecuteRoot<FabTravUserRoot>(pApiReq);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IApiResponse VerticesResp(IApiRequest pApiReq) {
			return ExecuteRoot<FabTravVertexRoot>(pApiReq);
		}
		
	}

}