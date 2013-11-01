using System;

namespace Fabric.Domain.Meta.Vertices.Tools {

	/*================================================================================================*/
	public class PropertyMapping<TDomType, TApiType> {

		public DomainProperty<TDomType> Domain { get; private set; }
		public ApiProperty<TApiType> Api { get; private set; }

		public Func<TDomType, TApiType> DomainToApi { get; internal set; }
		public Func<TApiType, TDomType> ApiToDomain { get; internal set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public PropertyMapping(DomainProperty<TDomType> pDomain, ApiProperty<TApiType> pApi) {
			Domain = pDomain;
			Api = pApi;
		}

	}

}