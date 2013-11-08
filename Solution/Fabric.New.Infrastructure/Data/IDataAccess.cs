using System.Collections.Generic;
using Weaver.Core.Query;

namespace Fabric.New.Infrastructure.Data {

	/*================================================================================================*/
	public interface IDataAccess {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Build(IDataContext pDataCtx);

		/*--------------------------------------------------------------------------------------------*/
		string GetLatestCommandId();
		void AddConditionsToLatestCommand(string pCmdId);
		void AppendScriptToLatestCommand(string pScript);
		void OmitResultsOfLatestCommand();
		void RemoveCommandIdOfLatestCommand();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataAccess AddQuery(string pScript, bool pCache=false);
		IDataAccess AddQuery(string pScript, IDictionary<string, string> pParams, bool pCache=false);
		IDataAccess AddQuery(string pScript, IDictionary<string, IWeaverQueryVal> pParams,
			bool pCache=false);
		IDataAccess AddQuery(IWeaverScript pWeaverScript, bool pCache=false);
		IDataAccess AddQueries(IEnumerable<IWeaverScript> pWeaverScripts, bool pCache=false);
		IDataAccess AddQueries(IWeaverTransaction pTx, bool pCache=false);

		/*--------------------------------------------------------------------------------------------*/
		IDataAccess AddSessionStart();
		IDataAccess AddSessionClose();
		IDataAccess AddSessionRollback();
		IDataAccess AddSessionCommit();

		/*--------------------------------------------------------------------------------------------*/
		IDataAccess AddConfigDebug(bool pEnable);
		IDataAccess AddConfigPretty(bool pEnable);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataResult Execute(string pName);
		string ExecuteName { get; }

	}

}