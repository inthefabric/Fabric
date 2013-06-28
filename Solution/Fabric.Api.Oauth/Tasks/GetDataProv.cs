using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;
using Fabric.Infrastructure.Data;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetDataProv : ApiFunc<User> {
		
		private readonly long vAppId;
		private readonly long vDataProvUserId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetDataProv(long pAppId, long pDataProvUserId) {
			vAppId = pAppId;
			vDataProvUserId = pDataProvUserId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vAppId == 0 ) {
				throw new FabArgumentValueFault("AppId", 0);
			}

			if ( vDataProvUserId == 0 ) {
				throw new FabArgumentValueFault("DataProvUserId", 0);
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override User Execute() {
			IWeaverStepAs<User> userAlias;
			IWeaverStepAs<Member> memberAlias;

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.ArtifactId, vDataProvUserId)
					.As(out userAlias)
				.DefinesMemberList.ToMember
					.As(out memberAlias)
				.InAppDefines.FromApp
					.Has(x => x.ArtifactId, WeaverStepHasOp.EqualTo, vAppId)
				.Back(memberAlias)
				.HasMemberTypeAssign.ToMemberTypeAssign
					.Has(x => x.MemberTypeId, WeaverStepHasOp.EqualTo, (byte)MemberTypeId.DataProvider)
				.Back(userAlias)
				.ToQuery();

			return ApiCtx.Get<User>(q);
		}

	}
	
}