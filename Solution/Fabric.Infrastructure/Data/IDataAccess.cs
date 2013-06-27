using System.Collections.Generic;
using Fabric.Infrastructure.Api;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public interface IDataAccess {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Build(IApiContext pApiCtx, string pSessionId=null);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		DataAccess AddQuery(string pScript);
		DataAccess AddQuery(string pScript, IDictionary<string, string> pParams);
		DataAccess AddQuery(string pScript, IDictionary<string, IWeaverQueryVal> pParams);
		DataAccess AddQuery(IWeaverScript pWeaverScript);
		DataAccess AddQuery(IEnumerable<IWeaverScript> pWeaverScripts);

		/*--------------------------------------------------------------------------------------------*/
		DataAccess AddSessionStart();
		DataAccess AddSessionClose();
		DataAccess AddSessionRollback();
		DataAccess AddSessionCommit();

		/*--------------------------------------------------------------------------------------------*/
		DataAccess AddConfigDebug(bool pEnable);
		DataAccess AddConfigPretty(bool pEnable);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		DataResult Execute();

	}

}