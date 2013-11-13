using System;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public abstract class TravRule {
		
		public string Name { get; private set; }
		public string Command { get; private set; }
		public Type FromType { get; private set; }
		public Type ToType { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TravRule(string pCommand, Type pFromType, Type pToType) {
			Name = pCommand;
			Command = pCommand.ToLower();
			FromType = pFromType;
			ToType = pToType;
		}

	}


	/*================================================================================================*/
	public class TravRule<TFrom, TTo> : TravRule {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected TravRule(string pCommand) : base(pCommand, typeof(TFrom), typeof(TTo)) {}

	}

}