using System.Collections.Generic;
using System.Linq;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Conversions;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Util;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TraversalOperation : ITraversalOperation {

		//private static readonly Logger Log = Logger.Build<TraversalOperation>();

		private IOperationContext vOpCtx;
		private ITravPath vPath;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Perform(IOperationContext pOpCtx, string pPath) {
			vOpCtx = pOpCtx;

			vPath = new TravPath(pPath, vOpCtx.Auth.ActiveMemberId);

			ITravPathItem tps = vPath.GetNextStep();

			while ( tps != null ) {
				IList<TravRule> rules = TraversalUtil.GetTravRules(vPath.GetCurrentType());
				TravRule rule = null;

				foreach ( TravRule r in rules ) {
					if ( r.Step.AcceptsPath(vPath) ) {
						rule = r;
						break;
					}
				}

				if ( rule == null ) {
					throw tps.NewStepFault(FabFault.Code.InvalidStep,
						"Step '"+tps.Command+"' is not valid.");
				}

				rule.Step.ConsumePath(vPath, rule.ToType);
				tps = vPath.GetNextStep();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<FabElement> GetResult() {
			IWeaverQuery q = vPath.BuildQuery();
			//Log.Debug(DataUtil.WeaverQueryToJson(q));
			string qid = "Trav"+string.Join("", vPath.GetFirstSteps(2).Select(x => "-"+x.Command));

			IList<IDataDto> verts = vOpCtx.Data.Execute(q, qid).ToDtoList();
			return verts.Select(DbToApi.FromDataDto).ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<FabTravStep> GetResultSteps() {
			return TraversalUtil.GetFabTravSteps(vPath.GetCurrentType());
		}

	}

}