using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetUserAuth : ApiFunc<User> {
		
		public enum Query {
			GetUser
		}

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
			string nameProp = WeaverUtil.GetPropertyName<User>(Weave.Inst.Config, x => x.Name);
			string filterStep = "filter{it.getProperty('"+nameProp+"').toLowerCase()==_P2}";

			IWeaverQuery q = 
				NewPathFromType<User>()
					.Has(x => x.Password, WeaverStepHasOp.EqualTo, FabricUtil.HashPassword(vPassword))
					.CustomStep(filterStep)
				.ToQuery();

			q.AddStringParam(vUsername.ToLower());
			return ApiCtx.DbSingle<User>(Query.GetUser+"", q);
		}
		
	}

}