using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetUserAuth : ApiFunc<User> {
		
		private readonly string vUsername;
		private readonly string vPassword;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetUserAuth(string pUsername, string pPassword) {
			vUsername = pUsername;
			vPassword = pPassword;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			if ( vUsername == null ) {
				throw new FabArgumentNullFault("Username");
			}

			if ( vPassword == null ) {
				throw new FabArgumentNullFault("Password");
			}
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override User Execute() {
			if ( string.IsNullOrWhiteSpace(vUsername) || string.IsNullOrWhiteSpace(vPassword) ) {
				return null; //avoid a database call (and corresponding database error)
			}

			IWeaverQuery q = 
				Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.NameKey, vUsername.ToLower())
				.Has(x => x.Password, WeaverStepHasOp.EqualTo, FabricUtil.HashPassword(vPassword))
				.ToQuery();

			return ApiCtx.Get<User>(q, "Oauth-GetUserAuth-Get");
		}
		
	}

}