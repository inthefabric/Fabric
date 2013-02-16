using System;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public enum ServiceOpParamType {
		Query = 1,
		Form
	}


	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Field)]
	public class ServiceOpParamAttribute : Attribute {

		public ServiceOpParamType ParamType { get; set; }
		public string Name { get; set; }
		public int Index { get; set; }
		public Type DomainClass { get; set; }

		public bool IsRequired { get; set; }
		public string DomainPropertyName { get; set; }
		public string ResxKey { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ServiceOpParamAttribute(ServiceOpParamType pParamType, string pName, int pIndex,
																						Type pDomClass) {
			ParamType = pParamType;
			Name = pName;
			Index = pIndex;
			DomainClass = pDomClass;
			IsRequired = true;
			DomainPropertyName = Name;
			ResxKey = Name;
		}

	}

}