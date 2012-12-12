using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Nodes;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestNodeStep : NodeStep<TestFabNode> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestNodeStep(Path pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return "TestNodeStepId"; } }
		public override bool TypeIdIsLong { get { return true; } }

		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get { return new[] { "HasThing" }; }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "HasThing": return new ThingStep(true, Path);
			}

			return null;
		}

	}

}