using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;
using Weaver.Titan;
using Weaver.Titan.Steps.Parameters;

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
			IWeaverQuery q = 
				Weave.Inst.TitanGraph()
				.QueryV().ElasticIndex(
					new WeaverParamElastic<User>(x => x.Name, WeaverParamElasticOp.Contains, vUsername)
				)
				.CustomStep("_()") //TODO: resolve "underscore" workaround
				.Has(x => x.Password, WeaverStepHasOp.EqualTo, FabricUtil.HashPassword(vPassword))
				.ToQuery();

			return ApiCtx.DbSingle<User>(Query.GetUser+"", q);
		}
		
	}

}