using System.Collections.Generic;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public interface IDbResult {

		string Request { get; set; }
		bool Success { get; set; }
		int QueryTime { get; set; }
		double ServerTime { get; set; }
		string Exception { get; set; }
		string Message { get; set; }
		string Text { get; set; }
		IList<string> TextList { get; set; }

		IList<DbDtoRaw> Results { get; set; }
		IList<DbDto> DbDtos { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void BuildDbDtos(string pResultJson);

	}

}