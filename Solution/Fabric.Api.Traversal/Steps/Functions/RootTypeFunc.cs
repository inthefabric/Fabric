using System;
using Fabric.Api.Dto.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	//TEST: all FuncRootTypeStep

	/*================================================================================================*/
	public abstract partial class RootTypeFunc : Func, IFinalStep {

		public bool UseLocalData { get { return true; } }
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected RootTypeFunc(IPath pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

	}

}