//#define MONO_DEV

using System;
#if !MONO_DEV
using System.Linq;
using GoogleAnalyticsTracker;
#endif

namespace Fabric.Infrastructure.Analytics {
	
	/*================================================================================================*/
	public class AnalyticsManager {

#if !MONO_DEV
		private readonly Tracker vTracker;
		private readonly Action<string> vLogAction;
#endif

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AnalyticsManager(Guid pContextId, Action<string> pLogAction) {
#if !MONO_DEV
			vLogAction = pLogAction;
			vTracker = new Tracker("UA-39329646-1", "inthefabric.com");
			vTracker.Hostname = "api.inthefabric.com";
			vTracker.SetCustomVariable(1, "ContextId", pContextId+"");
#endif
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string GetCategory(string pHttpMethod, string pPath) {
			string cat = pHttpMethod+" "+pPath.Replace(")", @"}");

			if ( cat.Length > 46 ) {
				cat = cat.Substring(0, 43)+"...";
			}

			return cat;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void TrackRequest(string pMethod, string pUri) {
#if !MONO_DEV
			int i = 1; //skip leading slash
			int n = 0;

			while ( true ) {
				int tryI;

				if ( (tryI = pUri.IndexOf('/', i)) == -1 ) {
					i = pUri.Length;
					break;
				}

				i = tryI+1;

				if ( ++n >= 2 ) {
					break;
				}
			}

			//var task = 
			vTracker.TrackPageViewAsync(pMethod+" "+pUri.Substring(0, i), pUri);
			//task.ContinueWith(x => LogResult("Request", x.Result));
#endif	
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TrackEvent(string pCategory, string pAction, string pLabel, int pValue) {
#if !MONO_DEV
			//var task = 
			vTracker.TrackEventAsync(pCategory, pAction, pLabel, pValue);
			//task.ContinueWith(x => LogResult("Event", x.Result));
#endif
		}


#if !MONO_DEV
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void LogResult(string pType, TrackingResult pResult) {
			vLogAction(pType+": "+pResult.Success+" | "+pResult.Url+" | "+
				pResult.Parameters.Aggregate("", (str,p) => str+", "+p.Key+"="+p.Value));
		}
#endif

	}

}