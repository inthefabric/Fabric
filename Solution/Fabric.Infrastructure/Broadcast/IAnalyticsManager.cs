namespace Fabric.New.Infrastructure.Broadcast {

	/*================================================================================================*/
	public interface IAnalyticsManager {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		string GetCategory(string pHttpMethod, string pPath);
		void TrackRequest(string pMethod, string pUri);
		void TrackEvent(string pCategory, string pAction, string pLabel, int pValue);

	}

}