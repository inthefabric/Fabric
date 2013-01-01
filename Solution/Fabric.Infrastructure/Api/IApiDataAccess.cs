using System.Collections.Generic;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IApiDataAccess {

		ApiContext Context { get; }

		string Script { get; }
		IDictionary<string, string> Params { get; }
		string Query { get; }

		byte[] ResultBytes { get; }
		string ResultString { get; }
		IDbDto ResultDto { get; }
		List<IDbDto> ResultDtoList { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Execute();

	}

}