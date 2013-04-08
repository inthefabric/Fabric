using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Modify {

	/*================================================================================================*/
	public abstract class UpdateFactor : BaseModifyFunc<Factor> {
		
		public const string FactorParam = "FactorId";
		public const string CompletedParam = "IsCompleted";
		public const string DeletedParam = "IsDeleted";

		private readonly long vFactorId;
		private readonly bool vCompleted;
		private readonly bool vDeleted;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UpdateFactor(IModifyTasks pTasks, long pFactorId, bool pCompleted, bool pDeleted) :
																						base(pTasks) {
			vFactorId = pFactorId;
			vCompleted = pCompleted;
			vDeleted = pDeleted;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.FactorId(vFactorId, FactorParam);

			if ( vCompleted == vDeleted ) {
				throw new FabArgumentValueFault(CompletedParam+" cannot equal "+DeletedParam);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Factor Execute() {
			//GetActiveFactorFromMember filters out deleted Factors
			Member m = GetContextMember();
			Factor f = Tasks.GetActiveFactorFromMember(ApiCtx, vFactorId, m.MemberId);

			if ( f == null ) {
				throw new FabNotFoundFault(typeof(Factor),
					AttachFactorElement.FactorParam+"="+vFactorId);
			}

			if ( vCompleted ) {
				DoCompletedChecks(f);
			}
			
			return Tasks.UpdateFactor(ApiCtx, f, vCompleted, vDeleted);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void DoCompletedChecks(Factor pFactor) {
			if ( pFactor.Completed != null ) {
				throw new FabPreventedFault(FabFault.Code.FactorAlreadyCompleted,
					"This "+typeof(Factor).Name+" is already completed.");
			}

			if ( pFactor.Descriptor_TypeId == null ) {
				throw new FabPreventedFault(FabFault.Code.FactorElementConflict,
					"This "+typeof(Factor).Name+" cannot be completed because it does not have a "+
					"Descriptor attached to it.");
			}
		}

	}

}