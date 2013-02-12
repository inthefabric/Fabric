﻿using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;

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

		//TODO: Fix issues with multiple "Back" functions
		
		//given: g.A.B.C.D.E.F.G.back(4) == C
		//given: g.A.B.C.D.E.F.G.back(4).back(1) == C
		//given: g.A.B.C.D.E.F.G.back(4).back(3) == A

		//given: g.A.as('a').B.C.as('c').D.E.back('c') == C
		//given: g.A.as('a').B.C.as('c').D.E.back('a') == A
		//given: g.A.as('a').B.C.as('c').D.E.back('c').back('a') == A
		//given: g.A.as('a').B.C.as('c').D.E.back('a').back('c') == exception

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
			ExpectParamCount(1);

			////

			int segCount;

			try {
				segCount = Data.ParamAt<int>(0);
			}
			catch ( InvalidCastException ex ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamType, this,
					"Could not convert to type 'int'.", 0, ex);
			}

			if ( segCount <= 0 ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this,
					"Cannot be less than 1.", 0);
			}

			////

			int numSegs = Path.Segments.Count-1; //skip "back" segment
			int maxSegCount = numSegs-1;

			if ( segCount > maxSegCount ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this,
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
			return true;
		}

	}

}