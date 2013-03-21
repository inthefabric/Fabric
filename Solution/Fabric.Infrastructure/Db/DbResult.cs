using System.Collections.Generic;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public class DbResult : IDbResult {

		public string Request { get; set; }
		public bool Success { get; set; }
		public int QueryTime { get; set; }
		public double ServerTime { get; set; }
		public string Exception { get; set; }
		public string Message { get; set; }
		public string Text { get; set; }

		public IList<DbDtoRaw> Results { get; set; }
		public IList<DbDto> DbDtos { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void BuildDbDtos(string pResultJson) {
			DbDtos = new List<DbDto>();

			if ( Results != null ) {
				foreach ( DbDtoRaw r in Results ) {
					DbDtos.Add(new DbDto(r));
				}

				Results = null;
			}

			const string textResultStart = "\"results\":[";
			int startI = pResultJson.IndexOf(textResultStart);

			if ( startI == -1 ) {
				return;
			}

			startI += textResultStart.Length;
			
			if ( pResultJson[startI] == '{' ) {
				return;
			}

			int endI = pResultJson.IndexOf("],", startI);

			Text = pResultJson.Substring(startI, endI-startI);
			DbDtos = null;
		}

	}

}