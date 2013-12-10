using System.Collections.Generic;
using Fabric.New.Infrastructure.Data;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public class CreateOperationContext : ICreateOperationContext {

		private readonly IDataAccess vDataAcc;
		private IList<DataResultCheck> vChecks;
		private string vLatestConditionCmdId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateOperationContext(IDataAccess pDataAcc) {
			vDataAcc = pDataAcc;
			vChecks = new List<DataResultCheck>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddQuery(IWeaverQuery pQuery, bool pCache=false, string pAppendScript=null) {
			vDataAcc.AddQuery(pQuery, pCache);

			if ( pAppendScript != null ) {
				vDataAcc.AppendScriptToLatestCommand(pAppendScript);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public string SetupLatestCommand(bool pOmitResults=false, bool pNewCondition=false) {
			if ( vLatestConditionCmdId != null ) {
				vDataAcc.AddConditionsToLatestCommand(vLatestConditionCmdId);
			}

			if ( pOmitResults ) {
				vDataAcc.OmitResultsOfLatestCommand();
			}

			string cmdId = vDataAcc.GetLatestCommandId();

			if ( pNewCondition ) {
				vLatestConditionCmdId = cmdId;
			}

			return cmdId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddCheck(DataResultCheck pCheck) {
			vChecks = new List<DataResultCheck>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<DataResultCheck> GetChecks() {
			return vChecks;
		}

	}

}