using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModIdentorsUri, typeof(FabIdentor),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class CreateIdentor : CreateFactorElement<Identor> {

		public const string IdenTypeParam = "IdentorTypeId";
		public const string ValueParam = "Value";

		[ServiceOpParam(ServiceOpParamType.Form, IdenTypeParam, 1, typeof(Identor))]
		private readonly byte vIdenTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, ValueParam, 2, typeof(Identor))]
		private readonly string vValue;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateIdentor(IModifyTasks pTasks, long pFactorId, byte pEveTypeId, 
															string pValue) : base(pTasks, pFactorId) {
			vIdenTypeId = pEveTypeId; 
			vValue = pValue;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.IdentorTypeId(vIdenTypeId, IdenTypeParam);
			Tasks.Validator.IdentorValue(vValue, ValueParam);
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