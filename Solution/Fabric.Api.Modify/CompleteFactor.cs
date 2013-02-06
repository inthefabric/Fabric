using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Modify {

	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Put, FabHome.ModFactorsUri, typeof(FabFactor),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(Factor))]
	public class CompleteFactor : UpdateFactor { //TEST: CompleteFactor
		
		[ServiceOpParam(ServiceOpParamType.Form, FactorParam, typeof(FactorAssertion))]
		private readonly long vFactorId;

		[ServiceOpParam(ServiceOpParamType.Form, CompletedParam, typeof(Factor))]
		private readonly bool vCompleted;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CompleteFactor(IModifyTasks pTasks, long pFactorId, bool pCompleted) :
															base(pTasks, pFactorId, pCompleted, false) {
			vFactorId = pFactorId;
			vCompleted = pCompleted;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( !vCompleted ) {
				throw new FabArgumentFault(CompletedParam+" must be true.");
			}

			base.ValidateParams();
		}

	}

}