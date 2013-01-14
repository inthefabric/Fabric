using System.Collections.Generic;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public interface IDbResult {

		bool Success { get; set; }
		string Version { get; set; }
		double QueryTime { get; set; }
		long ServerTicks { get; set; }
		string Exception { get; set; }
		string Message { get; set; }
		string Text { get; set; }

		IList<IDictionary<string, string>> Results { get; set; }
		IList<DbDto> DbDtos { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void BuildDbDtos(string pResultJson);

	}

}