using Fabric.New.Domain;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;

namespace Fabric.New.Operations.Web {

	/*================================================================================================*/
	public class WebUpdateAppSecretOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SuccessResult Execute(IOperationContext pOpCtx, long pAppId, string pSecret) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, pAppId)
					.SideEffect(new WeaverStatementSetProperty<App>(x => x.Secret, pSecret))
				.ToQuery();

			App app = pOpCtx.Data.Get<App>(q, "Web-UpdateAppSecret");
			return new SuccessResult(app != null);
		}

	}

}