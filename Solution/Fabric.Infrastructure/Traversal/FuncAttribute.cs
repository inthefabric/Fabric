using System;

namespace Fabric.Infrastructure.Traversal {
	
	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Class)]
	public class FuncAttribute : Attribute {

		public string Name { get; private set; }
		public string ResxKey { get; set; }
		public bool IsInternal { get; set; }
		public bool ReturnsPreviousType { get; set; }
		public bool ReturnsAliasType { get; set; }
		public Type ReturnsObjectType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncAttribute(string pName) {
			Name = pName;
		}

	}

}