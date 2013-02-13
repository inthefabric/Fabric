﻿using System;
using System.Text.RegularExpressions;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public interface IFuncAsStep : IFuncStep {
		
		string Alias { get; }
		
	}
		

	/*================================================================================================*/
	[Func("As")]
	public class FuncAsStep : FuncStep, IFuncAsStep {
		
		public const int LenMin = 1;
		public const int LenMax = 8;
		public const string ValidRegex = "^[a-zA-Z]+[a-zA-Z0-9]*$";

		[FuncParam(0, LenMin, LenMax, ValidRegex)]
		public string Alias { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncAsStep(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "as");
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
					"Could not convert to type 'string'.", 0, ex);
			}
			
			if ( Alias.Length < LenMin || Alias.Length > LenMax ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Invalid length.", 0);
			}
			
			if ( !Regex.IsMatch(Alias, ValidRegex) ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Invalid format.", 0);
			}
			
			IFuncAsStep asStep = Path.GetAlias(Alias);
			
			if ( asStep != null ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this,
					"The alias '"+Alias+"' is already in use.", 0);
					//Path.GetSegmentIndexOfStep(asStep)+".");
			}
			
			////

			ProxyStep = Path.GetSegmentBeforeLast(1).Step;
			Path.AppendToCurrentSegment("('"+Alias+"')", false);
			Path.RegisterAlias(this);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return true;
		}

	}

}