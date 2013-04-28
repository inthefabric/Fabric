using System.Collections.Generic;
using ServiceStack.Text;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public class DbResult : IDbResult { //TEST: DbResult functions

		public int QueryTime { get; private set; }
		public IList<IList<DbDto>> CmdDbDtos { get; private set; }
		public IList<DbDto> DbDtos { get; private set; }

		public double ServerTime { get; set; }
		public string Exception { get; set; }
		public string Message { get; set; }

		private readonly string vResponseJson;
		private IList<string> vTextList;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbResult(RexConnTcpResponse pResponse, string pResponseJson) {
			Exception = pResponse.Err;
			QueryTime = (int)pResponse.Timer;
			DbDtos = new List<DbDto>();
			CmdDbDtos = new List<IList<DbDto>>();

			vResponseJson = pResponseJson;

			foreach ( RexConnTcpResponseCommand rc in pResponse.CmdList ) {
				var cmdDtos = new List<DbDto>();
				CmdDbDtos.Add(cmdDtos);

				if ( rc.Results == null ) {
					continue;
				}

				foreach ( JsonObject jo in rc.Results ) {
					var dto = new DbDto(jo);
					DbDtos.Add(dto);
					cmdDtos.Add(dto);
				}
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<string> TextList {
			get {
				if ( vTextList == null ) {
					BuildTextList();
				}

				return vTextList;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void BuildTextList() { //TODO: support RexConnect "session" mode
			vTextList = new List<string>();
			
			const string startText = "\"results\":[";
			int startI = vResponseJson.IndexOf(startText);

			if ( startI == -1 ) {
				return;
			}

			startI += startText.Length;
			int endI = vResponseJson.IndexOf("]}", startI);
			string text = vResponseJson.Substring(startI, endI-startI);

			////
			
			int i = 0;
			int j = -1;
			int lastIndex = text.Length-1;
			bool inQuote = false;
			int inCurly = 0;
			int inSquare = 0;

			foreach ( char c in text ) {
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
					TextList.Add(text.Substring(i,j-i).Trim());
					i = j+1;
					continue;
				}

				if ( j == lastIndex ) {
					TextList.Add(text.Substring(i).Trim());
					break;
				}
			}

		}

	}

}