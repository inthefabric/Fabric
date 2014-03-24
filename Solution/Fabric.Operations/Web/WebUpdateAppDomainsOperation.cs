using Fabric.Domain;
using Fabric.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;

namespace Fabric.Operations.Web {

	/*================================================================================================*/
	public class WebUpdateAppDomainsOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public App ExecuteAdd(IOperationContext pOpCtx, long pAppId, string pDomain) {
			App a = pOpCtx.Data.GetVertexById<App>(pAppId);
			a.OauthDomains += (string.IsNullOrEmpty(a.OauthDomains) ? "" : "|")+pDomain;
			return UpdateAppDomains(pOpCtx, a);
		}

		/*--------------------------------------------------------------------------------------------*/
		public App ExecuteRemove(IOperationContext pOpCtx, long pAppId, string pDomain) {
			App a = pOpCtx.Data.GetVertexById<App>(pAppId);

			if ( string.IsNullOrEmpty(a.OauthDomains) || !a.OauthDomains.Contains(pDomain) ) {
				return a;
			}

			a.OauthDomains = a.OauthDomains
				.Replace(pDomain, "")
				.Replace("||", "|")
				.Trim(new[] { '|' });

			return UpdateAppDomains(pOpCtx, a);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static App UpdateAppDomains(IOperationContext pOpCtx, App pApp) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, pApp.VertexId)
					.SideEffect(new WeaverStatementSetProperty<App>(
						x => x.OauthDomains, pApp.OauthDomains))
				.ToQuery();

			return pOpCtx.Data.Get<App>(q, "Web-UpdateAppDomains");
		}

	}

}