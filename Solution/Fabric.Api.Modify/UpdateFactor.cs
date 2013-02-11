using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Modify {

	/*================================================================================================*/
	public class UpdateFactor : BaseModifyFunc<Factor> {
		
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
					CreateFactorElement.FactorParam+"="+vFactorId);
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

			if ( !Tasks.FactorHasDescriptor(ApiCtx, pFactor) ) {
				throw new FabPreventedFault(FabFault.Code.FactorElementConflict,
					"This "+typeof(Factor).Name+" does not have a "+
					typeof(Descriptor).Name+" attached to it, so it cannot be completed.");
			}
		}

	}

}