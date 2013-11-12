using System.Collections.Generic;
using System.Linq;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Steps;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TravOperation : ITravOperation {

		private static readonly IList<ITravStep> AllSteps = BuildAllSteps();
		private static readonly IDictionary<string, ITravStep> AllStepsMap = BuildAllStepsMap();

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

				ITravStep step = AllStepsMap[tps.Command];

				if ( !step.AcceptsPath(Path) ) {
					throw tps.NewStepFault(FabFault.Code.InternalError, "Step could not be processed.");
				}

				step.ConsumePath(Path);
				tps = Path.GetNextStep();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabObject GetResult() {
			return null;
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
		private static IDictionary<string, ITravStep> BuildAllStepsMap() {
			return AllSteps.ToDictionary(ts => ts.Command);
		}

	}

}