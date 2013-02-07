using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Modify {

	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Delete, FabHome.ModFactorsUri, typeof(FabFactor),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class DeleteFactor : UpdateFactor { //TEST: DeleteFactor
		
		[ServiceOpParam(ServiceOpParamType.Form, FactorParam, typeof(FactorAssertion))]
		private readonly long vFactorId;

		[ServiceOpParam(ServiceOpParamType.Form, DeletedParam, typeof(Factor))]
		private readonly bool vDeleted;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DeleteFactor(IModifyTasks pTasks, long pFactorId, bool pDeleted) :
															base(pTasks, pFactorId, false, pDeleted) {
			vFactorId = pFactorId;
			vDeleted = pDeleted;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( !vDeleted ) {
				throw new FabArgumentValueFault(DeletedParam+" must be true.");
			}

			base.ValidateParams();
		}

	}

}