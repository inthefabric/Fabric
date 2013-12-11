﻿using System.Collections.Generic;
using Fabric.New.Infrastructure.Data;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public class CreateOperationContext : ICreateOperationContext {

		private readonly IDataAccess vDataAcc;
		private readonly IList<DataResultCheck> vChecks;
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
		public void AddCheck(DataResultCheck pCheck) {
			vChecks.Add(pCheck);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void PerformChecks(IDataResult pResult) {
			foreach ( DataResultCheck check in vChecks ) {
				check.PerformCheck(pResult);
			}
		}

	}

}