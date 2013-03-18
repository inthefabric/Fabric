using System.Collections.Generic;
using Fabric.Domain;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IClassNameCache {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddClass(IApiContext pApiCtx, Class pClass);
		IList<long> GetClassIds(IApiContext pApiCtx, string pName, string pDisamb);

	}

}