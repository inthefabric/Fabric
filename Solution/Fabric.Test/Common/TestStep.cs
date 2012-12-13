using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Nodes;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestStep : Step<TestFabNode> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestStep(Path pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps {
			get { return new[] { "Test1", "TEST2" }; }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "test1": return new ArtifactStep(true, Path);
				case "test2": return new FactorStep(true, Path);
			}

			return base.GetNextStep(pData);
		}

	}

}