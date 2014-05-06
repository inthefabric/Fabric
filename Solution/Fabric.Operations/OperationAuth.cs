using System;
using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Cache;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Operations {

	/*================================================================================================*/
	public class OperationAuth : IOperationAuth {

		public long? CookieUserId { get; private set;  }

		private readonly IMemCache vMemCache;
		private readonly Func<IDataAccess> vGetDataAcc;
		private readonly Func<long> vGetUtcNow;
		private Member vActiveMember;
		private string vOauthToken;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OperationAuth(IMemCache pMemCache, Func<IDataAccess> pGetDataAcc, Func<long> pGetUtcNow){
			vMemCache = pMemCache;
			vGetDataAcc = pGetDataAcc;
			vGetUtcNow = pGetUtcNow;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void SetOauthToken(string pToken) {
			if ( vOauthToken != null ) {
				throw new Exception("OauthToken was already set.");
			}

			vOauthToken = pToken;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetCookieUserId(long? pUserId) {
			CookieUserId = pUserId;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetFabricActiveMember() {
			if ( vActiveMember != null ) {
				throw new Exception("ActiveMember is already set: "+vActiveMember.VertexId);
			}

			vActiveMember = new Member();
			vActiveMember.VertexId = (long)SetupMemberId.FabFabData;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void RemoveFabricActiveMember() {
			if ( vActiveMember == null || vActiveMember.VertexId != (long)SetupMemberId.FabFabData ) {
				throw new Exception("ActiveMember is not set to Fabric.");
			}

			vActiveMember = null;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetNewUserMember(long pVertexId) {
			vActiveMember = new Member();
			vActiveMember.VertexId = pVertexId;
			vActiveMember.MemberType = (byte)MemberType.Id.Member;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public long? ActiveMemberId {
			get {
				return (vActiveMember == null ? (long?)null : vActiveMember.VertexId);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void ExecuteOauth() {
			if ( vOauthToken == null ) {
				vActiveMember = null;
				return;
			}

			vActiveMember = vMemCache.FindOauthMember(vOauthToken);

			if ( vActiveMember != null ) {
				return;
			}

			////

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<OauthAccess>(x => x.Token, vOauthToken)
					.Has(x => x.Expires, WeaverStepHasOp.GreaterThan, vGetUtcNow())
				.AuthenticatesMember.ToMember
				.ToQuery();

			vActiveMember = vGetDataAcc()
				.AddQuery(q)
				.Execute("MemberForOauthToken")
				.ToElement<Member>();

			if ( vActiveMember == null ) {
				throw new FabOauthFault();
			}

			switch ( (MemberType.Id)vActiveMember.MemberType ) {
				case MemberType.Id.None:
				case MemberType.Id.Invite:
				case MemberType.Id.Request:
					vActiveMember = null;
					throw new FabOauthFault();
			}

			////

			long exp = (vActiveMember.OauthGrantExpires ?? 0);
			var expSec = (int)(new TimeSpan(exp-vGetUtcNow()).TotalSeconds);
			vMemCache.AddOauthMember(vOauthToken, vActiveMember, expSec);
		}

	}

}