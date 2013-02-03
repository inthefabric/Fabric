using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public class CreateIdentor : CreateFactorElement<Identor> {

		public const string IdenTypeParam = "IdentorTypeId";
		public const string ValueParam = "Value";

		private readonly long vIdenTypeId;
		private readonly string vValue;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateIdentor(IModifyTasks pTasks, long pFactorId, long pEveTypeId, 
															string pValue) : base(pTasks, pFactorId) {
			vIdenTypeId = pEveTypeId; 
			vValue = pValue;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.IdentorTypeId(vIdenTypeId, IdenTypeParam);
			Tasks.Validator.IdentorValue(vValue, ValueParam); //TODO: update to 1 <= value <= 256
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool FactorHasElement(Factor pFactor) {
			return Tasks.FactorHasIdentor(ApiCtx, pFactor);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Identor AddElementToFactor(Factor pFactor, Member pMember) {
			Identor iden = Tasks.GetIdentorMatch(ApiCtx, vIdenTypeId, vValue);

			if ( iden != null ) {
				Tasks.AttachExistingElement<Identor, FactorUsesIdentor>(ApiCtx, pFactor, iden);
				return iden;
			}

			////

			IWeaverVarAlias<Identor> idenVar;
			var txb = new TxBuilder();

			Tasks.TxAddIdentor(ApiCtx, txb, vIdenTypeId, vValue, pFactor, out idenVar);

			txb.RegisterVarWithTxBuilder(idenVar);
			return ApiCtx.DbSingle<Identor>("CreateIdentorTx", txb.Finish(idenVar));
		}

	}

}