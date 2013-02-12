using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetDataProv : ApiFunc<User> {
		
		public enum Query {
			GetUser
		}

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
			/*User dp = QueryOver<User>()
			   .Where(p => p.Id == vDataProvId)
			   .JoinQueryOver<Member>(p => p.Members, JoinType.InnerJoin)
			   .Where(m => m.App.Id == vClientId && m.MemberType.Id == (int)MemberTypeIds.DataProvider)
			   .Take(1).SingleOrDefault();*/

			IWeaverFuncAs<User> userAlias;
			IWeaverFuncAs<Member> memberAlias;

			IWeaverQuery q = 
				NewPathFromIndex(new User { UserId = vDataProvUserId})
					.As(out userAlias)
				.DefinesMemberList.ToMember
					.As(out memberAlias)
				.InAppDefines.FromApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, vAppId)
				.Back(memberAlias)
				.HasMemberTypeAssign.ToMemberTypeAssign
				.UsesMemberType.ToMemberType
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.EqualTo, (long)MemberTypeId.DataProvider)
				.Back(userAlias)
				.End();

			return ApiCtx.DbSingle<User>(Query.GetUser+"", q);
		}

	}
	
}