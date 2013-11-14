﻿using System;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.New.Operations {

	/*================================================================================================*/
	public class OperationAccess : IOperationAccess {

		//private static readonly Logger Log = Logger.Build<OperationAccess>();

		public Member ActiveMember { get; private set; }

		private readonly Func<IDataAccess> vGetDataAcc;
		private readonly Func<long> vGetUtcNow;
		private string vOauthToken;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OperationAccess(Func<IDataAccess> pGetDataAcc, Func<long> pGetUtcNow) {
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
					.Has(x => x.Expires, WeaverStepHasOp.GreaterThan, vGetUtcNow)
				.AuthenticatesMember.ToMember
				.ToQuery();

			ActiveMember = vGetDataAcc()
				.AddQuery(q)
				.Execute("MemberForOauthToken")
				.ToElementAt<Member>(0, 0);

			if ( ActiveMember == null ) {
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