using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public partial class CreateOperationTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void FindDuplicateMember(
										ICreateOperationContext pCreCtx, long pUserId, long pAppId) {
			IWeaverVarAlias<Member> alias;
			const string varName = "m";

			IWeaverQuery q = Weave.Inst.Graph.V
				.ExactIndex<User>(x => x.VertexId, pUserId)
				.DefinesMembers
					.Has(x => x.AppId, WeaverStepHasOp.EqualTo, pAppId)
				.ToQueryAsVar(varName, out alias);

			pCreCtx.AddQuery(q, true, varName+"?0:1;");
			string cmdId = pCreCtx.SetupLatestCommand(false, true);

			pCreCtx.AddCheck(new DataResultCheck(cmdId, (dr, i) => {
				if ( dr.ToIntAt(i, 0) != 0 ) {
					throw new FabDuplicateFault("A "+typeof(Member).Name+" already exists with "+
						typeof(App).Name+"Id="+pAppId+" and "+
						typeof(User).Name+"Id="+pUserId+".");
				}
			}));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void FindDuplicateClass(
										ICreateOperationContext pCreCtx, string pName, string pDisamb) {
			Class c = Weave.Inst.Graph.V.ExactIndex<Class>(x => x.NameKey, pName.ToLower());
			IWeaverQuery q;

			if ( pDisamb == null ) {
				q = c.HasNot(x => x.Disamb)
					.Property(x => x.VertexId)
					.ToQuery();
			}
			else {
				q = c.CustomStep(
					"filter{"+ //the "?." before "toLowerCase()" is the "safe-navigation" operator
						"it.property('"+DbName.Vert.Class.Disamb+"')?.toLowerCase()==_P1;"+
					"}")
					.Property(x => x.VertexId)
					.ToQuery();

				q.AddParam(new WeaverQueryVal(pDisamb.ToLower()));
			}

			////

			const string classVarName = "c";
			IWeaverVarAlias<Class> alias;
			q = WeaverQuery.StoreResultAsVar(classVarName, q, out alias);
			pCreCtx.AddQuery(q, true, classVarName+"?1:0;");

			string cmdId = pCreCtx.SetupLatestCommand(false, true);

			pCreCtx.AddCheck(new DataResultCheck(cmdId, (dr, i) => {
				if ( dr.ToIntAt(i, 0) != 0 ) {
					string name = pName+(pDisamb == null ? "" : " ("+pDisamb+")");
					throw new FabDuplicateFault(typeof(Class), "Name", name, "Name+Disamb conflict.");
				}
			}));
		}

	}

}