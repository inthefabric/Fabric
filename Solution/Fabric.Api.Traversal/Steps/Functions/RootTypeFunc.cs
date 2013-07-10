using System;
using System.Collections.Generic;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	//TEST: all FuncRootTypeStep

	/*================================================================================================*/
	public abstract partial class RootTypeFunc : Func, IFinalStep {

		private static readonly List<IStepLink> vAvailLinks = new List<IStepLink>();
		private static readonly List<string> vAvailFuncs = new List<string>();

		public bool UseLocalData { get { return true; } }
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected RootTypeFunc(IPath pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks { get { return vAvailLinks; } }
		public override List<string> AvailableFuncs { get { return vAvailFuncs; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

	}

}