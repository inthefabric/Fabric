using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("Back")]
	public class FuncBackStep : FuncStep { //TEST: FuncBackStep

		//The correct way to read the "back" command is to count the period chars BEFORE ".back".
		//The next command will be issued from that period.

		//Example: g.v(0).out('HasX').inV(x).something(1,2).out('HasY').inV(y).filter(123).back(BACK)
		// * BACK == 1: next command will be issued as if it were after "inV(y)."
		// * BACK == 3: after "something(1,2)."
		// * BACK == 4: after "inV(x)."
		
		//given: g.A.B.C.D.E.F.G.back(4) == C
		//given: g.A.B.C.D.E.F.G.back(4).back(1) == C
		//given: g.A.B.C.D.E.F.G.back(4).back(3) == A

		//given: g.A.as('a').B.C.as('c').D.E.back('c') == C
		//given: g.A.as('a').B.C.as('c').D.E.back('a') == A
		//given: g.A.as('a').B.C.as('c').D.E.back('c').back('a') == A
		//given: g.A.as('a').B.C.as('c').D.E.back('a').back('c') == exception

		[FuncParam(0, FuncAsStep.LenMin, FuncAsStep.LenMax, FuncAsStep.ValidRegex)]
		public string Alias { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncBackStep(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "back");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			ExpectParamCount(1);

			////
			
			try {
				Alias = Data.ParamAt<string>(0);
			}
			catch ( InvalidCastException ex ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamType, this,
					"Could not convert to type 'int'.", 0, ex);
			}

			if ( Alias.Length < FuncAsStep.LenMin || Alias.Length > FuncAsStep.LenMax ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Invalid length.", 0);
			}
			
			if ( !Regex.IsMatch(Alias, FuncAsStep.ValidRegex) ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Invalid format.", 0);
			}
			
			IFuncAsStep asStep = Path.GetAlias(Alias);
			
			if ( asStep == null ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this,
					"The alias '"+Alias+"' was not found.", 0);
			}
			
			////
			
			//Ensure that a Back which occurs BEFORE this Back...
			//...is not linked to an Alias which occurs BEFORE this Alias
			
			int backI = Path.GetSegmentIndexOfStep(this);
			int aliasI = Path.GetSegmentIndexOfStep(asStep);
			IEnumerable<int> backSteps = Path.GetSegmentIndexesWithStepType<FuncBackStep>(backI);

			foreach ( int i in backSteps ) {
				FuncBackStep back = (FuncBackStep)Path.GetSegmentAt(i).Step;
				IFuncAsStep checkAlias = Path.GetAlias(back.Alias);
				int checkAliasI = Path.GetSegmentIndexOfStep(checkAlias);
				
				if ( checkAliasI >= aliasI ) {
					continue;
				}

				throw new FabStepFault(FabFault.Code.InvalidStep, this,
					"This step (at index "+backI+") links to alias at index "+aliasI+
					". This is invalid because the Back("+back.Alias+") step: A) occurs before this "+
					"step (at index "+i+"), and also B) links to an alias (at index "+checkAliasI+
					") that occurs before this step's alias.", 0);
			}
			
			////

			ProxyStep = asStep;
			Path.AppendToCurrentSegment("('"+Alias+"')", false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			if ( pDtoType == typeof(FabRoot) ) { return false; }
			return true;
		}

	}

}