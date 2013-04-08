using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public abstract class AttachFactorElement : BaseModifyFunc<bool> {

		public const string FactorParam = "FactorId";

		[ServiceOpParam(ServiceOpParamType.Form, FactorParam, 0, typeof(Factor))]
		protected readonly long vFactorId; //use 'protected' so SpecDoc can find it


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected AttachFactorElement(IModifyTasks pTasks, long pFactorId) : base(pTasks) {
			vFactorId = pFactorId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.FactorId(vFactorId, FactorParam);
			ValidateElementParams();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool Execute() {
			Member m = GetContextMember();
			Factor f = Tasks.GetActiveFactorFromMember(ApiCtx, vFactorId, m.MemberId);

			if ( f == null ) {
				throw new FabNotFoundFault(typeof(Factor), FactorParam+"="+vFactorId);
			}

			if ( f.Completed != null ) {
				throw new FabPreventedFault(FabFault.Code.FactorAlreadyCompleted,
					"This "+typeof(Factor).Name+" is already completed.");
			}

			return AddElementToFactor(f, m);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract void ValidateElementParams();
		protected abstract bool AddElementToFactor(Factor pFactor, Member pMember);

	}

}