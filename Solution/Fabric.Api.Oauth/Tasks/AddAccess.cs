using System;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Tasks {
	
	/*================================================================================================*/
	public class AddAccess : ApiFunc<OAuthAccessResult> {
		
		protected FabAppKey vAppKey;
		protected FabUserKey vUserKey;
		private readonly int vExpireSec;
		private readonly bool vClientOnly;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AddAccess(FabAppKey pAppKey, FabUserKey pUserKey, int pExpireSec,
															bool pClientOnly) :	base(AuthType.None) {
			vAppKey = pAppKey;
			vUserKey = pUserKey;
			vExpireSec = pExpireSec;
			vClientOnly = pClientOnly;

			AddTransactionFunc(ClearOldTokens);
			AddTransactionFunc(DoAccessAdd);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void PreGoChecks() {
			if ( vAppKey == null ) { throw new FabArgumentNullFault("AppKey"); }
			
			if ( vClientOnly ) {
				if ( vUserKey != null ) {
					throw new FabArgumentFault("UserKey must be null in ClientOnly mode.");
				}

				vUserKey = new FabUserKey(1); //Fabric System (ID can't be zero)
			}
			else if ( vUserKey == null ) {
				throw new FabArgumentNullFault("UserKey");
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void ClearOldTokens(ISession pSession) {
			//Clear out the Token value of old records instead of removing the row. The rows will
			//provide good historical data about logins and app usage. Use the OauthAccess ID value
			//to replace the Token, because the Token column has a unique constraint.

			string q = String.Format(
				"UPDATE {0}{1} SET {2}={1}Id WHERE {3}={4} AND {5}={6} AND {7}({2})=32",
				Context.SqlSchemaWithDot, FabricUtil.GetTableName<OauthAccess>(), "Token",
				typeof(App).Name+"Id", vAppKey.Id,
				typeof(Usr).Name+"Id", vUserKey.Id,
				Context.SqlStringLengthFunc);
			pSession.CreateSQLQuery(q).UniqueResult();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void DoAccessAdd(ISession pSession) {
			OauthAccess oa = new OauthAccess();
			oa.App = pSession.Load<App>(vAppKey.Id);
			oa.Usr = pSession.Load<Usr>(vUserKey.Id);
			oa.Expires = GetDbNow(pSession).AddSeconds(vExpireSec);
			oa.Token = FabricUtil.Code32();
			oa.Refresh = FabricUtil.Code32();
			oa.IsClientOnly = vClientOnly;
			pSession.Save(oa);

			OAuthAccessResult res = new OAuthAccessResult();
			res.Token = oa.Token;
			res.Refresh = oa.Refresh;
			res.ExpireSec = vExpireSec;
			SetResult(res);
		}

	}
	
	/*================================================================================================*/
	public class OAuthAccessResult {
		public string Token;
		public string Refresh;
		public int ExpireSec;
	}

}
