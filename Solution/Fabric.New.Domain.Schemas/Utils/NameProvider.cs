namespace Fabric.New.Domain.Schemas.Utils {
	
	/*================================================================================================*/
	public class NameProvider {

		public string Domain { get; private set; }
		public string DomainPlural { get; private set; }
		public string Database { get; private set; }
		public string Api { get; private set; }
		public string ApiPlural { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public NameProvider(string pDomain, string pDomainPlural, string pDatabase, bool pFab=true) {
			Domain = pDomain;
			DomainPlural = pDomainPlural;
			Database = pDatabase;
			Api = (pFab ? "Fab" : "")+pDomain;
			ApiPlural = (pFab ? "Fab" : "")+pDomainPlural;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public NameProvider(string pDomain, string pDomainPlural, string pDatabase, 
																	string pApi, string pApiPlural) {
			Domain = pDomain;
			DomainPlural = pDomainPlural;
			Database = pDatabase;
			Api = pApi;
			ApiPlural = pApiPlural;
		}

	}

}