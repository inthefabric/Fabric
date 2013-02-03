using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public class CreateEventor : CreateFactorElement<Eventor> {

		public const string EveTypeParam = "EventorTypeId";
		public const string EvePrecParam = "EventorPrecisionId";
		public const string DateTimeParam = "DateTime";

		private readonly long vEveTypeId;
		private readonly long vEvePrecId;
		private readonly long vDateTime;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateEventor(IModifyTasks pTasks, long pFactorId, long pEveTypeId, 
										long pEvePrecId, long pDateTime) : base(pTasks, pFactorId) {
			vEveTypeId = pEveTypeId; 
			vEvePrecId = pEvePrecId;
			vDateTime = pDateTime;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.EventorTypeId(vEveTypeId, EveTypeParam);
			Tasks.Validator.EventorPrecisionId(vEvePrecId, EvePrecParam);
			//TODO: ensure DateTime is >= 0?
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