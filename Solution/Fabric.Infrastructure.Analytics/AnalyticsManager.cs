using System;
using GoogleAnalyticsTracker;

namespace Fabric.Infrastructure.Analytics {
	
	/*================================================================================================*/
	public class AnalyticsManager {

		private readonly AnalyticsSession vSession;
		private readonly Tracker vTracker;
		private readonly Action<string> vLogAction;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AnalyticsManager(Guid pContextId, Action<string> pLogAction) {
			vSession = new AnalyticsSession(pContextId+"", "");
			vLogAction = pLogAction;
			vTracker = new Tracker("UA-39329646-2", "api.inthefabric.com", vSession);
		}

		/*--------------------------------------------------------------------------------------------* /
		public void SetAppUserId(long pAppId, long pUserId) {
			vSession.UpdateCookie("AppId="+pAppId+";UserId="+pUserId);
			vTracker.SetCustomVariable(0, "AppId", pAppId+"");
			vTracker.SetCustomVariable(1, "UserId", pUserId+"");
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

			var task = vTracker.TrackPageViewAsync(pMethod+pUri.Substring(0, i-1), pUri);
			//task.ContinueWith(x => vLogAction(" *** TrackRequest: "+x.Result.Success));
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TrackEvent(string pCategory, string pAction, string pLabel, int pValue) {
			var task = vTracker.TrackEventAsync(pCategory, pAction, pLabel, pValue);
			//task.ContinueWith(x => vLogAction(" *** TrackEvent: "+x.Result.Success));
		}

	}

}