using Fabric.Api.Objects.Conversions;
using Fabric.Domain;
using Fabric.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps.Statements;

namespace Fabric.Operations.Web {

	/*================================================================================================*/
	public class WebUpdateAppSecretOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SuccessResult Execute(IOperationContext pOpCtx, long pAppId) {
			string secret = pOpCtx.Code32;
			CreateFabAppValidator.Secret(secret);

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, pAppId)
					.SideEffect(new WeaverStatementSetProperty<App>(x => x.Secret, secret))
				.ToQuery();

			App app = pOpCtx.Data.Get<App>(q, "Web-UpdateAppSecret");
			return new SuccessResult(app != null);
		}

	}

}