using System;

namespace Fabric.Infrastructure.Traversal {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Class)]
	public class FuncAttribute : Attribute {

		public string Name { get; private set; }
		public string ResxKey { get; set; }
		public bool IsInternal { get; set; }
		public bool ReturnsPrevious { get; set; }
		public bool ReturnsReferenced { get; set; }
		public Type ReturnsObject { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncAttribute(string pName) {
			Name = pName;
		}

	}

}