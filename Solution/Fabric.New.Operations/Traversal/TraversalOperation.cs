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

		private IOperationContext vOpCtx;
		private ITravPathData vPathData;
		private ITravPath vPath;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Perform(IOperationContext pOpCtx, string pPath) {
			vOpCtx = pOpCtx;

			vPathData = new TravPathData(pPath, vOpCtx.Auth.ActiveMemberId);
			vPath = new TravPath(vPathData);

			ITravPathItem tps = vPath.GetNextStep();

			while ( tps != null ) {
				IList<ITravRule> rules = TraversalUtil.GetTravRules(vPathData.CurrType);
				ITravRule rule = null;

				foreach ( ITravRule r in rules ) {
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
			IWeaverQuery q = vPathData.BuildQuery();
			string qid = "Trav"+string.Join("", vPath.GetFirstSteps(2).Select(x => "-"+x.Command));

			IList<IDataDto> verts = vOpCtx.Data.Execute(q, qid).ToDtoList();
			return verts.Select(DbToApi.FromDataDto).ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<FabTravStep> GetResultSteps() {
			return TraversalUtil.GetFabTravSteps(vPathData.CurrType);
		}

	}

}