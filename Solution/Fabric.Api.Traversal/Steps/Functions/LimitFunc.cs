using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("Limit")]
	public class LimitFunc : Func, IFinalStep {

		public const string DefaultStepText = "Limit(0,20)";

		public bool UseLocalData { get { return false; } }

		[FuncParam(0, 0)]
		public long Index { get; private set; }

		[FuncParam(1, 0, 50)]
		public int Count { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public LimitFunc(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "dedup");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			ExpectParamCount(2);

			////

			try {
				Index = Data.ParamAt<long>(0);
			}
			catch ( InvalidCastException ex ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamType, this,
					"Could not convert to type 'long'.", 0, ex);
			}

			if ( Index < 0 ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this,
					"Cannot be less than 0.", 0);
			}

			////

			try {
				Count = Data.ParamAt<int>(1);
			}
			catch ( InvalidCastException ex ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamType, this,
					"Could not convert to type 'int'.", 1, ex);
			}

			if ( Count <= 0 || Count > 50 ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this,
					"Must be between 1 and 50.", 1);
			}

			////
			
			//The Limit function intentionally requests one more result than it needs. This allows the
			//API to determine if there are more items available after the requested set of items.

			ProxyStep = Path.GetSegmentBeforeLast(1).Step;

			string i0Param = Path.AddParam(new WeaverQueryVal(Index));
			string i1Param = Path.AddParam(new WeaverQueryVal(Index+Count));
			
			Path.AppendToCurrentSegment("["+i0Param+".."+i1Param+"]", false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			if ( pDtoType == typeof(FabRoot) ) { return false; }
			return true;
		}

	}

}