using System;
using Fabric.Infrastructure.Faults;

namespace Fabric.Operations.Traversal.Routing {

	/*================================================================================================*/
	public interface ITravPathItem {

		int StepIndex { get; }
		string RawText { get; }
		string Command { get; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		T GetParamAt<T>(int pIndex);

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