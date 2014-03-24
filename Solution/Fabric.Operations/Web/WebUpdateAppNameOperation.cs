using Fabric.Domain;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;

namespace Fabric.Operations.Web {

	/*================================================================================================*/
	public class WebUpdateAppNameOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SuccessResult Execute(IOperationContext pOpCtx, long pAppId, string pName) {
			ConfirmUniqueAppName(pOpCtx, pName);
			App app = UpdateAppName(pOpCtx, pAppId, pName);
			return new SuccessResult(app != null);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void ConfirmUniqueAppName(IOperationContext pOpCtx, string pName) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.NameKey, pName.ToLower())
				.ToQuery();

			App app = pOpCtx.Data.Get<App>(q, "Web-GetAppByName");

			if ( app != null && app.Name.ToLower() == pName.ToLower() ) {
				throw new FabDuplicateFault(typeof(App), "Name", pName);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static App UpdateAppName(IOperationContext pOpCtx, long pAppId, string pName) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, pAppId)
					.SideEffect(new WeaverStatementSetProperty<App>(x => x.Name, pName))
				.ToQuery();

			return pOpCtx.Data.Get<App>(q, "Web-UpdateAppName");
		}

	}

}