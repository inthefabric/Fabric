namespace Fabric.New.Domain.Schemas.Utils {

	/*================================================================================================*/
	public class PropertyMapping {

		public DomainProperty Domain { get; private set; }
		public ApiProperty Api { get; private set; }
		public bool Custom { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public PropertyMapping(DomainProperty pDom, ApiProperty pApi, bool pCustom=false) {
			Domain = pDom;
			Api = pApi;
			Custom = pCustom;
		}

	}


	/*================================================================================================*/
	public class PropertyMapping<TDom, TApi> : PropertyMapping {

		public DomainProperty<TDom> DomainT { get; private set; }
		public ApiProperty<TApi> ApiT { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public PropertyMapping(DomainProperty<TDom> pDom, ApiProperty<TApi> pApi, bool pCustom=false) :
																			base(pDom, pApi, pCustom) {
			DomainT = pDom;
			ApiT = pApi;
		}

	}

}