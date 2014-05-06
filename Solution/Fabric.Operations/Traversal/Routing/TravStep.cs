using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Fabric.Infrastructure.Faults;

namespace Fabric.Operations.Traversal.Routing {

	/*================================================================================================*/
	public abstract class TravStep : ITravStep {
		
		public string Command { get; private set; }
		public string CommandLow { get; private set; }
		public Type FromType { get; private set; }
		public Type ToType { get; private set; }
		public Type ParamValueType { get; protected set; }
		public bool ToAliasType { get; protected set; }
		public bool FromExactType { get; protected set; }
		public bool EndsWithRangeFilter { get; protected set; }

		public IList<ITravStepParam> Params { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TravStep(string pCmd, Type pFromType, Type pToType) {
			Command = pCmd;
			CommandLow = pCmd.ToLower();
			FromType = pFromType;
			ToType = pToType;

			Params = new List<ITravStepParam>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool AcceptsPath(ITravPath pPath) {
			if ( !pPath.IsAcceptableType(FromType, FromExactType) ) {
				return false;
			}

			IList<ITravPathItem> steps = pPath.GetSteps(1);

			if ( steps != null ) {
				ITravPathItem s = steps[0];
				return (s.Command == CommandLow);
			}

			return false;
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract void ConsumePath(ITravPath pPath, Type pToType);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected T ParamAt<T>(ITravPathItem pItem, int pIndex) {
			ITravStepParam p = Params[pIndex];
			T val = pItem.GetParamAt<T>(pIndex);
			string valStr = val+"";

			if ( valStr.Length == 0 ) {
				throw pItem.NewStepFault(FabFault.Code.IncorrectParamValue,
					p.Name+" is empty.", pIndex);
			}

			if ( p.Min != null && long.Parse(valStr) < p.Min ) {
				throw pItem.NewStepFault(FabFault.Code.IncorrectParamValue,
					p.Name+" cannot be less than "+p.Min, pIndex);
			}

			if ( p.Max != null && long.Parse(valStr) > p.Max ) {
				throw pItem.NewStepFault(FabFault.Code.IncorrectParamValue,
					p.Name+" cannot be greater than "+p.Max, pIndex);
			}

			if ( p.LenMax != null && valStr.Length > p.LenMax ) {
				throw pItem.NewStepFault(FabFault.Code.IncorrectParamValue,
					p.Name+" cannot exceed "+p.LenMax+" characters.", pIndex);
			}

			if ( p.ValidRegex != null && !Regex.IsMatch(valStr, p.ValidRegex) ) {
				throw pItem.NewStepFault(FabFault.Code.IncorrectParamValue,
					"Invalid "+p.Name+" format.", pIndex);
			}

			if ( p.AcceptedStrings != null && !p.AcceptedStrings.Contains(valStr) ) {
				throw pItem.NewStepFault(FabFault.Code.IncorrectParamValue,
					"Invalid "+p.Name+" value. Accepted values: "+
					string.Join(", ", p.AcceptedStrings)+".", pIndex);
			}

			return val;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected ITravPathItem ConsumeFirstPathItem(ITravPath pPath, Type pToType) {
			ITravPathItem item = pPath.ConsumeSteps(1, pToType)[0];
			item.VerifyParamCount(Params.Count);
			return item;
		}

	}


	/*================================================================================================*/
	public abstract class TravStep<TFrom, TTo> : TravStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TravStep(string pCmd) : base(pCmd, typeof(TFrom), typeof(TTo)) {}

	}

}