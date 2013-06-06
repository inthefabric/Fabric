using System.Collections.Generic;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public interface IDbResult {

		int QueryTime { get; }
		IList<string> TextList { get; }
		IList<DbDto> DbDtos { get; }
		IList<IList<DbDto>> CmdDbDtos { get; }

		int ServerTime { get; set; }
		string Exception { get; set; }
		string Message { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IList<string> GetTextListForCommandAt(int pIndex);

	}

}