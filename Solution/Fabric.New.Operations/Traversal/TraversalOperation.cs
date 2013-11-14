using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Steps;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TraversalOperation : ITraversalOperation {

		//private static readonly Logger Log = Logger.Build<TraversalOperation>();

		private static readonly IList<ITravStep> StepList = BuildStepList();
		private static readonly IDictionary<Type, IList<TravRule>> RulesMap = BuildRulesMap();

		private IOperationContext vOpCtx;
		private ITravPath vPath;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Perform(IOperationContext pOpCtx, string pPath) {
			vOpCtx = pOpCtx;
			vPath = new TravPath(pPath, vOpCtx.MemberId);

			ITravPathItem tps = vPath.GetNextStep();

			while ( tps != null ) {
				IList<TravRule> rules = RulesMap[vPath.GetCurrentType()];
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
		public IList<FabObject> GetResult() {
			Type t = vPath.GetCurrentType();
			
			var list = new List<FabObject>();
			list.Add((FabObject)Activator.CreateInstance(t, false));
			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<FabTravStep> GetResultSteps() {
			Type t = vPath.GetCurrentType();

			if ( !RulesMap.ContainsKey(t) ) {
				return new List<FabTravStep>();
			}

			return RulesMap[t].Select(x => x.ToFabTravStep()).ToList();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IList<ITravStep> BuildStepList() {
			var list = new List<ITravStep>();
			list.AddRange(TravSteps.EntryList);
			list.AddRange(TravSteps.LinkHasList);
			list.AddRange(TravSteps.LinkList);
			list.AddRange(TravSteps.LinkTakeList);
			list.AddRange(TravSteps.RootList);
			list.AddRange(TravSteps.ToTypeList);
			list.AddRange(TravSteps.VertexHasList);
			list.AddRange(TravStepsCustom.FuncList);
			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IDictionary<Type, IList<TravRule>> BuildRulesMap() {
			var map = new Dictionary<Type, IList<TravRule>>();
			Type ot = typeof(FabObject);
			Type[] types = ot.Assembly.GetTypes();

			foreach ( Type ft in types ) {
				if ( !ot.IsAssignableFrom(ft) ) {
					continue;
				}

				map.Add(ft, new List<TravRule>());

				foreach ( ITravStep step in StepList ) {
					if ( !IsAcceptableStepForType(step, ft) ) {
						continue;
					}

					Type tt = GetStepToType(step, ft);
					map[ft].Add(new TravRule(step, ft, tt));
				}
			}

			return map;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static bool IsAcceptableStepForType(ITravStep pStep, Type pFromType) {
			if ( pStep == null ) {
				return false;
			}

			if ( !TravPath.IsSameTypeOrSubclass(pStep.FromType, pFromType) ) {
				return false;
			}

			if ( pStep.FromExactType && pFromType != pStep.FromType ) {
				return false;
			}

			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static Type GetStepToType(ITravStep pStep, Type pFromType) {
			if ( pStep.ToAliasType ) {
				return null;
			}

			Type tt = pStep.ToType;

			if ( TravPath.IsSameTypeOrSubclass(typeof(FabTravTypedRoot), pFromType) ) {
				Type baseType = FabTravTypedRoot.BaseTypeMap[pFromType];

				if ( TravPath.IsSameTypeOrSubclass(tt, baseType) ) {
					return baseType;
				}
			}
			
			if ( TravPath.IsSameTypeOrSubclass(tt, pFromType) ) {
				return pFromType;
			}

			return tt;
		}

	}

}