using System;
using System.Text.RegularExpressions;
using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class GetAccessToken : ApiFunc<FabOauthAccess> {
		
		private readonly string vToken;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetAccessToken(string pToken) : base(AuthType.None) {
			vToken = pToken;
			AddTransactionFunc(DoAccessGet);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vToken == null ) { throw new FabArgumentNullFault("Token"); }
			if ( vToken.Length != 32 ) { throw new FabArgumentLengthFault("Token", 32, 32); }

			var r = new Regex("^[a-zA-Z0-9]*$");
			if ( !r.IsMatch(vToken) ) { throw new FabArgumentFault("Token must be alpha-numeric."); }
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void DoAccessGet(ISession pSession) {
			PreGoChecks(); //just in case, check for injection again...
			
			//OPTIMIZE: including "LIMIT 1" works with SQLite, but not SqlServer (uses "TOP"?).
			//It's not a SQL standard, so consider omitting it entirely.
			//LIMIT may not be much of a performance boost if Token is an indexed column.

			string q = String.Format(
				/*"SELECT {1}Id, IsClientOnly, {2}Id, {3}Id FROM {0}{1} "+
					"WHERE (Token='{4}' and Expires > CURRENT_TIMESTAMP)",
				Context.SqlSchemaWithDot, typeof(OauthAccess).Name,
				typeof(App).Name, typeof(User).Name, vToken);*/
				"SELECT * FROM {0}{1} WHERE (Token='{2}' and Expires > CURRENT_TIMESTAMP)",
				Context.SqlSchemaWithDot, FabricUtil.GetTableName<OauthAccess>(), vToken);
			
			OauthAccess oa = pSession.CreateSQLQuery(q)
				.AddEntity(typeof(OauthAccess))
				.UniqueResult<OauthAccess>();

			if ( oa == null ) { return; }
			SetResult(new FabOauthAccess(oa));

			//OPTIMIZE: shouldn't need to include Token and Expires. Discluding these columns
			//works in SQLite, but breaks in SqlServer. Below is a different attempt...

			/*object oa = pSession.CreateSQLQuery(q)
				.AddScalar("OauthAccessId", NHibernateUtil.Int32)
				.AddScalar("AppId", NHibernateUtil.Int32)
				.AddScalar("UserId", NHibernateUtil.Int32)
				.AddScalar("IsClientOnly", NHibernateUtil.Boolean)
				.UniqueResult();
			
			if ( oa == null ) { return; }
			FabOauthAccess dto = new FabOauthAccess();
			dto.AppKey = new FabAppKey(oa[1]);
			SetResult(dto);*/
		}

	}
}
