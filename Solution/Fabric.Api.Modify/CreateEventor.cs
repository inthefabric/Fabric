﻿using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModEventorsUri, typeof(FabEventor),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class CreateEventor : CreateFactorElement<Eventor> {

		public const string EveTypeParam = "EventorTypeId";
		public const string EvePrecParam = "EventorPrecisionId";
		public const string DateTimeParam = "DateTime";

		[ServiceOpParam(ServiceOpParamType.Form, EveTypeParam, 1, typeof(Eventor))]
		private readonly byte vEveTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, EvePrecParam, 2, typeof(Eventor))]
		private readonly byte vEvePrecId;

		[ServiceOpParam(ServiceOpParamType.Form, DateTimeParam, 3, typeof(Eventor))]
		private readonly long vDateTime;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateEventor(IModifyTasks pTasks, long pFactorId, byte pEveTypeId, 
										byte pEvePrecId, long pDateTime) : base(pTasks, pFactorId) {
			vEveTypeId = pEveTypeId; 
			vEvePrecId = pEvePrecId;
			vDateTime = pDateTime;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.EventorTypeId(vEveTypeId, EveTypeParam);
			Tasks.Validator.EventorPrecisionId(vEvePrecId, EvePrecParam);
			Tasks.Validator.EventorDateTime(vDateTime, DateTimeParam);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool FactorHasElement(Factor pFactor) {
			return Tasks.FactorHasEventor(ApiCtx, pFactor);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Eventor AddElementToFactor(Factor pFactor, Member pMember) {
			Eventor eve = Tasks.GetEventorMatch(ApiCtx, vEveTypeId, vEvePrecId, vDateTime);

			if ( eve != null ) {
				Tasks.AttachExistingElement<Eventor, FactorUsesEventor>(ApiCtx, pFactor, eve);
				return eve;
			}

			////

			IWeaverVarAlias<Eventor> eveVar;
			var txb = new TxBuilder();

			Tasks.TxAddEventor(ApiCtx, txb, vEveTypeId, vEvePrecId, vDateTime, pFactor, out eveVar);

			txb.RegisterVarWithTxBuilder(eveVar);
			return ApiCtx.DbSingle<Eventor>("CreateEventorTx", txb.Finish(eveVar));
		}

	}

}