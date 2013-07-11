using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	public interface IFuncBackStep : IFunc {

		string Alias { get; }

	}
	
	/*================================================================================================*/
	[Func("Back")]
	public class BackFunc : Func {

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

		[FuncParam(0, AsFunc.LenMin, AsFunc.LenMax, AsFunc.ValidRegex)]
		public string Alias { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public BackFunc(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "back");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			ExpectParamCount(1);

			////
			
			Alias = ParamAt<string>(0);

			if ( Alias.Length < AsFunc.LenMin || Alias.Length > AsFunc.LenMax ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Invalid length.", 0);
			}
			
			if ( !Regex.IsMatch(Alias, AsFunc.ValidRegex) ) {
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
			IEnumerable<int> backSteps = Path.GetSegmentIndexesWithStepType<IFuncBackStep>(backI);

			foreach ( int checkBackI in backSteps ) {
				IFuncBackStep checkBack = (IFuncBackStep)Path.GetSegmentAt(checkBackI).Step;
				IFuncAsStep checkAlias = Path.GetAlias(checkBack.Alias);
				int checkAliasI = Path.GetSegmentIndexOfStep(checkAlias);

				if ( checkAliasI >= aliasI ) {
					continue;
				}

				throw new FabStepFault(FabFault.Code.InvalidStep, this,
					"Cannot traverse back to the As("+Alias+") step because it exists within the "+
					"As("+checkBack.Alias+") and Back("+checkBack.Alias+") traversal path.", 0);
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