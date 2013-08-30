using System.Collections.Generic;
using Fabric.Infrastructure.Api;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public interface IDataAccess {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Build(IApiContext pApiCtx, string pSessionId=null, bool pSetCmdIds=false,
																			bool pOmitCmdTimers=true);

		/*--------------------------------------------------------------------------------------------*/
		string GetLatestCommandId();
		void AddConditionsToLatestCommand(string pCmdId);
		void AppendScriptToLatestCommand(string pScript);
		void OmitResultsOfLatestCommand();
		void RemoveCommandIdOfLatestCommand();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataAccess AddQuery(string pScript);
		IDataAccess AddQuery(string pScript, IDictionary<string, string> pParams);
		IDataAccess AddQuery(string pScript, IDictionary<string, IWeaverQueryVal> pParams);
		IDataAccess AddQuery(IWeaverScript pWeaverScript);
		IDataAccess AddQueries(IEnumerable<IWeaverScript> pWeaverScripts);
		IDataAccess AddQueries(IWeaverTransaction pTx);

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