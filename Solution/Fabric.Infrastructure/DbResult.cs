﻿using System.Collections.Generic;

namespace Fabric.Infrastructure {
	
	/*================================================================================================*/
	public class DbResult : IDbResult {

		public bool Success { get; set; }
		public string Version { get; set; }
		public double QueryTime { get; set; }
		public long ServerTicks { get; set; }
		public string Exception { get; set; }
		public string Message { get; set; }
		public string Text { get; set; }

		public IList<IDictionary<string, string>> Results { get; set; }
		public IList<DbDto> DbDtos { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void BuildDbDtos(string pResultJson) {
			DbDtos = new List<DbDto>();

			if ( Results != null ) {
				foreach ( IDictionary<string, string> r in Results ) {
					DbDtos.Add(new DbDto(r));
				}

				Results = null;
			}

			const string textResultStart = "\"results\":[\"";
			int startI = pResultJson.IndexOf(textResultStart);

			if ( startI == -1 ) {
				return;
			}

			startI += textResultStart.Length;
			int endI = pResultJson.IndexOf("\"],", startI);

			Text = pResultJson.Substring(startI, endI-startI);
			DbDtos = null;
		}

	}

}