using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps.Functions;
using Moq;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public abstract class TestFinalStep : FuncLimitStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TestFinalStep() : base(new Mock<IPath>().Object) {}

	}

}