using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public static class CreateFactorElement {

		public const string FactorParam = "FactorId";

	}

	/*================================================================================================*/
	public abstract class CreateFactorElement<T> : BaseModifyFunc<T> where T : FactorElementNode {

		[ServiceOpParam(ServiceOpParamType.Form, CreateFactorElement.FactorParam, 0, typeof(Factor))]
		protected readonly long vFactorId; //use 'protected' so SpecDoc can find it


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected CreateFactorElement(IModifyTasks pTasks, long pFactorId) : base(pTasks) {
			vFactorId = pFactorId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.FactorId(vFactorId, CreateFactorElement.FactorParam);
			ValidateElementParams();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override T Execute() {
			Member m = GetContextMember();
			Factor f = Tasks.GetActiveFactorFromMember(ApiCtx, vFactorId, m.MemberId);

			if ( f == null ) {
				throw new FabNotFoundFault(typeof(Factor),
					CreateFactorElement.FactorParam+"="+vFactorId);
			}

			if ( f.Completed != null ) {
				throw new FabPreventedFault(FabFault.Code.FactorAlreadyCompleted,
					"This "+typeof(Factor).Name+" is already completed.");
			}

			if ( FactorHasElement(f) ) {
				throw new FabPreventedFault(FabFault.Code.FactorElementConflict,
					"This "+typeof(Factor).Name+" already has an attached "+typeof(T).Name+".");
			}

			return AddElementToFactor(f, m);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract void ValidateElementParams();
		protected abstract bool FactorHasElement(Factor pFactor);
		protected abstract T AddElementToFactor(Factor pFactor, Member pMember);

	}

}