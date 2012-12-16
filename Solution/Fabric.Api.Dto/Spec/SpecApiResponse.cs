using System.Collections.Generic;
using System.Linq;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class SpecApiResponse : SpecDto {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecApiResponse() {
			Name = typeof(FabResponse).Name;
			Description = SpecDoc.GetDtoText(Name.Substring(3));
			Abstract = Description.Substring(0, Description.IndexOf('.')+1);

			Dictionary<string,SpecProperty> propMap = SpecDoc.ReflectProps<FabResponse>();
			PropertyList = propMap.Values.ToList();
		}

	}

}