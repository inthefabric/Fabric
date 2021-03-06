﻿using Fabric.Domain;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Query;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Operations.Create {

	/*================================================================================================*/
	public partial class CreateOperationTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void FindDuplicateMember(
										ICreateOperationBuilder pCreCtx, long pUserId, long pAppId) {
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
				if ( dr.ToIntAt(i, 0) != 1 ) {
					throw new FabDuplicateFault("A "+typeof(Member).Name+" already exists with "+
						typeof(App).Name+"Id="+pAppId+" and "+
						typeof(User).Name+"Id="+pUserId+".");
				}
			}));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void FindDuplicateClass(
								ICreateOperationBuilder pCreCtx, string pNameKey, string pDisambLower) {
			Class c = Weave.Inst.Graph.V
				.ExactIndex<Class>(x => x.NameKey, pNameKey);

			IWeaverQuery q;

			if ( pDisambLower == null ) {
				q = c.HasNot(x => x.Disamb)
					.Property(x => x.VertexId)
					.ToQuery();
			}
			else {
				q = c.Has(x => x.Disamb)
					.CustomStep("filter{"+
						"it.property('"+DbName.Vert.Class.Disamb+"').next().toLowerCase()==_P1"+
					"}")
					.Property(x => x.VertexId)
					.ToQuery();

				q.AddParam(new WeaverQueryVal(pDisambLower));
			}

			////

			const string classVarName = "c";
			IWeaverVarAlias<Class> alias;
			q = WeaverQuery.StoreResultAsVar(classVarName, q, out alias);
			pCreCtx.AddQuery(q, true, classVarName+"?0:1;");

			string cmdId = pCreCtx.SetupLatestCommand(false, true);

			pCreCtx.AddCheck(new DataResultCheck(cmdId, (dr, i) => {
				if ( dr.ToIntAt(i, 0) != 1 ) {
					string name = pNameKey+(pDisambLower == null ? "" : " ("+pDisambLower+")");
					throw new FabDuplicateFault(typeof(Class), "Name", name, "Name+Disamb conflict.");
				}
			}));
		}

	}

}