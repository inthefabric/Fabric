using System;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("Back")]
	public class FuncBackStep : FuncStep {

		//The correct way to read the "back" command is to count the period chars BEFORE ".back".
		//The next command will be issued from that period.

		//Example: g.v(0).out('HasX').inV(x).something(1,2).out('HasY').inV(y).filter(123).back(BACK)
		// * BACK == 1: next command will be issued as if it were after "inV(y)."
		// * BACK == 3: after "something(1,2)."
		// * BACK == 4: after "inV(x)."

		[FuncParam(0, 1)]
		public int Count { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncBackStep(Path pPath) : base(pPath) {
			Path.AddSegment(this, "back");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);

			if ( Data.Params == null || Data.Params.Length != 1 ) {
				throw new StepException(StepException.Code.IncorrectParamCount, this,
					"One parameter required.");
			}

			////

			int segCount;

			try {
				segCount = Data.ParamAt<int>(0);
			}
			catch ( InvalidCastException ex ) {
				throw new StepException(StepException.Code.IncorrectParamType, this,
					"Could not convert to type 'int'.", 0, ex);
			}

			if ( segCount <= 0 ) {
				throw new StepException(StepException.Code.IncorrectParamValue, this,
					"Cannot be less than 1.", 0);
			}

			////

			int numSegs = Path.Segments.Count-1; //skip "back" segment
			int maxSegCount = numSegs-1;

			if ( segCount > maxSegCount ) {
				throw new StepException(StepException.Code.IncorrectParamValue, this,
					"Exceeds the maximum 'back' steps ("+maxSegCount+") for the current path.", 0);
			}

			PathSegment seg;
			Count = 0;

			for ( int i = 0 ; i < segCount ; ++i ) {
				seg = Path.Segments[numSegs-i-1];
				Count += seg.SubstepCount;
			}

			seg = Path.Segments[numSegs-segCount-1];
			ProxyStep = seg.Step;
			Path.AppendToCurrentSegment("("+Count+")", false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			if ( pDtoType == typeof(FabRoot) ) { return false; }
			if ( pDtoType == typeof(FabOauth) ) { return false; }
			return true;
		}

	}

}