using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public class UpdateFactor : BaseModifyFunc<Factor> { //TEST: UpdateFactor
		
		public const string FactorParam = "FactorId";
		public const string CompletedParam = "Completed";
		public const string DeletedParam = "Deleted";

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
				throw new FabArgumentFault(CompletedParam+" cannot equal "+DeletedParam);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Factor Execute() {
			//Note: GetActiveFactorFromMember filters out deleted Factors
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
				throw new FabPreventedFault("This "+typeof(Factor).Name+" is already completed.");
			}

			if ( !Tasks.FactorHasDescriptor(ApiCtx, pFactor) ) {
				throw new FabPreventedFault("This "+typeof(Factor).Name+" does not have a "+
					typeof(Descriptor).Name+" attached to it, so it cannot be completed.");
			}
		}

	}

}