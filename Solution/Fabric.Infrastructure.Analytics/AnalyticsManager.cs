using System;
using System.Linq;
using GoogleAnalyticsTracker;

namespace Fabric.Infrastructure.Analytics {
	
	/*================================================================================================*/
	public class AnalyticsManager {

		private readonly Tracker vTracker;
		private readonly Action<string> vLogAction;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AnalyticsManager(Guid pContextId, Action<string> pLogAction) {
			vLogAction = pLogAction;
			vTracker = new Tracker("UA-39329646-1", "inthefabric.com");
			vTracker.Hostname = "api.inthefabric.com";
			vTracker.SetCustomVariable(1, "ContextId", pContextId+"");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void TrackRequest(string pMethod, string pUri) {
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
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TrackEvent(string pCategory, string pAction, string pLabel, int pValue) {
			//var task = 
			vTracker.TrackEventAsync(pCategory, pAction, pLabel, pValue);
			//task.ContinueWith(x => LogResult("Event", x.Result));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void LogResult(string pType, TrackingResult pResult) {
			vLogAction(pType+": "+pResult.Success+" | "+pResult.Url+" | "+
				pResult.Parameters.Aggregate("", (str,p) => str+", "+p.Key+"="+p.Value));
		}

	}

}