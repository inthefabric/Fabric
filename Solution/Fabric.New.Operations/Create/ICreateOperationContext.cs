﻿using Fabric.New.Infrastructure.Data;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public interface ICreateOperationContext {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddQuery(IWeaverQuery pQuery, bool pCache=false, string pAppendScript=null);

		/*--------------------------------------------------------------------------------------------*/
		string SetupLatestCommand(bool pOmitResults=false, bool pNewCondition=false);

		/*--------------------------------------------------------------------------------------------*/
		void CommitAndCloseSession();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddCheck(IDataResultCheck pCheck);
		
		/*--------------------------------------------------------------------------------------------*/
		void PerformChecks(IDataResult pResult);

	}

}