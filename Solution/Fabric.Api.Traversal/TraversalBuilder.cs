using System;
using System.Collections.Generic;
using System.Net;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Traversal {

	/*================================================================================================*/
	public class TraversalBuilder { //TEST: TraversalBuilder

		private readonly IApiContext vApiCtx;
		private readonly TraversalModel vModel;
		private readonly IFinalStep vLastStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TraversalBuilder(IApiContext pApiCtx, FabResponse pResp, string pApiUri) {
			vApiCtx = pApiCtx;

			if ( pApiUri.Length > 0 ) {
				pApiUri = pApiUri.Substring(1); //remove "/"
			}

			vModel = new TraversalModel();
			vModel.Resp = pResp;
			vModel.HttpStatus = HttpStatusCode.OK;

			RootStep r = PathRouter.NewRootStep(vApiCtx.AppId, vApiCtx.UserId);
			vLastStep = PathRouter.GetPath(r, pApiUri);
			vModel.Resp.SetLinks(vLastStep.AvailableLinks);
			vModel.Resp.Functions = vLastStep.AvailableFuncs.ToArray();
			vModel.Query = vLastStep.Path.Script;
		}

		/*--------------------------------------------------------------------------------------------*/
		public TraversalModel BuildModel() {
			try {
				Execute();
			}
			catch ( Exception e ) {
				HandleException(e);
			}

			return vModel;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void Execute() {
			if ( vLastStep.UseLocalData ) {
				return;
			}

			IApiDataAccess data = vApiCtx.DbData("Traversal", vLastStep.Path);
			vModel.Resp.DbMs = vApiCtx.DbQueryMillis;

			////

			if ( data.ResultDtoList != null ) {
				int max = vLastStep.Count;
				int count = 0;
				vModel.DtoList = new List<IDbDto>();

				foreach ( DbDto dbDto in data.ResultDtoList ) {
					if ( count++ >= max ) { break; }
					vModel.DtoList.Add(dbDto);
					++vModel.Resp.Count;
				}

				vModel.Resp.StartIndex = vLastStep.Index;
				vModel.Resp.HasMore = (data.ResultDtoList.Count > max);
				return;
			}

			vModel.NonDtoText = data.RawResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void HandleException(Exception pEx) {
			vModel.Resp.Links = new FabStepLink[0];
			vModel.Resp.Functions = new string[0];
			vModel.Resp.StartIndex = 0;
			vModel.Resp.Count = 0;

			if ( pEx is FabFault ) {
				vModel.IsErrorHandled = true;
				vModel.Resp.Error = FabError.ForFault(pEx as FabFault);
				vModel.HttpStatus = HttpStatusCode.BadRequest;
			}
			else {
				vModel.Resp.Error = FabError.ForInternalServerError();
				vModel.HttpStatus = HttpStatusCode.InternalServerError;
				Log.Error("Unhandled Traversal Exception:\n"+pEx);
			}

			vModel.Resp.HttpStatus = (int)vModel.HttpStatus;
		}

	}

}