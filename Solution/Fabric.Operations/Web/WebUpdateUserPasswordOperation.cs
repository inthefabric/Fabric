using Fabric.Api.Objects.Conversions;
using Fabric.Domain;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Query;
using Fabric.Infrastructure.Util;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;

namespace Fabric.Operations.Web {

	/*================================================================================================*/
	public class WebUpdateUserPasswordOperation { //TEST: all Web Operations (integration tests)


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SuccessResult Execute(IOperationContext pOpCtx, long pUserId,
																	string pOldPass, string pNewPass) {
			CreateFabUserValidator.Password(pNewPass);

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