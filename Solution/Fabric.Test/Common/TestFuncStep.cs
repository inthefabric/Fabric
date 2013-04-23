using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class TestFuncStep : FuncStep {

		public const string SegmentText = "testFunc(x)";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestFuncStep(IPath pPath) : base(pPath) {
			Path.AddSegment(this, SegmentText);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);

			if ( Path.GetSegmentCount()-2 >= 0 ) {
				ProxyStep = Path.GetSegmentBeforeLast(1).Step;
			}
		}
	}

}