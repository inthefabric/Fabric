using System;
using System.Text.RegularExpressions;

namespace Fabric.Api.Paths.Steps {
	
	/*================================================================================================*/
	public class StepData {

		public string RawString { get; private set; }
		public string Command { get; private set; }
		public string[] Params { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public StepData(string pRawString) {
			RawString = pRawString;

			Command = RawString.ToLower();
			int pi = Command.IndexOf('(');
			int pi2 = Command.LastIndexOf(')');

			if ( (pi != -1 && pi2 < pi) || (pi == -1 && pi2 != -1) ) {
				throw new Exception("Invalid parameter syntax: '"+RawString+"'.");
			}

			if ( pi == -1 ) {
				return;
			}

			Command = Command.Substring(0, pi);
			string p = RawString.Substring(pi+1);
			int len = p.Length;

			if ( len == 0 || p[len-1] != ')' ) {
				throw new Exception("Invalid parameter syntax: '"+RawString+"'.");
			}

			p = p.Substring(0, len-1);

			if ( p.Length == 0 ) {
				throw new Exception("Empty parameter list: '"+RawString+"'.");
			}

			Params = Regex.Replace(p, @"\s*", "").Split(',');
		}

	}

}