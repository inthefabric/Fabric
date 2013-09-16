﻿using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModEventorsUri, typeof(bool),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class AttachEventor : AttachFactorElement {

		public const string EveTypeParam = "EventorTypeId";
		public const string DateTimeParam = "DateTime";

		[ServiceOpParam(ServiceOpParamType.Form, EveTypeParam, 1, typeof(Factor))]
		private readonly byte vEveTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, DateTimeParam, 2, typeof(Factor))]
		private readonly long vDateTime;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AttachEventor(IModifyTasks pTasks, long pFactorId, byte pEveTypeId, 
															long pDateTime) : base(pTasks, pFactorId) {
			vEveTypeId = pEveTypeId;
			vDateTime = pDateTime;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.FactorEventor_TypeId(vEveTypeId, EveTypeParam);
			Tasks.Validator.FactorEventor_DateTime(vDateTime, DateTimeParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Dictionary<string, long> GetRequiredArtifactIds() { return null; }

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AddElementToFactor(Factor pFactor) {
			Tasks.UpdateFactorEventor(ApiCtx, pFactor, vEveTypeId, vDateTime);
			return true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override string GetElementName() {
			return "Eventor";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool FactorHasElement(Factor pFactor) {
			return (pFactor.Eventor_TypeId != null);
		}

	}

}