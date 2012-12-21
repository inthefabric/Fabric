using System;

namespace Fabric.Api.Dto {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property)]
	public class DtoPropAttribute : Attribute {

		public bool IsInternal { get; set; }
		public string DisplayName { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DtoPropAttribute(string pDisplayName) {
			DisplayName = pDisplayName;
			IsInternal = false;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DtoPropAttribute(bool pIsInternal) {
			IsInternal = pIsInternal;
			DisplayName = null;
		}

	}

}