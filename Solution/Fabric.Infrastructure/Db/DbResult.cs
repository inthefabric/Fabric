using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public class DbResult : IDbResult { //TEST: DbResult functions

		//Regex from http://stackoverflow.com/questions/3776458/
		//	split-a-comma-separated-string-with-both-quoted-and-unquoted-strings
		private static readonly Regex SmartCommaSplit = 
			new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);

		public string Request { get; set; }
		public bool Success { get; set; }
		public int QueryTime { get; set; }
		public double ServerTime { get; set; }
		public string Exception { get; set; }
		public string Message { get; set; }
		public string Text { get; set; }
		public IList<string> TextList { get; set; }

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

			if ( DbDtos.Count > 0 && DbDtos[0].Id != null ) {
				return;
			}

			const string textResultStart = "\"results\":[";
			int startI = pResultJson.IndexOf(textResultStart);

			if ( startI == -1 ) {
				return;
			}

			startI += textResultStart.Length;
			int endI = pResultJson.IndexOf("],", startI);

			Text = pResultJson.Substring(startI, endI-startI);
			BuildTextList();
			DbDtos = null;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void BuildTextList() {
			TextList = new List<string>();
			int i = 0;
			int j = -1;
			int lastIndex = Text.Length-1;
			bool inQuote = false;
			int inCurly = 0;
			int inSquare = 0;

			foreach ( char c in Text ) {
				++j;

				switch ( c ) {
					case '"': inQuote = !inQuote; break;
					case '{': inCurly++; break;
					case '}': inCurly--; break;
					case '[': inSquare++; break;
					case ']': inSquare--; break;
				}

				if ( inQuote || inCurly > 0 || inSquare > 0 ) {
					continue;
				}

				if ( c == ',' ) {
					TextList.Add(Text.Substring(i,j-i).Trim());
					i = j+1;
					continue;
				}

				if ( j == lastIndex ) {
					TextList.Add(Text.Substring(i).Trim());
					break;
				}
			}

		}

	}

}