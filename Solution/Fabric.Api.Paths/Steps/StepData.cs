using System;

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

			if ( pi == -1 ) {
				return;
			}

			Command = Command.Substring(0, pi);
			string p = Command.Substring(pi+1);
			int len = p.Length;

			if ( len == 0 || p[len-1] != ')' ) {
				throw new Exception("Invalid parameter syntax: '"+RawString+"'.");
			}

			p = p.Substring(0, len-1);

			if ( p.Length == 0 ) {
				throw new Exception("Empty parameter list: '"+RawString+"'.");
			}

			Params = p.Replace(" ", "").Split(',');
		}

	}

}