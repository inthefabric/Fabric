using System;
using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal.Routing {

	/*================================================================================================*/
	public abstract class TravStep : ITravStep {
		
		public string Command { get; private set; }
		public string CommandLow { get; private set; }
		public Type FromType { get; private set; }
		public Type ToType { get; private set; }
		public bool ToAliasType { get; protected set; }
		public bool FromExactType { get; protected set; }

		protected IList<ITravStepParam> Params { get; private set; }


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
		public virtual bool AcceptsPath(ITravPath pPath) {
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