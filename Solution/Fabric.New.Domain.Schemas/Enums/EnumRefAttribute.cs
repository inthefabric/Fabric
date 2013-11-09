using System;

namespace Fabric.New.Domain.Schemas.Enums {

	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Property)]
	public class EnumRefAttribute : Attribute {

		public string EnumType { get; private set; } 


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EnumRefAttribute(string pEnumType) {
			EnumType = pEnumType;
		}

	}

}