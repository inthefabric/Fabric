using System;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public abstract class TravStep : ITravStep {

		public string Command { get; private set; }
		public int Params { get; private set; }
		public Type FromType { get; private set; }
		public Type ToType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TravStep(string pCommand, int pParams, Type pFromType=null, Type pToType=null) {
			Command = pCommand.ToLower();
			FromType = pFromType;
			ToType = pToType;
			Params = pParams;
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract bool AcceptsPath(ITravPath pPath);

		/*--------------------------------------------------------------------------------------------*/
		public abstract void ConsumePath(ITravPath pPath);

	}


	/*================================================================================================*/
	public abstract class TravStep<TFrom, TTo> : TravStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TravStep(string pCommand, int pParams) : 
												base(pCommand, pParams, typeof(TFrom), typeof(TTo)) {}

	}

}