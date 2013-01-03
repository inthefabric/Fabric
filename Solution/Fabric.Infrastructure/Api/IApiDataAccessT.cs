using Fabric.Domain;
using System.Collections.Generic;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IApiDataAccess<T> : IApiDataAccess where T : INodeWithId, new() {

		T TypedResult { get; }
		IList<T> TypedResultList { get; }

	}

}