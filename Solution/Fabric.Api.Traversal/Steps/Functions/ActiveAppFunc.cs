using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("ActiveApp", IsInternal=true, ReturnsObjectType=typeof(FabApp))]
	public class ActiveAppFunc : AppIdIndexFunc, IFinalStep {

		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ActiveAppFunc(IPath pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			ExpectParamCount(0);
			Value = Path.AppId;
		}

	}

}