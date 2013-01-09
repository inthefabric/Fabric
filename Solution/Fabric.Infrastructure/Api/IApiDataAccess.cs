using System.Collections.Generic;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IApiDataAccess {

		IApiContext Context { get; }

		string Script { get; }
		IDictionary<string, string> Params { get; }
		string Query { get; }

		byte[] ResultBytes { get; }
		string ResultString { get; }
		IDbDto ResultDto { get; }
		IList<IDbDto> ResultDtoList { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Execute();

	}

}