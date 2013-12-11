using Fabric.New.Domain;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public partial class CreateMemberOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void VerifyCustomMember() { }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterSessionStart() {
			IWeaverVarAlias<Member> alias;
			const string varName = "m";

			IWeaverQuery q = Weave.Inst.Graph.V
				.ExactIndex<User>(x => x.VertexId, NewCre.DefinedByUserId)
				.DefinesMembers
					.Has(x => x.AppId, WeaverStepHasOp.EqualTo, NewCre.DefinedByAppId)
				.ToQueryAsVar(varName, out alias);

			DataAcc.AddQuery(q, true);
			DataAcc.AppendScriptToLatestCommand("("+varName+"?0:1);");
			string cmdId = CreCtx.SetupLatestCommand(false, true);

			CreCtx.AddCheck(new DataResultCheck(cmdId, (dr, i) => {
				if ( dr.ToIntAt(i, 0) != 0 ) {
					throw new FabDuplicateFault("A "+typeof(Member).Name+" already exists with "+
						typeof(App).Name+"Id="+NewCre.DefinedByAppId+" and "+
						typeof(User).Name+"Id="+NewCre.DefinedByUserId+".");
				}
			}));
		}

	}

}