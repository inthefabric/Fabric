using System;
using Fabric.New.Infrastructure.Data;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public class DataResultCheck : IDataResultCheck {

		public string CommandId { get; private set; }

		private readonly Action<IDataResult, int> vCheck;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataResultCheck(string pCommandId, Action<IDataResult, int> pCheck) {
			CommandId = pCommandId;
			vCheck = pCheck;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void PerformCheck(IDataResult pDataRes) {
			int index = pDataRes.GetCommandIndexByCmdId(CommandId);
			vCheck(pDataRes, index);
		}

	}

}