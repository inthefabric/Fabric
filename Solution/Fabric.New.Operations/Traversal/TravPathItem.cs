using System;
using System.ComponentModel;
using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TravPathItem : ITravPathItem {

		public int StepIndex { get; private set; }
		public string RawText { get; private set; }
		public string Command { get; private set; }

		private string[] vParams;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravPathItem(int pStepIndex, string pRawText) {
			StepIndex = pStepIndex;
			RawText = pRawText;
			Command = RawText+"";
			vParams = new string[0];

			int pi = RawText.IndexOf('(');

			if ( pi != -1 ) {
				Command = Command.Substring(0, pi);
				BuildParams(pi);
			}

			Command = Command.ToLower();

			if ( Command.Length == 0 ) {
				throw NewStepFault(FabFault.Code.InvalidStep, "Step is empty.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private void BuildParams(int pParamI) {
			string raw = RawText.Substring(pParamI);

			if ( raw.Length < 2 || raw.Substring(raw.Length-1) != ")" ) {
				throw NewStepFault(FabFault.Code.InvalidParamSyntax, "Invalid parameter format.");
			}

			raw = raw.Substring(1, raw.Length-2);
			vParams = (raw.Length > 0 ? raw.Split(',') : new string[0]);

			for ( int i = 0 ; i < vParams.Length ; i++ ) {
				if ( vParams[i].Length == 0 ) {
					throw NewStepFault(FabFault.Code.InvalidParamSyntax, "Parameter is empty.", i);
				}
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public int GetParamCount() {
			return vParams.Length;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void VerifyParamCount(int pMinCount, int pMaxCount=-1) {
			int max = (pMaxCount == -1 ? pMinCount : pMaxCount);
			int n = vParams.Length;

			if ( n < pMinCount || n > max ) {
				throw NewStepFault(FabFault.Code.IncorrectParamCount, "Expected "+pMinCount+""+
					(pMaxCount != -1 ? " (or up to "+pMaxCount+")" : "")+
					" parameter(s), but found "+n+".");
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T ParamAt<T>(int pIndex) {
			string p = vParams[pIndex];
			Type tt = typeof(T);

			if ( tt == typeof(string) ) {
				return (T)(object)p;
			}

			try {
				return (T)TypeDescriptor.GetConverter(tt).ConvertFromString(p);
			}
			catch ( Exception ex ) {
				throw NewStepFault(FabFault.Code.IncorrectParamType,
					"Expected paramter type '"+tt.Name+"'.", pIndex, ex);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabStepFault NewStepFault(FabFault.Code pCode, string pMsg,
															int pParamI=-1, Exception pInner=null) {
			string paramRaw = null;

			if ( pParamI != -1 ) {
				paramRaw = (vParams != null && vParams.Length > pParamI ? vParams[pParamI] : "");
			}

			return new FabStepFault(pCode, StepIndex, RawText, pMsg, pParamI, paramRaw, pInner);
		}

	}

}