using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Objects.Conversions;
using Fabric.Domain;
using Fabric.Infrastructure.Faults;
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

			if ( string.IsNullOrEmpty(a.OauthDomains) ) {
				return a;
			}

			IList<string> list = a.OauthDomains.Split('|').ToList();
			int i = list.IndexOf(pDomain);

			if ( i == -1 ) {
				throw new FabPropertyValueFault(
					"Domain '"+pDomain+"' (case-sensitive) is not present, and cannot be removed.");
			}

			list.RemoveAt(i);
			a.OauthDomains = string.Join("|", list);
			return UpdateAppDomains(pOpCtx, a);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static App UpdateAppDomains(IOperationContext pOpCtx, App pApp) {
			CreateFabAppValidator.OauthDomains(pApp.OauthDomains);

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, pApp.VertexId)
					.SideEffect(new WeaverStatementSetProperty<App>(
						x => x.OauthDomains, pApp.OauthDomains))
				.ToQuery();

			return pOpCtx.Data.Get<App>(q, "Web-UpdateAppDomains");
		}

	}

}