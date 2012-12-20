using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Functions;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestFuncStep : FuncStep {

		public const string SegmentText = "testFunc(x)";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestFuncStep(Path pPath) : base(pPath) {
			Path.AddSegment(this, SegmentText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);

			int segI = Path.Segments.Count-2;

			if ( segI < 0 ) {
				return;
			}

			ProxyStep = Path.Segments[segI].Step;
		}
	}

}