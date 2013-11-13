using System;
using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Steps;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TraversalOperation : ITraversalOperation {

		private static readonly Logger Log = Logger.Build<TraversalOperation>();

		private static readonly IList<ITravStep> StepList = BuildStepList();
		private static readonly IDictionary<string, IList<ITravStep>> StepMap = BuildStepMap();
		private static readonly IDictionary<Type, IList<FabTravStep>> TypeStepsMap =BuildTypeStepsMap();

		protected IOperationContext OpCtx { get; set; }
		protected ITravPath Path { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Perform(IOperationContext pOpCtx, string pPath) {
			OpCtx = pOpCtx;
			Path = new TravPath(pPath, OpCtx.MemberId);

			ITravPathItem tps = Path.GetNextStep();

			while ( tps != null ) {
				if ( !StepMap.ContainsKey(tps.Command) ) {
					throw tps.NewStepFault(FabFault.Code.InvalidStep,
						"Step '"+tps.Command+"' is not valid.");
				}

				IList<ITravStep> steps = StepMap[tps.Command];
				ITravStep step = null;

				foreach ( ITravStep s in steps ) {
					if ( s.AcceptsPath(Path) ) {
						step = s;
						break;
					}
				}

				if ( step == null ) {
					throw tps.NewStepFault(FabFault.Code.InternalError, "Step could not be processed.");
				}

				step.ConsumePath(Path);
				tps = Path.GetNextStep();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<FabObject> GetResult() {
			Type t = Path.GetCurrentType();
			
			var list = new List<FabObject>();
			list.Add((FabObject)Activator.CreateInstance(t, false));
			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<FabTravStep> GetResultSteps() {
			Type t = Path.GetCurrentType();
			Log.Debug("GetResultSteps: "+t.Name);
			return (TypeStepsMap.ContainsKey(t) ? TypeStepsMap[t] : new List<FabTravStep>());
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
		private static IDictionary<string, IList<ITravStep>> BuildStepMap() {
			var map = new Dictionary<string, IList<ITravStep>>();

			foreach ( ITravStep step in StepList ) {
				if ( step == null ) {
					continue;
				}

				string key = step.Command;

				if ( !map.ContainsKey(key) ) {
					map.Add(key, new List<ITravStep>());
				}

				map[key].Add(step);
			}

			return map;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static IDictionary<Type, IList<FabTravStep>> BuildTypeStepsMap() {
			var map = new Dictionary<Type, IList<FabTravStep>>();
			Type fabObjType = typeof(FabObject);
			Type[] types = fabObjType.Assembly.GetTypes();

			foreach ( Type t in types ) {
				if ( !fabObjType.IsAssignableFrom(t) ) {
					continue;
				}

				var list = new List<FabTravStep>();
				map.Add(t, list);

				foreach ( ITravStep step in StepList ) {
					if ( step == null || !TravPath.IsSameTypeOrSubclass(step.FromType, t) ) {
						continue;
					}

					var fts = new FabTravStep();
					fts.Name = step.Name;
					fts.Uri = "/"+step.Command;
					fts.Returns = step.ToType.Name;
					list.Add(fts);
				}
			}

			return map;
		}

	}

}