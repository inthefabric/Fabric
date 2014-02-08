using System;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.New.Operations {

	/*================================================================================================*/
	public class OperationAuth : IOperationAuth {

		public Member ActiveMember { get; private set; }
		public long? CookieUserId { get; private set;  }

		private readonly Func<IDataAccess> vGetDataAcc;
		private readonly Func<long> vGetUtcNow;
		private string vOauthToken;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OperationAuth(Func<IDataAccess> pGetDataAcc, Func<long> pGetUtcNow) {
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
		public void SetCookieUserId(long pUserId) {
			CookieUserId = pUserId;
		}

		/*--------------------------------------------------------------------------------------------*/
		//TEST: fabric active member
		public void SetFabricActiveMember() {
			if ( ActiveMember != null ) {
				throw new Exception("ActiveMember is already set.");
			}

			ActiveMember = new Member();
			ActiveMember.VertexId = (long)SetupMemberId.FabFabData;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void RemoveFabricActiveMember() {
			if ( ActiveMember == null || ActiveMember.VertexId != (long)SetupMemberId.FabFabData ) {
				throw new Exception("ActiveMember is not set to Fabric.");
			}

			ActiveMember = null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public long? ActiveMemberId {
			get {
				return (ActiveMember == null ? (long?)null : ActiveMember.VertexId);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void ExecuteOauth() {
			if ( vOauthToken == null ) {
				ActiveMember = null;
				return;
			}

			////

			//TODO: support caching
			//Tuple<OauthAccess, long, long?> tuple = ApiCtx.Cache.Memory.FindOauthAccess(vToken);

			////

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<OauthAccess>(x => x.Token, vOauthToken)
					.Has(x => x.Expires, WeaverStepHasOp.GreaterThan, vGetUtcNow())
				.AuthenticatesMember.ToMember
				.ToQuery();

			ActiveMember = vGetDataAcc()
				.AddQuery(q)
				.Execute("MemberForOauthToken")
				.ToElement<Member>();

			if ( ActiveMember == null ) {
				throw new FabOauthFault();
			}

			switch ( (MemberType.Id)ActiveMember.MemberType ) {
				case MemberType.Id.None:
				case MemberType.Id.Invite:
				case MemberType.Id.Request:
					throw new FabOauthFault();
			}

			/*tuple = new Tuple<OauthAccess, long, long?>(oa, appId, userId);
			var expireSec = (int)(new TimeSpan(pAcc.Expires-ApiCtx.UtcNow.Ticks).TotalSeconds);
            ApiCtx.Cache.Memory.AddOauthAccess(vToken, tuple, expSec);*/
		}

	}

}