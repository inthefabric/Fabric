using System;

namespace Fabric.Api.Paths.Steps.Functions {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Class)]
	public class FuncAttribute : Attribute {

		public string Name { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncAttribute(string pName) {
			Name = pName;
		}

	}

}