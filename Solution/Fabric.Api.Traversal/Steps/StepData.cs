using System;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Traversal.Steps {
	
	/*================================================================================================*/
	public class StepData : IStepData {

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
				throw new FabStepDataFault(FabFault.Code.InvalidParamSyntax,
					"Invalid parameter syntax: '"+RawString+"'.");
			}

			if ( pi == -1 ) {
				return;
			}

			Command = Command.Substring(0, pi);
			string p = RawString.Substring(pi+1);
			int len = p.Length;

			if ( len == 0 || p[len-1] != ')' ) {
				throw new FabStepDataFault(FabFault.Code.InvalidParamSyntax,
					"Invalid parameter syntax: '"+RawString+"'.");
			}

			p = p.Substring(0, len-1);

			if ( p.Length == 0 ) {
				throw new FabStepDataFault(FabFault.Code.IncorrectParamCount,
					"Empty parameter list: '"+RawString+"'.");
			}

			Params = Regex.Replace(p, @"\s*", "").Split(',');
		}

		/*--------------------------------------------------------------------------------------------*/
		public T ParamAt<T>(int pIndex) {
			if ( Params == null ) {
				throw new InvalidDataException("No parameters available.");
			}

			if ( pIndex < 0 || pIndex >= Params.Length ) {
				throw new ArgumentOutOfRangeException("Index", pIndex,
					"The maximum Index value is "+(Params.Length-1));
			}

			string p = Params[pIndex];
			Type tt = typeof(T);

			if ( tt == typeof(string) ) {
				return (T)(object)p;
			}

			try {
				return (T)TypeDescriptor.GetConverter(tt).ConvertFromString(p);
			}
			catch ( Exception ex ) {
				throw new InvalidCastException("Count not convert parameter at index "+pIndex+
					"to type '"+tt.Name+"'.", ex);
			}
		}

	}

}