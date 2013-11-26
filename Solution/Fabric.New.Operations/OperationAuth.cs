using System;
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

			if ( vOauthToken == null ) {
				ActiveMember = null;
				return;
			}

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
		}

		/*--------------------------------------------------------------------------------------------*/
		public long? ActiveMemberId {
			get {
				return (ActiveMember == null ? (long?)null : ActiveMember.VertexId);
			}
		}

	}

}