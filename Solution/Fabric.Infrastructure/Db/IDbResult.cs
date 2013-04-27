using System.Collections.Generic;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public interface IDbResult {

		int QueryTime { get; }
		IList<string> TextList { get; }
		IList<DbDto> DbDtos { get; }

		double ServerTime { get; set; }
		string Exception { get; set; }
		string Message { get; set; }

	}

}