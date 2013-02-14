using System;
using System.Collections.Generic;
using System.Net;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Weaver;

namespace Fabric.Api.Traversal {

	/*================================================================================================*/
	public class TraversalBuilder { //TEST: TraversalBuilder

		private readonly IApiContext vApiCtx;
		private readonly TraversalModel vModel;
		private readonly IFinalStep vLastStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TraversalBuilder(IApiContext pApiCtx, FabResponse pResp, string pApiUri,
																					bool pStartAtRoot) {
			vApiCtx = pApiCtx;

			if ( pApiUri.Length > 0 ) {
				pApiUri = pApiUri.Substring(1); //remove "/"
			}

			vModel = new TraversalModel();
			vModel.Resp = pResp;
			vModel.HttpStatus = HttpStatusCode.OK;

			RootStep r = PathRouter.NewRootStep(pStartAtRoot, vApiCtx.AppId, vApiCtx.UserId);
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

			vModel.Resp.DbStartEvent();

			var wq = new WeaverQuery();
			wq.FinalizeQuery(vModel.Query);
			IApiDataAccess data = vApiCtx.DbData("Traversal", wq);

			vModel.Resp.DbEndEvent();

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

			vModel.NonDtoText = data.ResultString;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void HandleException(Exception pEx) {
			vModel.Resp.IsError = true;
			vModel.Resp.Links = new FabStepLink[0];
			vModel.Resp.Functions = new string[0];
			vModel.Resp.StartIndex = 0;
			vModel.Resp.Count = 0;

			if ( pEx is FabFault ) {
				vModel.IsErrorHandled = true;
				vModel.Error = FabError.ForFault(pEx as FabFault);
				vModel.HttpStatus = HttpStatusCode.BadRequest;
			}
			else {
				vModel.Error = FabError.ForInternalServerError();
				vModel.HttpStatus = HttpStatusCode.InternalServerError;
			}

			vModel.Resp.HttpStatus = (int)vModel.HttpStatus;
		}

	}

}