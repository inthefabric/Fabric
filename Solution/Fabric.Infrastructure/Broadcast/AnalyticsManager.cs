//#define MONO_DEV

using System;
using GoogleAnalyticsTracker;

#if !MONO_DEV

#endif

namespace Fabric.Infrastructure.Broadcast {
	
	/*================================================================================================*/
	public class AnalyticsManager : IAnalyticsManager { //TEST: AnalyticsManager

#if !MONO_DEV
		private readonly Tracker vTracker;
#endif

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AnalyticsManager(Guid pContextId) {
#if !MONO_DEV
			vTracker = new Tracker("UA-39329646-1", "inthefabric.com");
			vTracker.Hostname = "api.inthefabric.com";
			vTracker.SetCustomVariable(1, "ContextId", pContextId+"");
#endif
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetCategory(string pHttpMethod, string pPath) {
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

	}

}