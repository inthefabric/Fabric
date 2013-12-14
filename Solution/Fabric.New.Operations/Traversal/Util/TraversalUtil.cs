using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Steps;

namespace Fabric.New.Operations.Traversal.Util {

	/*================================================================================================*/
	public static class TraversalUtil {

		private static readonly IList<ITravStep> StepList = BuildStepList();
		private static readonly IList<ITravRule> RulesList = BuildRulesList();
		private static readonly IDictionary<Type, IList<ITravRule>> RulesMap = BuildRulesMap();
		private static readonly IDictionary<Type, IList<FabTravStep>> FabStepMap = BuildFabStepMap();


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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<ITravRule> GetTravRules() {
			return RulesList;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static IList<ITravRule> GetTravRules(Type pType) {
			return RulesMap[pType];
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IList<ITravRule> BuildRulesList() {
			var list = new List<ITravRule>();
			Type ot = typeof(FabObject);
			Type[] types = ot.Assembly.GetTypes();

			foreach ( Type ft in types ) {
				if ( !ot.IsAssignableFrom(ft) ) {
					continue;
				}

				foreach ( ITravStep step in StepList ) {
					if ( !IsAcceptableStepForType(step, ft) ) {
						continue;
					}

					Type tt = GetStepToType(step, ft);
					list.Add(new TravRule(step, ft, tt));
				}
			}

			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IDictionary<Type, IList<ITravRule>> BuildRulesMap() {
			var map = new Dictionary<Type, IList<ITravRule>>();

			foreach ( ITravRule rule in RulesList ) {
				Type ft = rule.FromType;

				if ( !map.ContainsKey(ft) ) {
					map.Add(ft, new List<ITravRule>());
				}

				map[ft].Add(rule);
			}

			return map;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static bool IsAcceptableStepForType(ITravStep pStep, Type pFromType) {
			if ( pStep == null ) {
				return false;
			}

			if ( !TravPathData.IsSameTypeOrSubclass(pStep.FromType, pFromType) ) {
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

			if ( TravPathData.IsSameTypeOrSubclass(typeof(FabTravTypedRoot), pFromType) ) {
				return FabTravTypedRoot.BaseTypeMap[pFromType];
			}

			if ( TravPathData.IsSameTypeOrSubclass(tt, pFromType) ) {
				return pFromType;
			}

			return tt;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<FabTravStep> GetFabTravSteps(Type pType) {
			return FabStepMap[pType];
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IDictionary<Type, IList<FabTravStep>> BuildFabStepMap() {
			var map = new Dictionary<Type, IList<FabTravStep>>();

			foreach ( KeyValuePair<Type, IList<ITravRule>> pair in RulesMap ) {
				map.Add(
					pair.Key,
					pair.Value.Select(TravRule.ToFabTravStep).ToList()
				);
			}

			return map;
		}

	}

}