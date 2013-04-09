using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModIdentorsUri, typeof(bool),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class AttachIdentor : AttachFactorElement {

		public const string IdenTypeParam = "IdentorTypeId";
		public const string ValueParam = "Value";

		[ServiceOpParam(ServiceOpParamType.Form, IdenTypeParam, 1, typeof(Factor))]
		private readonly byte vIdenTypeId;

		[ServiceOpParam(ServiceOpParamType.Form, ValueParam, 2, typeof(Factor))]
		private readonly string vValue;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AttachIdentor(IModifyTasks pTasks, long pFactorId, byte pEveTypeId, 
															string pValue) : base(pTasks, pFactorId) {
			vIdenTypeId = pEveTypeId; 
			vValue = pValue;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateElementParams() {
			Tasks.Validator.FactorIdentor_TypeId(vIdenTypeId, IdenTypeParam);
			Tasks.Validator.FactorIdentor_Value(vValue, ValueParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AddElementToFactor(Factor pFactor, Member pMember) {
			Tasks.UpdateFactorIdentor(ApiCtx, pFactor, vIdenTypeId, vValue);
			return true;
		}

	}

}