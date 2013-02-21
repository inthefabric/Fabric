using Fabric.Domain;
using System.Collections.Generic;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IApiDataAccess<T> : IApiDataAccess where T : IItemWithId, new() {

		IList<T> TypedResultList { get; }

	}

}