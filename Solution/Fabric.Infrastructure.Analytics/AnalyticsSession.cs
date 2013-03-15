using GoogleAnalyticsTracker;

namespace Fabric.Infrastructure.Analytics {
	
	/*================================================================================================*/
	public class AnalyticsSession : IAnalyticsSession {

		private readonly string vSessionId;
		private string vCookie;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AnalyticsSession(string pSessionId, string pCookie) {
			vSessionId = pSessionId;
			vCookie = pCookie;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateCookie(string pCookie) {
			vCookie = pCookie;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		// IAnalyticsSession
		/*--------------------------------------------------------------------------------------------*/
		public string GenerateSessionId() {
			return vSessionId;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GenerateCookieValue() {
			return vCookie;
		}

	}

}