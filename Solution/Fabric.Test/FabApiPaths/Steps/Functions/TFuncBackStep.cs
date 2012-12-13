using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Functions;
using NUnit.Framework;

namespace Fabric.Test.FabApiPaths.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncBackStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			var s = new FuncBackStep(p);

			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.Null(s.TypeId, "TypeId should be null.");
			Assert.Null(s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void SetDataAndUpdatePathNoParams() {
			var p = new Path();
			var s = new FuncBackStep(p);
			s.SetDataAndUpdatePath(new StepData("back"));
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void SetDataAndUpdatePathBackTooFar() {
			var p = new Path();
			p.AddSegment(null, "first");
			p.AddSegment(null, "second(x)");
			p.AddSegment(null, "third");

			var s = new FuncBackStep(p);
			s.SetDataAndUpdatePath(new StepData("back(4)"));
		}*/

	}

}