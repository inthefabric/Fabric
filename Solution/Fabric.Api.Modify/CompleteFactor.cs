using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Modify {

	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Put, FabHome.ModFactorsUri, typeof(FabFactor),
		Auth=ServiceAuthType.Member, AuthMemberOwns=typeof(FabFactor))]
	public class CompleteFactor : UpdateFactor {
		
		[ServiceOpParam(ServiceOpParamType.Form, FactorParam, typeof(Factor))]
		private readonly long vFactorId;

		[ServiceOpParam(ServiceOpParamType.Form, CompletedParam, null)]
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
				throw new FabArgumentValueFault(CompletedParam+" must be true.");
			}

			base.ValidateParams();
		}

	}

}