using System.Collections.Generic;
using Fabric.Infrastructure.Data;
using Weaver.Core.Query;

namespace Fabric.Operations.Create {

	/*================================================================================================*/
	public class CreateOperationBuilder : ICreateOperationBuilder {

		private readonly IList<IDataResultCheck> vChecks;
		private IDataAccess vDataAcc;
		private string vLatestConditionCmdId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateOperationBuilder() {
			vChecks = new List<IDataResultCheck>();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetDataAccess(IDataAccess pDataAcc) {
			vDataAcc = pDataAcc;
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
		public void StartSession() {
			vDataAcc.AddSessionStart();
			SetupLatestCommand();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void CommitAndCloseSession() {
			vDataAcc.AddSessionCommit();
			SetupLatestCommand();

			vLatestConditionCmdId = null; //ensure session closes
			vDataAcc.AddSessionClose();
			SetupLatestCommand();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddCheck(IDataResultCheck pCheck) {
			vChecks.Add(pCheck);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void PerformChecks(IDataResult pResult) {
			foreach ( IDataResultCheck check in vChecks ) {
				check.PerformCheck(pResult);
			}
		}

	}

}