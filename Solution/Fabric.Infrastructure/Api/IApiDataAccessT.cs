using Fabric.Domain;
using System.Collections.Generic;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IApiDataAccess<T> : IApiDataAccess where T : INode, new() {

		T TypedResult { get; }
		List<T> TypedResultList { get; }

	}

}