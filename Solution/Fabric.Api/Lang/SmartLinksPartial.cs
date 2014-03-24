using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fabric.New.Api.Lang {

	/*================================================================================================*/
	public static partial class SmartLinks {

		//private static readonly Logger Log = Logger.Build(typeof(SmartLinks));
		private const string DelimSet = @"('s)?[\s.,;-]+";

		private static readonly IDictionary<string, string> ObjMap = new Dictionary<string, string> {
			{"Object", "FabObject"},
			{"Objects", "FabObject"},
			{"FabObject", "FabObject"},
			{"FabObjects", "FabObject"},
			{"CreateFabObject", "FabObject"},
			{"CreateFabObjects", "FabObject"},
			{"Element", "FabElement"},
			{"Elements", "FabElement"},
			{"FabElement", "FabElement"},
			{"FabElements", "FabElement"},
			{"CreateFabElement", "FabElement"},
			{"CreateFabElements", "FabElement"},
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string Convert(string pString) {
			string[] tokens = Regex.Split(pString, @"(?<="+DelimSet+")"); //token includes delimiter

			for ( int i = 0 ; i < tokens.Length ; i++ ) {
				tokens[i] = ConvertToken(tokens[i]);
			}

			return string.Join("", tokens);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string ConvertToken(string pToken) {
			Match m = Regex.Match(pToken, DelimSet);
			string key = (m.Length == 0 ? pToken : pToken.Replace(m.Value, ""));
			string result = key;

			if ( VertMap.ContainsKey(key) ) {
				result = "[["+key+"|Object|"+VertMap[key]+"]]";
				//Log.Debug("VERT "+pToken+" // "+key+" // "+(result+m.Value));
			}
			else if ( ObjMap.ContainsKey(key) ) {
				result = "[["+key+"|Object|"+ObjMap[key]+"]]";
				//Log.Debug("OBJT "+pToken+" // "+key+" // "+(result+m.Value));
			}
			else if ( EdgeMap.ContainsKey(key) ) {
				result = "[["+key+"|Edge|"+EdgeMap[key]+"]]";
				//Log.Debug("EDGE "+pToken+" // "+key+" // "+(result+m.Value));
			}
			else if ( EnumMap.ContainsKey(key) ) {
				result = "[["+key+"|Enum|"+EnumMap[key]+"]]";
				//Log.Debug("ENUM "+pToken+" // "+key+" // "+(result+m.Value));
			}
			else if ( key.IndexOf('!') == 0 ) {
				result = key.Substring(1);
				//Log.Debug("EXCL "+pToken+" // "+key+" // "+(result+m.Value));
			}

			return result+m.Value;
		}

	}

}