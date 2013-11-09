﻿namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public interface ITravPathStep {

		int StepIndex { get; }
		string RawText { get; }
		string Command { get; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		T ParamAt<T>(int pIndex);

		/*--------------------------------------------------------------------------------------------*/
		int GetParamCount();

		/*--------------------------------------------------------------------------------------------*/
		void VerifyParamCount(int pMinCount, int pMaxCount=-1);

	}

}