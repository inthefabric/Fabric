﻿using Fabric.New.Domain;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Infrastructure.Util;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;

namespace Fabric.New.Operations.Web {

	/*================================================================================================*/
	public class WebUpdateUserPasswordOperation { //TEST: all Web Operations


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SuccessResult Execute(IOperationContext pOpCtx, long pUserId,
																	string pOldPass, string pNewPass) {
			User user = pOpCtx.Data.GetVertexById<User>(pUserId);

			if ( user.Password != DataUtil.HashPassword(pOldPass) ) {
				throw new FabPreventedFault(FabFault.Code.ActionNotPermitted, "Incorrect Password.");
			}

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.VertexId, pUserId)
					.SideEffect(new WeaverStatementSetProperty<User>(x => x.Password,
						DataUtil.HashPassword(pNewPass)))
				.ToQuery();

			user = pOpCtx.Data.Get<User>(q, "Web-UpdateUserPassword");
			return new SuccessResult(user != null);
		}

	}

}