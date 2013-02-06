using System;

namespace Fabric.Infrastructure.Traversal {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Class)]
	public class FuncAttribute : Attribute {

		public string Name { get; set; }
		public string ResxKey { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncAttribute(string pName) {
			Name = pName;
		}

	}

}