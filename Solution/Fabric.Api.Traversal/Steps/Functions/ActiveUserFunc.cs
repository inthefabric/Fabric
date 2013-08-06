using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("ActiveUser", IsInternal=true, ReturnsObject=typeof(FabUser))]
	public class ActiveUserFunc : UserIdIndexFunc, IFinalStep {

		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ActiveUserFunc(IPath pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			ExpectParamCount(0);
			Value = Path.UserId;
		}

	}

}