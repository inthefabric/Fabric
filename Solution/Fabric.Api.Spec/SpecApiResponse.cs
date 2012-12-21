using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Dto;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public class SpecApiResponse : SpecDto {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecApiResponse() {
			Name = typeof(FabResponse).Name;
			Description = SpecDoc.GetDtoText(Name.Substring(3));
			Abstract = Description.Substring(0, Description.IndexOf('.')+1);

			Dictionary<string,SpecDtoProp> propMap = SpecDoc.ReflectProps<FabResponse>();
			PropertyList = propMap.Values.ToList();
		}

	}

}