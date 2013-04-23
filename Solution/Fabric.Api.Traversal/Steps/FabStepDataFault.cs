using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Traversal.Steps {
	
	/*================================================================================================*/
	public class FabStepDataFault : FabFault {

		//public IStep Step { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabStepDataFault(Code pErrCode, string pMessage) : base(pErrCode, pMessage) {}

	}

}