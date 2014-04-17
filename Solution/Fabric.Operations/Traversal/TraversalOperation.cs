using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Conversions;
using Fabric.Api.Objects.Traversal;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Faults;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Steps;
using Fabric.Operations.Traversal.Util;
using Weaver.Core.Query;

namespace Fabric.Operations.Traversal {

	/*================================================================================================*/
	public class TraversalOperation : ITraversalOperation {

		private IOperationContext vOpCtx;
		private ITravPathData vPathData;
		private ITravPath vPath;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IList<FabElement> Execute(IOperationContext pOpCtx, string pPath) {
			vOpCtx = pOpCtx;
			BuildPath(pPath);
			return ExecutePath();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<FabTravStep> GetResultSteps() {
			return TraversalUtil.GetFabTravSteps(vPathData.CurrType);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void BuildPath(string pPath) {
			vPathData = new TravPathData(pPath, vOpCtx.Auth.ActiveMemberId);
			vPath = new TravPath(vPathData);

			ITravPathItem tps = vPath.GetNextStep();
			ITravRule rule = null;

			while ( tps != null ) {
				rule = FindRuleForStep(tps);
				rule.Step.ConsumePath(vPath, rule.ToType);
				tps = vPath.GetNextStep();
			}

			if ( rule == null || !rule.Step.EndsWithRangeFilter ) {
				vPathData.AddScript("[0.."+(TravStepTake.Maximum-1)+"]");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private ITravRule FindRuleForStep(ITravPathItem pStep) {
			IList<ITravRule> rules = TraversalUtil.GetTravRules(vPathData.CurrType);

			foreach ( ITravRule r in rules ) {
				if ( r.Step.AcceptsPath(vPath) ) {
					return r;
				}
			}

			throw pStep.NewStepFault(FabFault.Code.InvalidStep,
				"Step '"+pStep.Command+"' is not valid.");
		}

		/*--------------------------------------------------------------------------------------------*/
		private IList<FabElement> ExecutePath() {
			if ( typeof(FabTravTypedRoot).IsAssignableFrom(vPathData.CurrType) ) {
				return new List<FabElement>();
			}

			IWeaverQuery q = vPathData.BuildQuery();
			string name = "Trav"+string.Join("", 
				vPath.GetFirstSteps(2).Select(x => "-"+x.Command.ToLower()));

			IList<IDataDto> verts = vOpCtx.Data.Execute(q, name).ToDtoList();
			return verts.Select(DbToApi.FromDataDto).ToList();
		}

	}

}