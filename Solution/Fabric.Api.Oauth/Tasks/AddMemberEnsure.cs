using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class AddMemberEnsure : ActiveFunc<bool> {
		
		private readonly FabAppKey vAppKey;
		private readonly FabUserKey vUserKey;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AddMemberEnsure(FabAppKey pAppKey, FabUserKey pUserKey) : base(AuthType.None) {
			vAppKey = pAppKey;
			vUserKey = pUserKey;
			AddTransactionFunc(DoMemberAdd);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vAppKey == null ) { throw new FabArgumentNullFault("AppKey"); }
			if ( vUserKey == null ) { throw new FabArgumentNullFault("UserKey"); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoMemberAdd(ISession pSession) {
			Member mem = pSession.QueryOver<Member>()
				.Where(g => g.App.Id == vAppKey.Id && g.Usr.Id == vUserKey.Id)
				.Take(1)
				.SingleOrDefault();

			//only SaveOrUpdate if no membership, or if it's none/invite/request

			if ( mem == null ) {
				mem = new Member();
				mem.App = pSession.Load<App>(vAppKey.Id);
				mem.Usr = pSession.Load<Usr>(vUserKey.Id);
			}
			else {
				switch ( mem.MemberType.Id ) {
					case (int)MemberTypeIds.None:
					case (int)MemberTypeIds.Invite:
					case (int)MemberTypeIds.Request:
						break;

					default:
						SetResult(false);
						return;
				}
			}
			
			mem.MemberType = pSession.Load<MemberType>((byte)MemberTypeIds.Member);
			mem.Updated = GetDbNow(pSession);
			pSession.SaveOrUpdate(mem);

			SetResult(true);
		}

	}
}
