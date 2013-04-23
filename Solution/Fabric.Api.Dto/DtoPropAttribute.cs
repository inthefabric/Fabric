using System;

namespace Fabric.Api.Dto {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property)]
	public class DtoPropAttribute : Attribute {

		public string DisplayName { get; private set; }
		public bool IsInternal { get; set; }
		public string DomainPropName { get; set; }
		public bool IsOptional { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DtoPropAttribute() {}

		/*--------------------------------------------------------------------------------------------*/
		public DtoPropAttribute(string pDisplayName) {
			DisplayName = pDisplayName;
		}

	}

}