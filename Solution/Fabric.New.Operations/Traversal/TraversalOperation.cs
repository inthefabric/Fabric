using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Steps;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TraversalOperation : ITraversalOperation {

		//private static readonly Logger Log = Logger.Build<TraversalOperation>();
		private static readonly IList<ITravStep> AllSteps = BuildAllSteps();
		private static readonly IDictionary<string, IList<ITravStep>> AllStepsMap = BuildAllStepsMap();

		protected IOperationContext OpCtx { get; set; }
		protected ITravPath Path { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Perform(IOperationContext pOpCtx, string pPath) {
			OpCtx = pOpCtx;
			Path = new TravPath(pPath, OpCtx.MemberId);

			ITravPathItem tps = Path.GetNextStep();

			while ( tps != null ) {
				if ( !AllStepsMap.ContainsKey(tps.Command) ) {
					throw tps.NewStepFault(FabFault.Code.InvalidStep,
						"Step '"+tps.Command+"' is not valid.");
				}

				IList<ITravStep> steps = AllStepsMap[tps.Command];
				ITravStep step = null;

				foreach ( ITravStep s in steps ) {
					if ( s.AcceptsPath(Path) ) {
						step = s;
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
			var list = new List<FabObject>();
			list.Add(new FabApp());
			return list;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IList<ITravStep> BuildAllSteps() {
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
		private static IDictionary<string, IList<ITravStep>> BuildAllStepsMap() {
			var map = new Dictionary<string, IList<ITravStep>>();

			foreach ( ITravStep step in AllSteps ) {
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
	}

}