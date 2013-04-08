using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModDirectorsUri, typeof(FabDirector),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class CreateDirector : CreateFactorElement<Director> {

		public const string DirTypeParam = "DirectorTypeId";
		public const string PrimActionParam = "PrimaryDirectorActionId";
		public const string RelActionParam = "RelatedDirectorActionId";

		[ServiceOpParam(ServiceOpParamType.Form, DirTypeParam, 1, typeof(Director))]
		private readonly byte vDescTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, PrimActionParam, 2, typeof(Director),
			DomainPropertyName="DirectorActionId")]
		private readonly byte vPrimActId;

		[ServiceOpParam(ServiceOpParamType.Form, RelActionParam, 3, typeof(Director),
			DomainPropertyName="DirectorActionId")]
		private readonly byte vRelActId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateDirector(IModifyTasks pTasks, long pFactorId, byte pDescTypeId, 
											byte pPrimActId, byte pRelActId) : base(pTasks, pFactorId) {
			vDescTypeId = pDescTypeId; 
			vPrimActId = pPrimActId;
			vRelActId = pRelActId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.DirectorTypeId(vDescTypeId, DirTypeParam);
			Tasks.Validator.PrimaryDirectorActionId(vPrimActId, PrimActionParam);
			Tasks.Validator.RelatedDirectorActionId(vRelActId, RelActionParam);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool FactorHasElement(Factor pFactor) {
			return Tasks.FactorHasDirector(ApiCtx, pFactor);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Director AddElementToFactor(Factor pFactor, Member pMember) {
			Director dir = Tasks.GetDirectorMatch(ApiCtx, vDescTypeId, vPrimActId, vRelActId);

			if ( dir != null ) {
				Tasks.AttachExistingElement<Director, FactorUsesDirector>(ApiCtx, pFactor, dir);
				return dir;
			}

			////

			IWeaverVarAlias<Director> dirVar;
			var txb = new TxBuilder();

			Tasks.TxAddDirector(ApiCtx, txb, vDescTypeId, vPrimActId, vRelActId, pFactor, out dirVar);

			txb.RegisterVarWithTxBuilder(dirVar);
			return ApiCtx.DbSingle<Director>("CreateDirectorTx", txb.Finish(dirVar));
		}

	}

}