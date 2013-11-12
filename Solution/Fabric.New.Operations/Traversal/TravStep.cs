using System;
using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public abstract class TravStep : ITravStep {

		public string Command { get; private set; }
		public IList<ITravStepParam> Params { get; private set; }
		public Type FromType { get; private set; }
		public Type ToType { get; private set; }
		public bool ToAliasType { get; protected set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TravStep(string pCommand, Type pFromType, Type pToType) {
			Command = pCommand.ToLower();
			Params = new List<ITravStepParam>();
			FromType = pFromType;
			ToType = pToType;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual bool AcceptsPath(ITravPath pPath) {
			if ( !pPath.IsAcceptableType(FromType) ) {
				return false;
			}

			IList<ITravPathItem> steps = pPath.GetSteps(1);

			if ( steps != null ) {
				ITravPathItem s = steps[0];
				return (s.Command == Command);
			}

			return false;
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract void ConsumePath(ITravPath pPath);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ITravPathItem ConsumeFirstPathItem(ITravPath pPath) {
			ITravPathItem item = pPath.ConsumeSteps(1, ToType)[0];
			item.VerifyParamCount(Params.Count);
			return item;
		}

	}


	/*================================================================================================*/
	public abstract class TravStep<TFrom, TTo> : TravStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TravStep(string pCommand) : base(pCommand, typeof(TFrom), typeof(TTo)) {}

	}

}