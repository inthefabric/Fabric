using System;
using Fabric.New.Infrastructure.Data;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	internal class DataResultCheck {

		private readonly string vCommandId;
		private readonly Action<IDataResult, int> vCheck;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataResultCheck(string pCommandId, Action<IDataResult, int> pCheck) {
			vCommandId = pCommandId;
			vCheck = pCheck;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void PerformCheck(IDataResult pDataRes) {
			int index = pDataRes.GetCommandIndexByCmdId(vCommandId);
			vCheck(pDataRes, index);
		}

	}

}