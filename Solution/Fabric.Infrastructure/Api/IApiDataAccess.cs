using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Db;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IApiDataAccess {

		IApiContext Context { get; }

		string Script { get; }
		IDictionary<string, string> Params { get; }
		string Query { get; }

		byte[] ResultBytes { get; }
		string ResultString { get; }
		IDbResult Result { get; }
		IList<IDbDto> ResultDtoList { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Execute();
		T GetResultAt<T>(int pIndex) where T : INodeWithId, new();

	}

}