﻿namespace Fabric.Domain.Schemas.Utils {

	/*================================================================================================*/
	public class PropertyMapping {

		public DomainProperty Domain { get; private set; }
		public ApiProperty Api { get; private set; }
		public CustomDir Custom { get; set; }
		public string ApiToDomainNote { get; set; }
		public string DomainToApiNote { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public PropertyMapping(DomainProperty pDom, ApiProperty pApi, 
																CustomDir pCustom=CustomDir.Neither) {
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
		public PropertyMapping(DomainProperty<TDom> pDom, ApiProperty<TApi> pApi,
									CustomDir pCustom=CustomDir.Neither) : base(pDom, pApi, pCustom) {
			DomainT = pDom;
			ApiT = pApi;
		}

	}

}