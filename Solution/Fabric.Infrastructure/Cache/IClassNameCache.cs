using System.Collections.Generic;
using Fabric.Infrastructure.Api;

namespace Fabric.Infrastructure.Cache {

	/*================================================================================================*/
	public interface IClassNameCache {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool IsLoadComplete();
		int GetLoadIndex();
		int GetKeyCount();
		void AddClass(IApiContext pApiCtx, long pClassId, string pName, string pDisamb);
		IList<long> GetClassIds(IApiContext pApiCtx, string pName, string pDisamb);
		bool HasDuplicateClass(string pName, string pDisamb);

	}

}