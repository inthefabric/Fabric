using System;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public enum ServiceOpParamType {
		Query = 1,
		Form
	}


	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class ServiceOpParamAttribute : Attribute {

		public ServiceOpParamType ParamType { get; set; }
		public string Name { get; set; }
		public Type DomainClass { get; set; }

		public bool IsRequired { get; set; }
		public string DomainPropertyName { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ServiceOpParamAttribute(ServiceOpParamType pParamType, string pName, Type pDomClass) {
			ParamType = pParamType;
			Name = pName;
			DomainClass = pDomClass;
			IsRequired = true;
			DomainPropertyName = null;
		}

	}

}