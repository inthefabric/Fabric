using Fabric.New.Domain;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public partial class CreateClassOperation {

		private string vCmdDuplicate;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void VerifyCustomClass() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterSessionStart() {
			Class c = Weave.Inst.Graph.V.ExactIndex<Class>(x => x.NameKey, NewDom.Name.ToLower());
			IWeaverQuery q;

			if ( NewDom.Disamb == null ) {
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

				q.AddParam(new WeaverQueryVal(NewDom.Disamb.ToLower()));
			}

			////

			const string classVarName = "c";
			IWeaverVarAlias<Class> alias;
			q = WeaverQuery.StoreResultAsVar(classVarName, q, out alias);
			DataAcc.AddQuery(q, true);
			DataAcc.AppendScriptToLatestCommand(classVarName+"?1:0;");
			vCmdDuplicate = SetupLatestCommand(false, true);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterExecute() {
			//TEST: CreateClassOperation.AfterExecute()
			int dupI = DataRes.GetCommandIndexByCmdId(vCmdDuplicate);
			int dupVal = DataRes.ToIntAt(dupI, 0);

			if ( dupVal == 0 ) {
				return;
			}

			string dupName = NewDom.Name+(NewDom.Disamb == null ? "" : " ("+NewDom.Disamb+")");
			throw new FabDuplicateFault(typeof(Class), "Name", dupName, "Name+Disamb conflict.");
		}

	}

}