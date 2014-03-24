using System;

namespace Fabric.New.Infrastructure.Spec {

	/*================================================================================================*/
	[AttributeUsage(AttributeTargets.Class)]
	public class SpecStepAttribute : Attribute {
	
		public string Name { get; private set; }
		public bool IsRoot { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SpecStepAttribute(string pName) {
			Name = pName;
		}
	
	}

}