using System;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Traversal {

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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		FabStepFault NewStepFault(
			FabFault.Code pCode, string pMsg, int pParamI=-1, Exception pInner=null);

	}

}