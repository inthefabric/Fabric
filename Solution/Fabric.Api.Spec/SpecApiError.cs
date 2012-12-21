using System.Collections.Generic;
using System.Linq;
using Fabric.Api.Dto;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public class SpecApiError : SpecDto {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecApiError() {
			Name = typeof(FabError).Name;
			Description = SpecDoc.GetDtoText(Name.Substring(3));
			Abstract = Description.Substring(0, Description.IndexOf('.')+1);

			Dictionary<string,SpecDtoProp> propMap = SpecDoc.ReflectProps<FabError>();
			PropertyList = propMap.Values.ToList();
		}

	}

}